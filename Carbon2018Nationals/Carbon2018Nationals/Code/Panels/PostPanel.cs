using Carbolibrary;
using CarboUiComponent;
using Carboutil;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;

namespace Carbon
{

	public partial class PostPanel : UserControl
	{

		#region ############################# CONSTRUCTOR ###############################

		public PostPanel()
		{
			InitializeComponent();

			// instances

			CarbolistTheme tempTheme = CarbolistTheme.LightBlue;
			tempTheme.ItemForeColor = Color.DarkGray;
			tempTheme.DefaultItemForeColor = Color.DimGray;

			TagList = new Carbotilelist(tempTheme, TagListSampleButton, OnTagListItemSelect)
			{
				CanSelect = false,
			};

			TagList.RegisterItemMenuButtons(Global.SpecialString.X, DeleteButton.BackColor, DeleteButton.ForeColor);

			// customize style of "new" button in taglist
			AddTagItem = TagList.AddDefaultItem("Add Tag");
			AddTagItem.Paint += OnTagListItemPaint;
			AddTagItem.TextAlign = ContentAlignment.MiddleRight;

			// font size list
			SizeList = new Carbolist(CarbolistTheme.LightBlue, SizeListSampleButton, OnSizeListItemSelect)
			{
				CanDeselect = false,
				CanDragAndDrop = false,
			};

			foreach (int p in new int[]
			{
				9, 10, 12, 14, 16, 18, 20, 24, 32, 40, 48, 72
			})
			{
				SizeList.AddItem(p.ToString(), null, p, false);
			}

			// font color list
			ColorList = new Carbotilelist(default, ColorListSampleButton, OnColorListItemSelect)
			{
				CanSelect = false,
				CanDeselect = false,
				CanDragAndDrop = false,
			};

			foreach (Color p in new Color[]
			{
				Color.Tomato, Color.Gold, Color.LawnGreen, Color.DodgerBlue, Color.MediumPurple, Color.WhiteSmoke,
				Color.OrangeRed, Color.DarkOrange, Color.SeaGreen, Color.RoyalBlue, Color.Purple, Color.Gray
			})
			{
				ColorList.AddItem("", null, p, false).BackColor = p;
			}

			// att list
			tempTheme = CarbolistTheme.LightBlue;
			tempTheme.FirstItemBackColor = tempTheme.SecondItemBackColor = BackColor;
			//tempTheme.FirstItemBackColor = ControlPaint.Dark(tempTheme.FirstItemBackColor);
			//tempTheme.SecondItemBackColor = ControlPaint.Dark(tempTheme.SecondItemBackColor);

			AttachmentList = new Carbolist(tempTheme, AttachmentListSampleButton)
			{
				CanSelect = false,
				CanDeselect = false,
				CanDragAndDrop = false,
				AreItemsShowingMenuButtons = false,
			};

			AttachmentList.RegisterItemMenuButtons("Remove", DeleteButton.BackColor, DeleteButton.ForeColor);

			this.AddControl(TagList);
			this.AddControl(SizeList, true, true);
			this.AddControl(ColorList, true, true);
			this.AddControl(AttachmentList, true, true);

			TagList.OnItemMenuButtonClick = OnTagListItemMenuButtonClick;
			TagList.OnDefaultItemSelect = OnTagListDefaultItemSelect;

			AttachmentList.OnItemDoubleSelect = OnAttachmentListItemDoubleSelect;
			AttachmentList.OnItemMenuButtonClick = OnAttachmentListItemMenuButtonClick;

			// tooltips
			ToolTip = new ToolTip();
			ToolTip.SetToolTip(BoldButton, "Bold (Ctrl+B)");
			ToolTip.SetToolTip(ItalicButton, "Italic (Ctrl+I)");
			ToolTip.SetToolTip(UnderlineButton, "Underline (Ctrl+U)");
			ToolTip.SetToolTip(SizeButton, "Text Size");
			ToolTip.SetToolTip(ColorButton, "Text Color");
			ToolTip.SetToolTip(AlignLeftButton, "Align Left (Ctrl+Shift+L)");
			ToolTip.SetToolTip(AlignMiddleButton, "Align Middle (Ctrl+Shift+E)");
			ToolTip.SetToolTip(AlignRightButton, "Align Right (Ctrl+Shift+R)");
			ToolTip.SetToolTip(UndoButton, "Undo (Ctrl+Z)");
			ToolTip.SetToolTip(RedoButton, "Redo (Ctrl+Y)");

			// others

			pendingAddedAttachments = new List<PostAttachment>();
			pendingRemovedAttachments = new List<PostAttachment>();

			Editable = false;

			ContentTextBox.OnFilePasted = OnContentTextBoxFilePasted;

			darkControlButtonColor = Color.FromArgb(5, 52, 81);
			lightControlButonColor = ControlPaint.Light(darkControlButtonColor);
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		public Carbotilelist TagList;
		public Carbotilelist ColorList;
		public Carbolist SizeList;
		public Carbolist AttachmentList;
		public CarbolistItem CurrentListItem;
		public CarbolistItem AddTagItem;
		public ToolTip ToolTip;
		public Post CurrentPost;
		public Action<Post, bool> OnPostSaved;
		public Action<Post, bool> OnPostDeleted;

		public bool Editable
		{
			get => TagList.CanDragAndDrop;

			set
			{
				// only the author can edit the post
				TitleTextBox.Editable = ContentTextBox.Editable = (value
					&& CurrentPost != null
					&& Database.CurrentUser == CurrentPost.Author
				);

				DeleteButton.Visible = value && Database.CurrentUser == CurrentPost.Author;

				DeleteButton.Text = isNewPost ? "Discard" : "Delete";
				EditButton.Text = value ? (isNewPost ? "Publish" : "Save") : "Edit";

				TextControlPanel.Visible = ContentTextBox.Visible && ContentTextBox.Editable;

				TagList.AreItemsShowingMenuButtons = value;
				TagList.CanDragAndDrop = value;
				TagList.BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;

				AttachmentButton.Left = DeleteButton.Visible ? DeleteButton.Right + 5 : DeleteButton.Left;
				AttachmentDescriptionLabel.Left = AttachmentButton.Right + 6;

				AttachmentList.CanDragAndDrop = AttachmentList.AreItemsShowingMenuButtons = value && ContentTextBox.Editable;
				AttachmentList.BorderStyle = ContentTextBox.Editable ? BorderStyle.FixedSingle : BorderStyle.None;

				if (AttachmentList.CanDragAndDrop)
					AttachmentListLabel.Text = "Attachments:";
				else
					AttachmentListLabel.Text = "Attachments: (double click to open)";

				UpdateEditButtonStatus();

				if (ContentTextBox.Editable) // force refresh text controls
				{
					ContentTextBox.SelectionStart = 0;
					ContentTextBox.ClearUndo();

					UndoButton.Visible = RedoButton.Visible = false;

					OnContentTextBoxMouseUp(null, null);
				}

				OnPaint(null);

				Refresh();
			}
		}

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		protected List<PostAttachment> pendingAddedAttachments;
		protected List<PostAttachment> pendingRemovedAttachments;
		protected Color editingTextBoxColor;
		protected Color darkControlButtonColor;
		protected Color lightControlButonColor;
		protected string arrow = Global.SpecialString.DownArrow;
		protected bool isNewPost;
		protected bool haveAttachmentsChanged;

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		public void ShowPanel(CarbolistItem postListItem, bool isNew = false, bool forceShowContent = true)
		{
			Visible = true;

			CurrentListItem = postListItem;
			CurrentPost = postListItem.Tag as Post;

			AuthorImageBox.BackgroundImage = CurrentPost.Author.UserImage;

			TitleTextBox.Text = CurrentPost.Title;
			ContentTextBox.Rtf = CurrentPost.RtfContent;

			DescriptionLabel.Text = $"By {CurrentPost.Author.Name} on {CurrentPost.Date.ToString(@"dddd, MMMM d, yyyy a\t h:mm tt", CultureInfo.CreateSpecificCulture("en-US"))}";

			if (!isNew && CurrentPost.LatestDate.Ticks != CurrentPost.Date.Ticks)
				DescriptionLabel.Text += $"\n(Edited on {CurrentPost.LatestDate.ToString(@"dddd, MMMM d, yyyy a\t h:mm tt", CultureInfo.CreateSpecificCulture("en-US"))})";

			// tag list

			TagList.RemoveAllItems();
			TagList.AddItemsBy("Name", CurrentPost.Meeting.Tags);
			TagList.AddItemsBy("Name", CurrentPost.Tags);

			foreach (CarbolistItem p in TagList.Items)
			{
				DrawSpecialTagListItem(p);

				// hide delete buttons for those tags that are from the meeting
				if (CurrentPost.Meeting.Tags.Contains(p.Tag as Tag))
					p.RegisterMenuButton("");
			}

			// attachment list

			AttachmentDescriptionLabel.Text = "";

			AttachmentList.RemoveAllItems();

			if (forceShowContent)
			{
				AttachmentList.Visible = AttachmentListLabel.Visible = false;
				ContentTextBox.Visible = AttachmentDescriptionLabel.Visible = true;
			}

			if (CurrentPost.Attachments.Count == 0)
			{
				if (Database.CurrentUser == CurrentPost.Author)
				{
					AttachmentButton.Visible = true;

					if (ContentTextBox.Visible)
						AttachmentButton.Text = "Attach Files to Post";
				}
				else
				{
					AttachmentButton.Visible = false;
					if (ContentTextBox.Visible)
						AttachmentButton.Text = "";
				}
			}
			else
			{
				AttachmentButton.Visible = true;

				if (ContentTextBox.Visible)
					AttachmentButton.Text = "View Attachments";

				foreach (PostAttachment p in CurrentPost.Attachments)
					DrawSpecialAttachmentListItem(AttachmentList.AddItem(" " + p.Name, p.Icon, p, false));

				AttachmentDescriptionLabel.Text = "File".ToPlural(AttachmentList.Items.Count) + " Attached";
			}

			AddAttachmentButton.Visible = Database.CurrentUser == CurrentPost.Author;

			pendingAddedAttachments.Clear();
			pendingRemovedAttachments.Clear();

			isNewPost = isNew;

			BringToFront();

			haveAttachmentsChanged = false;

			if (isNew)
			{
				ContentTextBox.SetForeColor(Color.WhiteSmoke);
				ColorButton.ForeColor = Color.WhiteSmoke; // force it to be white, preventing it from being the watermark's color
			}
		}

		public void HidePanel()
		{
			Visible = false;

			if (Editable && CurrentPost != null)
			{
				if (ContainsTexts())
					SavePost();
				else
					DeletePost();
			}

			isNewPost = false;

			Editable = false;

			CurrentPost = null;
			CurrentListItem = null;
		}

		public void ResizePanel(int width, int height)
		{
			Width = width;
			Height = height;

			DeleteButton.Top = AttachmentButton.Top = EditButton.Top = height - 34;

			EditButton.Left = width - 94;

			AttachmentDescriptionLabel.Top = AttachmentButton.Top + 7;

			TitleTextBox.Width = width - 108;
			AuthorImageBox.Left = width - 74;
			DescriptionLabel.Width = TagList.Width = ContentTextBox.Width = width - 55;
			ContentTextBox.Height = height - 260;
			TextControlPanel.Top = height - 96;

			SizeList.Top = TextControlPanel.Top - SizeList.Height - 1;
			ColorList.Top = TextControlPanel.Bottom + 1;

			AttachmentList.Width = width - 65;
			AttachmentList.Height = height - 266;

			AddAttachmentButton.Left = width - 170;

			if (ContentTextBox.Editable)
				Invalidate();
		}

		#endregion

		#region ########################### PRIVATE METHODS #############################

		protected bool ContainsTexts()
		{
			return TitleTextBox.RawText.Trim() != "" || ContentTextBox.RawText.Trim() != "";
		}

		protected void UpdateEditButtonStatus()
		{
			EditButton.Enabled = !Editable || ContainsTexts();
		}

		protected void SavePost()
		{
			if (!isNewPost
				&& (TitleTextBox.RawText != CurrentPost.Title
					|| ContentTextBox.Rtf != CurrentPost.RtfContent
					|| haveAttachmentsChanged
				)
			)
			{
				CurrentPost.LatestDate = DateTime.Now;
			}

			if (TitleTextBox.RawText == "")
				CurrentPost.Title = "Untitled Post";
			else
				CurrentPost.Title = TitleTextBox.RawText;

			if (ContentTextBox.RawText == "")
				ContentTextBox.Text = "(No content)";

			CurrentPost.RtfContent = ContentTextBox.Rtf;

			CurrentPost.RemoveAllTags();
			// remove those tags from parent meeting before saving
			CurrentPost.AddTags(TagList.Items.Select(x => x.Tag as Tag).Except(
				CurrentPost.Meeting.Tags
			));

			CurrentPost.RemoveAllAttachments();
			CurrentPost.AddAttachments(AttachmentList.Items.Select(x => x.Tag as PostAttachment));

			if (pendingRemovedAttachments.Count > 0)
				pendingRemovedAttachments.ForEach(x => FileManager.DeletePostAttachment(CurrentPost, x));

			OnPostSaved?.Invoke(CurrentPost, isNewPost);

			haveAttachmentsChanged = false;
		}

		protected void DeletePost()
		{
			if (CurrentListItem != null)
			{
				CurrentListItem.ParentList.RemoveItem(CurrentListItem);

				OnPostDeleted?.Invoke(CurrentPost, isNewPost);
			}

			Visible = false;
		}

		protected void DrawSpecialTagListItem(CarbolistItem item)
		{
			item.Paint += OnTagListItemPaint;
		}

		protected void DrawSpecialAttachmentListItem(CarbolistItem item)
		{
			item.Paint += OnAttachmentListItemPaint;
		}

		protected void AddTag(string tagText)
		{
			AddTagItem.Enabled = true;

			AddTagTextBox.KeyDown -= OnAddTagTextBoxKeyDown;
			AddTagTextBox.TextChanged -= OnAddTagTextBoxTextChanged;
			AddTagTextBox.Leave -= OnAddTagTextBoxLeave;

			AddTagTextBox.Visible = false;

			AddTagItem.Text = "Add Tag";
			AddTagItem.AutoSetWidth();
			TagList.RefreshItems();

			if (AddTagTextBox.RawText == "")
				return;

			if (CurrentPost.Tags.Any(x => x.Name == AddTagTextBox.RawText)
				|| CurrentPost.Meeting.Tags.Any(x => x.Name == AddTagTextBox.RawText))
			{
				MessageBox.Show(
					$"Tag \"{AddTagTextBox.Text}\" already exists for this post.",
					"Existing Tag",
					MessageBoxButtons.OK,
					MessageBoxIcon.Asterisk
				);

				return;
			}

			Tag tag = new Tag(AddTagTextBox.RawText);

			DrawSpecialTagListItem(TagList.AddItem(tag.Name, null, tag));

			if (!Editable)
			{
				CurrentPost.AddTag(tag);
				Database.UpdatePost(CurrentPost);
			}
		}

		protected void AttachFileByDialog()
		{
			if (AttachFileDialog.ShowDialog() != DialogResult.OK)
				return;

			if (ContentTextBox.Visible)
			{
				AttachmentList.Visible = AttachmentListLabel.Visible = true;
				ContentTextBox.Visible = TextControlPanel.Visible = AttachmentDescriptionLabel.Visible = false;
			}

			AttachmentButton.Text = "View Post Content";

			if (isNewPost)
			{
				for (int i = 0, l = AttachFileDialog.FileNames.Length; i < l; i++)
				{
					string fileName = AttachFileDialog.FileNames[i];
					string safeName = AttachFileDialog.SafeFileNames[i];

					PostAttachment temp = new PostAttachment(
						AttachFileDialog.FileNames[i],
						Icon.ExtractAssociatedIcon(fileName).ToBitmap(),
						new FileInfo(fileName).Length
					);

					DrawSpecialAttachmentListItem(
						AttachmentList.AddItem(
							" " + AttachFileDialog.SafeFileNames[i],
							temp.Icon,
							temp
						)
					);
				}
			}
			else
			{
				foreach (PostAttachment p in FileManager.CreatePostAttachments(CurrentPost, AttachFileDialog.FileNames))
				{
					DrawSpecialAttachmentListItem(
						AttachmentList.AddItem(" " + p.Name, p.Icon, CurrentPost.AddAttachment(p))
					);

					pendingAddedAttachments.Add(p);
				}
			}

			AttachmentDescriptionLabel.Text = "File".ToPlural(AttachmentList.Items.Count) + " Attached";

			Invalidate(); // clears the lines around content textbox if needed to

			if (!Editable)
			{
				Database.UpdatePost(CurrentPost);

				ShowPanel(CurrentListItem, false, false);
			}

			haveAttachmentsChanged = true;
		}

		#endregion

		#region ############################### EVENTS ##################################

		#region *************** HOTKEYS ***************

		override protected bool ProcessCmdKey(ref Message message, Keys keys)
		{
			if (!Visible)
				return false;

			if (keys == (Keys.Control | Keys.Oemtilde)) // Ctrl+`
			{
				/// ////////////////////////////// ///
				///          TESTING AREA          ///
				/// ////////////////////////////// ///

				//tra.ce(Encoding.Unicode.GetBytes(ContentTextBox.Rtf));
				//tra.ce(ContentTextBox.Rtf);
				//tra.ce(ContentTextBox.SelectionType);
				//tra.ce(tra.ceSettings.FormatStrings, ContentTextBox.Rtf);
				//tra.ce(ContentTextBox.SelectionColor.ToString());

				return true;
			}

			if (ContentTextBox.Editable && ContentTextBox.Visible)
			{
				switch (keys)
				{
					case Keys.Control | Keys.B:
						OnBoldButtonClick(null, null);
						return true;

					case Keys.Control | Keys.I:
						OnItalicButtonClick(null, null);
						return true;

					case Keys.Control | Keys.U:
						OnUnderlineButtonClick(null, null);
						return true;

					case Keys.Control | Keys.Shift | Keys.L:
						OnAlignButtonClick(AlignLeftButton, null);
						return true;

					case Keys.Control | Keys.Shift | Keys.E:
						OnAlignButtonClick(AlignMiddleButton, null);
						return true;

					case Keys.Control | Keys.Shift | Keys.R:
						OnAlignButtonClick(AlignRightButton, null);
						return true;
				}
			}

			return base.ProcessCmdKey(ref message, keys);
		}

		#endregion

		#region *************** NORMAL UI ***************

		protected void OnAuthorImageBoxClick(object sender, EventArgs e)
		{
			new BasicUserInfoForm(CurrentPost.Author).ShowForm(ParentForm);
		}

		protected void OnTitleTextBoxTextChanged(object sender, EventArgs e)
		{
			if (!Editable)
				return;

			if (CurrentListItem == null)
				return;

			CurrentListItem.Text = TitleTextBox.RawText;

			UpdateEditButtonStatus();
		}

		protected void OnContentTextBoxTextChanged(object sender, EventArgs e)
		{
			UpdateEditButtonStatus();

			UndoButton.Visible = ContentTextBox.CanUndo;
			RedoButton.Visible = ContentTextBox.CanRedo;
		}

		protected void OnEditButtonClick(object sender, EventArgs e)
		{
			if (Editable)
			{
				SavePost();

				ShowPanel(CurrentListItem, false, false); // update panel display
			}

			Editable = !Editable;
		}

		protected void OnDeleteButtonClick(object sender, EventArgs e)
		{
			if (isNewPost)
			{
				TitleTextBox.Text = "";
				ContentTextBox.Text = "";

				HidePanel();

				return;
			}

			if (MessageBox.Show(
				$"Delete post \"{CurrentPost.Title}\"?",
				"Delete Post",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				DeletePost();
			}
		}

		protected void OnTagListItemPaint(object sender, PaintEventArgs e)
		{
			if ((sender as CarbolistItem).IsDragging)
				return;

			SolidBrush brush = new SolidBrush(TagList.BackColor);

			e.Graphics.FillPolygon(brush, new Point[]
			{
				new Point(0, 0),
				new Point(7, 0),
				new Point(0, 13),
			});

			e.Graphics.FillPolygon(brush, new Point[]
			{
				new Point(0, 13),
				new Point(7, 26),
				new Point(0, 26),
			});
		}

		protected void OnTagListItemSelect(CarbolistItem sender)
		{
			(ParentForm as Form1).Search($"Tag: {(sender.Tag as Tag).Name}", true);
		}

		protected void OnTagListItemMenuButtonClick(CarbolistItem sender)
		{
			if (MessageBox.Show(
				$"Remove Tag \"{(sender.Tag as Tag).Name}\" from this post?",
				"Remove Post Tag",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation
				) == DialogResult.No)
			{
				return;
			}

			TagList.RemoveItem(sender);
		}

		protected void OnTagListDefaultItemSelect(CarbolistItem sender)
		{
			AddTagItem.Enabled = false;

			AddTagItem.Text = "".PadRight(12);
			AddTagItem.AutoSetWidth();
			TagList.RefreshItems();

			AddTagTextBox.BringToFront();

			AddTagTextBox.Visible = true;
			AddTagTextBox.Text = "";
			AddTagTextBox.Width = AddTagItem.Width - 12;

			// set the location of the textbox to the same as the "new" button's

			Point location = TagList.DefaultItems[0].Location;
			location.X += TagList.ItemContainer.Left + TagList.Left + 12;
			location.Y += TagList.ItemContainer.Top + TagList.Top + 5;

			AddTagTextBox.Location = location;

			AddTagTextBox.Select();
			AddTagTextBox.Focus();

			AddTagTextBox.KeyDown += OnAddTagTextBoxKeyDown;
			AddTagTextBox.TextChanged += OnAddTagTextBoxTextChanged;
			AddTagTextBox.Leave += OnAddTagTextBoxLeave;
		}

		protected void OnAddTagTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
			{
				if (AddTagTextBox.RawText == "")
					return;

				e.SuppressKeyPress = e.Handled = true;

				AddTag(AddTagTextBox.Text);
			}
			else if (e.KeyData == Keys.Escape)
			{
				e.SuppressKeyPress = e.Handled = true;

				AddTagTextBox.Text = "";

				AddTag("");
			}
		}

		protected void OnAddTagTextBoxTextChanged(object sender, EventArgs e)
		{
			AddTagItem.Text = "   " + AddTagTextBox.Text.PadRight(9);
			AddTagItem.AutoSetWidth();
			TagList.RefreshItems();

			AddTagTextBox.Width = AddTagItem.Width - 12;

			Point location = TagList.DefaultItems[0].Location;
			location.X += TagList.ItemContainer.Left + TagList.Left + 12;
			location.Y += TagList.ItemContainer.Top + TagList.Top + 5;

			AddTagTextBox.Location = location;
		}

		protected void OnAddTagTextBoxLeave(object sender, EventArgs e)
		{
			AddTag(AddTagTextBox.Text);
		}

		#endregion

		#region *************** CONTENT TEXTBOX ***************

		override protected void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// draw contentTextBox border
			if (ContentTextBox.Editable && ContentTextBox.Visible)
			{
				(e?.Graphics ?? CreateGraphics()).DrawRectangle(
					Pens.DimGray,
					ContentTextBox.Left - 1,
					ContentTextBox.Top - 1,
					ContentTextBox.Width + 1,
					ContentTextBox.Height + 1
				);
			}
		}

		protected void OnContentTextBoxMouseUp(object sender, MouseEventArgs e)
		{
			if (CurrentPost == null || !Editable)
				return;

			if (ContentTextBox.SelectionFont != null)
			{
				BoldButton.BackColor = ContentTextBox.SelectionFont.Bold ?
				  lightControlButonColor : darkControlButtonColor;
				ItalicButton.BackColor = ContentTextBox.SelectionFont.Italic ?
					lightControlButonColor : darkControlButtonColor;
				UnderlineButton.BackColor = ContentTextBox.SelectionFont.Underline ?
					lightControlButonColor : darkControlButtonColor;
				SizeButton.Text = $"{((int)ContentTextBox.SelectionFont.Size).Replace(13, "   ")} {arrow}";
			}

			if (ContentTextBox.SelectionColor != ContentTextBox.WatermarkColor)
				ColorButton.ForeColor = ContentTextBox.SelectionColor;

			switch (ContentTextBox.SelectionAlignment)
			{
				case HorizontalAlignment.Left:
					AlignLeftButton.BackColor = lightControlButonColor;
					AlignMiddleButton.BackColor = AlignRightButton.BackColor = darkControlButtonColor;
					break;

				case HorizontalAlignment.Center:
					AlignMiddleButton.BackColor = lightControlButonColor;
					AlignLeftButton.BackColor = AlignRightButton.BackColor = darkControlButtonColor;
					break;

				case HorizontalAlignment.Right:
					AlignRightButton.BackColor = lightControlButonColor;
					AlignLeftButton.BackColor = AlignMiddleButton.BackColor = darkControlButtonColor;
					break;
			}
		}

		protected void OnContentTextBoxKeyUp(object sender, KeyEventArgs e)
		{
			OnContentTextBoxMouseUp(null, null);
		}

		protected void OnBoldButtonClick(object sender, EventArgs e)
		{
			FlipFontStyle(BoldButton, FontStyle.Bold);
		}

		protected void FlipFontStyle(Carbobutton controlButton, FontStyle style)
		{
			Font temp = new Font(ContentTextBox.SelectionFont.FontFamily, ContentTextBox.SelectionFont.Size, ContentTextBox.SelectionFont.Style ^ style);

			if (ContentTextBox.SelectionLength == 0)
			{
				string tempRtf = ContentTextBox.Rtf;
				int tempSelectionStart = ContentTextBox.SelectionStart;

				ContentTextBox.Font = temp;
				ContentTextBox.Rtf = tempRtf;
				ContentTextBox.SelectionStart = tempSelectionStart;
			}

			ContentTextBox.SelectionFont = temp; // flips style

			controlButton.BackColor = controlButton.BackColor == lightControlButonColor ?
				darkControlButtonColor : lightControlButonColor;

			ContentTextBox.Select();
		}

		protected void OnItalicButtonClick(object sender, EventArgs e)
		{
			FlipFontStyle(ItalicButton, FontStyle.Italic);
		}

		protected void OnUnderlineButtonClick(object sender, EventArgs e)
		{
			FlipFontStyle(UnderlineButton, FontStyle.Underline);
		}

		protected void OnSizeButtonClick(object sender, EventArgs e)
		{
			SizeList.Visible = !SizeList.Visible;

			if (!SizeList.Visible)
			{
				ContentTextBox.Select();

				return;
			}

			SizeList.SelectWhere(x => (int)x.Tag == (int)ContentTextBox.SelectionFont.Size);

			SizeButton.Select();
			SizeButton.Leave += OnSizeButtonLeave;
		}

		protected void OnSizeButtonLeave(object sender, EventArgs e)
		{
			if (SizeList.Focused
				|| SizeList.Items.Any(x => x.Focused)
				|| SizeList.ScrollBar.Slider.Focused)
			{
				return;
			}

			SizeButton.Leave -= OnSizeButtonLeave;
			SizeList.Visible = false;
		}

		protected void OnSizeListItemSelect(CarbolistItem sender)
		{
			if (!sender.Focused) // prevents this event to fire immediately after the size button is clicked.
				return;

			Font temp = new Font(ContentTextBox.SelectionFont.FontFamily, (int)sender.Tag, ContentTextBox.SelectionFont.Style);

			if (ContentTextBox.SelectionLength == 0)
			{
				string tempRtf = ContentTextBox.Rtf;
				int tempSelectionStart = ContentTextBox.SelectionStart;

				ContentTextBox.Font = temp;
				ContentTextBox.Rtf = tempRtf;
				ContentTextBox.SelectionStart = tempSelectionStart;
			}

			ContentTextBox.SelectionFont = temp;

			SizeButton.Text = $"{sender.Tag} {arrow}";
			SizeList.Visible = false;

			ContentTextBox.Select();
		}

		protected void OnColorButtonClick(object sender, EventArgs e)
		{
			ColorList.Visible = !ColorList.Visible;

			if (!ColorList.Visible)
			{
				ContentTextBox.Select();

				return;
			}

			ColorButton.Select();
			ColorButton.Leave += OnColorButtonLeave;
		}

		protected void OnColorButtonLeave(object sender, EventArgs e)
		{
			if (ColorList.Focused
				|| ColorList.Items.Any(x => x.Focused)
				|| ColorList.ScrollBar.Slider.Focused)
			{
				return;
			}

			ColorButton.Leave -= OnColorButtonLeave;
			ColorList.Visible = false;
		}

		protected void OnColorListItemSelect(CarbolistItem sender)
		{
			if (!sender.Focused) // prevents this event to fire immediately after the size button is clicked.
				return;

			if (ContentTextBox.SelectionLength == 0)
			{
				string tempRtf = ContentTextBox.Rtf;
				int tempSelectionStart = ContentTextBox.SelectionStart;

				ContentTextBox.SetForeColor((Color)sender.Tag);
				ContentTextBox.Rtf = tempRtf;
				ContentTextBox.SelectionStart = tempSelectionStart;
			}

			ContentTextBox.SelectionColor = ColorButton.ForeColor = (Color)sender.Tag;

			ColorList.Visible = false;

			ContentTextBox.Select();
			ContentTextBox.SelectionStart = ContentTextBox.SelectionStart + ContentTextBox.SelectionLength;
			ContentTextBox.SelectionLength = 0;
		}

		protected void OnAlignButtonClick(object sender, EventArgs e)
		{
			Button targetAlignButton = sender as Button;

			ContentTextBox.SelectionAlignment = (HorizontalAlignment)int.Parse((string)targetAlignButton.Tag);

			if (sender != AlignLeftButton)
				AlignLeftButton.BackColor = darkControlButtonColor;

			if (sender != AlignMiddleButton)
				AlignMiddleButton.BackColor = darkControlButtonColor;

			if (sender != AlignRightButton)
				AlignRightButton.BackColor = darkControlButtonColor;

			targetAlignButton.BackColor = lightControlButonColor;

			ContentTextBox.Select();
		}

		protected void OnUndoButtonClick(object sender, EventArgs e)
		{
			ContentTextBox.Undo();

			UndoButton.Visible = ContentTextBox.CanUndo;
			RedoButton.Visible = ContentTextBox.CanRedo;

			OnContentTextBoxMouseUp(null, null); // updates buttons

			ContentTextBox.Select();
		}

		protected void OnRedoButtonClick(object sender, EventArgs e)
		{
			ContentTextBox.Redo();

			UndoButton.Visible = ContentTextBox.CanUndo;
			RedoButton.Visible = ContentTextBox.CanRedo;

			OnContentTextBoxMouseUp(null, null); // updates buttons

			ContentTextBox.Select();
		}

		protected void OnContentTextBoxFilePasted(StringCollection urls)
		{
			MessageBox.Show(
				$"You're pasting some files! Unfortunately your dear programmer just forgot to develop an \"attachment\" function to this post! :(\n\nPlease call him and tell him how you love him more than everyone else does, and then he'll probably develop it for you. Thanks!\n\nFiles caught:\n\n{string.Join("\n\n", urls.Cast<string>())}",
				"Whoops!",
				MessageBoxButtons.OK,
				MessageBoxIcon.Asterisk
			);
		}

		#endregion

		#region *************** FILE ATTS ***************

		protected void OnAttachmentButtonClick(object sender, EventArgs e)
		{
			if (AttachmentList.Items.Count == 0)
			{
				AttachFileByDialog();

				return;
			}

			AttachmentList.Visible = AttachmentListLabel.Visible = !AttachmentList.Visible;
			ContentTextBox.Visible = AttachmentDescriptionLabel.Visible = !AttachmentList.Visible;
			TextControlPanel.Visible = ContentTextBox.Visible && ContentTextBox.Editable;

			Invalidate(); // forced it to clear the lines around the content textbox if needed to

			if (AttachmentList.Visible)
				AttachmentButton.Text = "View Post Content";
			else
				AttachmentButton.Text = "View Attachments";
		}

		protected void OnAttachmentListItemPaint(object sender, PaintEventArgs e)
		{
			CarbolistItem item = sender as CarbolistItem;
			string text = (item.Tag as PostAttachment).GetSizeAsString();
			Size size = TextRenderer.MeasureText(text, AttachmentListLabel.Font);

			SolidBrush brush = new SolidBrush(Color.Gray);

			e.Graphics.DrawString(
				text,
				AttachmentListLabel.Font,
				brush,
				item.Width - size.Width - 3,
				item.Height - size.Height - 6
			);
		}

		protected void OnAttachmentListItemDoubleSelect(CarbolistItem sender)
		{
			if (AttachmentList.CanDragAndDrop)
				return;

			Process.Start(Path.GetFullPath((sender.Tag as PostAttachment).Url));
		}

		protected void OnAttachmentListItemMenuButtonClick(CarbolistItem sender)
		{
			if (MessageBox.Show(
				$"Remove attachment \"{(sender.Tag as PostAttachment).Name}\" from this post?",
				"Remove Post Attachment",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation
				) == DialogResult.No)
			{
				return;
			}

			AttachmentList.RemoveItem(sender);

			if (!isNewPost)
				pendingRemovedAttachments.Add(sender.Tag as PostAttachment);

			haveAttachmentsChanged = true;

			if (AttachmentList.Items.Count == 0)
			{
				AttachmentList.Visible = AttachmentListLabel.Visible = false;
				ContentTextBox.Visible = TextControlPanel.Visible = AttachmentDescriptionLabel.Visible = true;
				AttachmentButton.Text = "Attach Files to Post";
				AttachmentDescriptionLabel.Text = "";
			}
		}

		protected void OnAddAttachmentButtonClick(object sender, EventArgs e)
		{
			AttachFileByDialog();
		}

		#endregion

		#endregion

	}

}
