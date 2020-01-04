using Carbolibrary;
using CarboUiComponent;
using Carboutil;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon
{

	public partial class SearchPanel : UserControl
	{

		#region ############################# CONSTRUCTOR ###############################

		public SearchPanel()
		{
			InitializeComponent();

			#region *************** INSTANCE INIT ***************

			// panel

			Panel = new UserControl()
			{
				BackColor = BackColor,
				Width = Width,
			};

			this.AddControl(Panel);

			// move all labels and lists onto scrollable panel

			GroupListLabel.Parent = MeetingListLabel.Parent = PostListLabel.Parent =
				GroupNoResultLabel.Parent = MeetingNoResultLabel.Parent = PostNoResultLabel.Parent = Panel;

			// margin and padding

			margin = GroupListLabel.Top;
			padding = GroupListSampleButton.Top - GroupListLabel.Bottom;

			// carbolists

			GroupList = new Carbolist(CarbolistTheme.LightBlue, GroupListSampleButton, OnGroupListItemSelect);
			MeetingList = new Carbolist(CarbolistTheme.LightBlue, MeetingListSampleButton, OnMeetingListItemSelect);
			PostList = new Carbolist(CarbolistTheme.LightBlue, PostListSampleButton, OnPostListItemSelect);

			GroupList.CanSelect = GroupList.CanDeselect = GroupList.CanDragAndDrop =
				MeetingList.CanSelect = MeetingList.CanDeselect = MeetingList.CanDragAndDrop =
				PostList.CanSelect = PostList.CanDeselect = PostList.CanDragAndDrop = false;

			Panel.AddControl(GroupList);
			Panel.AddControl(MeetingList);
			Panel.AddControl(PostList);

			// panel height init: top & bottom margins, three labels and lists of paddings

			Panel.Height = margin * 2 + padding * 5 + GroupListLabel.Height * 3;

			// scrollbar

			ScrollBar = new Carboscrollbar(OnScrollBarDragged, ControlPaint.Light(BackColor, .70f), ControlPaint.Light(BackColor, .20f), 8)
			{
				Location = new Point(Width - 20, margin),
				Height = Height - margin * 2,
				Capacity = Height,
				Total = Panel.Height,
			};

			this.AddControl(ScrollBar);

			// bring labels to front

			GroupListLabel.BringToFront();
			MeetingListLabel.BringToFront();
			PostListLabel.BringToFront();

			#endregion

			dotWidth = TextRenderer.MeasureText("...", ListItemDescriptionSampleLabel.Font).Width;
			relatedTextDict = new Dictionary<CarbolistItem, RelatedText>();
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		public Carbolist GroupList;
		public Carbolist MeetingList;
		public Carbolist PostList;
		public Carboscrollbar ScrollBar;
		public UserControl Panel;

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		protected Dictionary<CarbolistItem, RelatedText> relatedTextDict;
		protected string keyword;
		protected int margin;
		protected int padding;
		protected int dotWidth;

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		public void ClearResults()
		{
			DescriptionLabel.Text = "Searching...";
			DescriptionLabel.Visible = true;

			Panel.Visible = ScrollBar.Visible = false;
		}

		public void ShowResults(List<Group> groups, List<Meeting> meetings, List<Post> posts, string keyword)
		{
			DescriptionLabel.Visible = false;

			relatedTextDict.Clear();

			this.keyword = keyword;

			//tra.ce("Search Results:");
			//tra.ce(tra.ceSettings.ForceShowDetails, "Groups", groups.Select(x => x.Name));
			//tra.ce(tra.ceSettings.ForceShowDetails, "Meetings", meetings.Select(x => x.Name));
			//tra.ce(tra.ceSettings.ForceShowDetails, "Posts", posts.Select(x => x.Title));

			Panel.Visible = true;

			GroupList.RemoveAllItems();
			MeetingList.RemoveAllItems();
			PostList.RemoveAllItems();

			if (groups != null)
			{
				GroupListLabel.Visible = true;
				GroupNoResultLabel.Visible = (groups.Count == 0);

				if (groups.Count > 0)
				{
					GroupList.AddItemsBy("Name", groups).ForEach(x => DrawSpecialGroupListItem(x));
					GroupList.ApplyAutoSize();
				}
				else
				{
					GroupList.Height = 0;
				}

				MeetingListLabel.Top = MeetingNoResultLabel.Top = GroupList.Bottom + padding;
			}
			else
			{
				GroupListLabel.Visible = GroupNoResultLabel.Visible = false;

				MeetingListLabel.Top = MeetingNoResultLabel.Top = GroupListLabel.Top;
			}

			MeetingNoResultLabel.Visible = (meetings.Count == 0);

			MeetingList.Top = MeetingListLabel.Bottom + padding;

			if (meetings.Count > 0)
			{
				MeetingList.AddItemsBy("Name", meetings).ForEach(x => DrawSpecialMeetingListItem(x));
				MeetingList.ApplyAutoSize();
			}
			else
			{
				MeetingList.Height = 0;
			}
			
			PostListLabel.Top = PostNoResultLabel.Top = MeetingList.Bottom + padding;

			PostList.Top = PostListLabel.Bottom + padding;
			PostNoResultLabel.Visible = (posts.Count == 0);

			// hide everything if no any result was found
			if ((groups == null || GroupNoResultLabel.Visible) && MeetingNoResultLabel.Visible && PostNoResultLabel.Visible)
			{
				ScrollBar.Total = 0;
				Panel.Visible = ScrollBar.Visible = false;

				DescriptionLabel.Text = "No results found.";
				DescriptionLabel.Visible = true;

				return;
			}

			if (posts.Count > 0)
			{
				PostList.AddItemsBy("Title", posts).ForEach(x => DrawSpecialPostListItem(x));
				PostList.ApplyAutoSize();
			}
			else
			{
				PostList.Height = 0;
			}

			if (groups != null)
			{
				ScrollBar.Total = Panel.Height = margin * 2 + padding * 5 + GroupListLabel.Height * 3
					+ GroupList.Height + MeetingList.Height + PostList.Height;
			}
			else
			{
				ScrollBar.Total = Panel.Height = margin * 2 + padding * 3 + GroupListLabel.Height * 3
					+ MeetingList.Height + PostList.Height;
			}

			ScrollBar.Value = 0; // reset scrollbar location
			ScrollBar.Visible = (ScrollBar.Total > ScrollBar.Capacity);

			UpdatePanelLocation();
		}

		public void ResizePanel(int height)
		{
			Height = height;

			ScrollBar.Height = height - margin * 2;
			ScrollBar.Capacity = Height;
			ScrollBar.Visible = (ScrollBar.Total > ScrollBar.Capacity);

			UpdatePanelLocation();
		}

		#endregion

		#region ########################### PRIVATE METHODS #############################

		protected void UpdatePanelLocation()
		{
			Panel.Top = -ScrollBar.Value;
		}

		protected void DrawSpecialGroupListItem(CarbolistItem item)
		{
			relatedTextDict[item] = GetRelatedText((item.Tag as Group).Description);

			item.Paint += OnGroupListItemPaint;
		}

		protected void DrawSpecialMeetingListItem(CarbolistItem item)
		{
			relatedTextDict[item] = GetRelatedText((item.Tag as Meeting).Description);

			item.Paint += OnMeetingListItemPaint;
		}

		protected void DrawSpecialPostListItem(CarbolistItem item)
		{
			relatedTextDict[item] = GetRelatedText((item.Tag as Post).RawContent);

			item.Paint += OnPostListItemPaint;
		}

		protected RelatedText GetRelatedText(string text)
		{
			// text that contains spaces as the only white-space character
			string rawText = text.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ");

			List<string> words = rawText.Split(' ').ToList();
			int index = text.ToWordList().IndexOf(keyword.ToWordList().ToArray());
			// the index where the keyword is located in the word list

			int keywordCount = keyword.Count(x => x == ' ') + 1; // how many words the keyword has

			int widthLimit = GroupList.Width - 15;
			Font font = ListItemDescriptionSampleLabel.Font;

			int l = words.Count;

			// when keyword doesn't exist in the text, 
			// just show the whole text from beginning as much as it can
			// and use "..." to represent the rest

			if (index == -1)
			{
				for (int i = 0; i < l; i++)
				{
					// find the cut-point of words where it starts to go beyond the button width
					if (TextRenderer.MeasureText(string.Join(" ", words.Take(i)), font).Width + dotWidth > widthLimit)
					{
						// when even the first word is too long
						if (i == 0)
						{
							// find the cut-point of characters
							for (int j = 0, m = words[0].Length; j < m; j++)
							{
								// "Supercalifragilistic..."
								if (TextRenderer.MeasureText(words[0].Substring(0, j), font).Width + dotWidth > widthLimit)
									return new RelatedText($"{words[0].Substring(0, j - 1)}...");
							}

							// no cut-point which means the entire first word can be displayed
							// "Supercalifragilisticexpialidocious..."
							return new RelatedText($"{words[0]}...");
						}

						// display the text before the cut-point
						// "These words can be displayed..."
						return new RelatedText($"{string.Join(" ", words.Take(i - 1))}...");
					}
				}

				// display every word when no cut-point is found
				return new RelatedText(rawText);
			}

			// when keyword does exist in the text,
			// display the most number of words, centered at the keyword,
			// and use "..." to represent the rest on each side

			int left = index, right = index; // words between index "left" and "right" are displayed

			// loop until cut-points of both sides are found,
			// or the entire string can be fit (no cut-points)
			while (left >= 0 || right < l)
			{
				// the "count" argument when using GetRange(start, count)
				int count = Math.Min(right, l - 1) - Math.Max(left, 0) + 1;

				// when the beginning of the string is not yet reached
				if (count >= keywordCount && left >= 0)
				{
					// find the first character on the left that's off-screen and can't be displayed
					if (TextRenderer.MeasureText(string.Join(" ", words.GetRange(left, count)), font).Width + dotWidth * 2 > widthLimit)
					{
						// when even the first word is too long
						if (count == 1)
						{
							for (int j = 0, m = words[index].Length; j < m; j++)
							{
								// "...Superfragilistic..."
								if (TextRenderer.MeasureText(words[index].Substring(0, j), font).Width + dotWidth * 2 > widthLimit)
									return new RelatedText("...".Only(left > 0), words[index].Substring(0, j - 1) + "...".Only(right < l - 1));
							}

							// no cut-point for the first word
							// "...Superfragilisticexpialidocious..."
							return new RelatedText("...".Only(left > 0), words[index], "...".Only(right < l - 1));
						}

						// display everything up to the cut-point
						// "...words around the keyword that can be displayed..."
						return new RelatedText(
							"..." + string.Join(" ", words.GetRange(left + 1, Math.Max(index - left - 1, 0))) + " ",
							string.Join(" ", words.GetRange(index, Math.Min(keywordCount, count))),
							" " + string.Join(" ", words.GetRange(index + Math.Min(keywordCount, count), Math.Max(Math.Min(right, l - 1) - index - keywordCount, 0))) + "...".Only(right < l - 1)
						);
					}

					left--; // move to the left for one word
					count++;
				}

				// break when both sides have reached the edge
				if (left < 0 && right >= l)
					break;

				// when the end of the string is not yet reached
				if (right < l)
				{
					// find the first character on the right that's off-screen
					if (TextRenderer.MeasureText(string.Join(" ", words.GetRange(Math.Max(left, 0), Math.Min(count, l - Math.Max(left, 0)))), font).Width + dotWidth * 2 > widthLimit)
					{
						return new RelatedText(
							"...".Only(left > 0) + string.Join(" ", words.GetRange(Math.Max(left, 0), Math.Max(index - Math.Max(left, 0), 0))) + " ",
							string.Join(" ", words.GetRange(index, Math.Min(keywordCount, count))),
							string.Join(" ", words.GetRange(index + Math.Min(keywordCount, count), Math.Max(right - index - keywordCount, 0))) + "..."
						);
					}

					right++; // move to the right for one word
				}
			}

			// when no cut-point was found, display the entire text
			// "This has neven been cut!"
			return new RelatedText(
				string.Join(" ", words.Take(index)) + " ",
				string.Join(" ", words.GetRange(index, keywordCount)),
				" " + string.Join(" ", words.GetRange(index + keywordCount, l - index - keywordCount))
			);
		}

		protected void DrawHighlightedDescription(RelatedText texts, Graphics graphics, Font font)
		{
			float currentX = 5;
			float currentY = 50;

			if (texts.TextBefore != "")
			{
				graphics.DrawString(texts.TextBefore, font, Brushes.DarkGray, currentX, currentY);
				currentX += CarbotextRenderer.MeasureText(texts.TextBefore, font);
			}

			if (texts.HighlightedText != "")
			{
				graphics.DrawString(texts.HighlightedText, font, Brushes.Aqua, currentX, currentY);
				currentX += CarbotextRenderer.MeasureText(texts.HighlightedText, font);
			}

			if (texts.TextAfter != "")
				graphics.DrawString(texts.TextAfter, font, Brushes.DarkGray, currentX, currentY);
		}

		#endregion

		#region ############################### EVENTS ##################################

		override protected void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);

			ScrollBar.Value -= Math.Sign(e.Delta) * SystemInformation.MouseWheelScrollLines * 40;

			UpdatePanelLocation();
		}

		protected void OnScrollBarDragged(int value)
		{
			UpdatePanelLocation();
		}

		protected void OnGroupListItemPaint(object sender, PaintEventArgs e)
		{
			Group group = (sender as CarbolistItem).Tag as Group;

			e.Graphics.DrawString(
				$"@{group.Code}",
				ListItemDescriptionSampleLabel.Font,
				Brushes.LightGray,
				5, 28
			);

			DrawHighlightedDescription(relatedTextDict[sender as CarbolistItem], e.Graphics, ListItemDescriptionSampleLabel.Font);
		}

		protected void OnMeetingListItemPaint(object sender, PaintEventArgs e)
		{
			Meeting meeting = (sender as CarbolistItem).Tag as Meeting;

			e.Graphics.DrawString(
				$"In group {meeting.Group.Name}",
				ListItemDescriptionSampleLabel.Font,
				Brushes.LightGray,
				5, 28
			);

			DrawHighlightedDescription(relatedTextDict[sender as CarbolistItem], e.Graphics, ListItemDescriptionSampleLabel.Font);
		}

		protected void OnPostListItemPaint(object sender, PaintEventArgs e)
		{
			Post post = (sender as CarbolistItem).Tag as Post;

			e.Graphics.DrawString(
				$"By {post.Author.Name} in meeting {post.Meeting.Name}",
				ListItemDescriptionSampleLabel.Font,
				Brushes.LightGray,
				5, 28
			);

			DrawHighlightedDescription(relatedTextDict[sender as CarbolistItem], e.Graphics, ListItemDescriptionSampleLabel.Font);
		}

		protected void OnGroupListItemSelect(CarbolistItem sender)
		{
			(ParentForm as Form1).SelectSearchedGroup(sender.Tag as Group);
		}

		protected void OnMeetingListItemSelect(CarbolistItem sender)
		{
			(ParentForm as Form1).SelectSearchedMeeting(sender.Tag as Meeting);
		}

		protected void OnPostListItemSelect(CarbolistItem sender)
		{
			(ParentForm as Form1).SelectSeacrhedPost(sender.Tag as Post);
		}

		#endregion

		#region EXTENSIONS

		protected class RelatedText
		{

			public RelatedText(string before, string highlighted = "", string after = "")
			{
				TextBefore = before;
				HighlightedText = highlighted;
				TextAfter = after;
			}

			public string TextBefore;
			public string HighlightedText;
			public string TextAfter;

		}

		#endregion

	}

}
