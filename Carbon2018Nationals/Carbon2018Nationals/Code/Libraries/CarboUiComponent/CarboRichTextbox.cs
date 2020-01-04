using Carboutil;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CarboUiComponent
{

	/// <summary>
	/// An advanced textbox that can show a watermark when no text is input.
	/// </summary>
	public class CarboRichTextbox : RichTextBox
	{

		#region ############################# CONSTRUCTOR ###############################

		public CarboRichTextbox()
		{
			BorderStyleWhenEditing = BorderStyle.None;
			BackColorWhenEditing = Color.Transparent;
			WatermarkColor = Color.DimGray;
			TabSize = 4;

			foreColor = Color.White;

			AcceptsTab = true;

			// context menu items

			ContextMenu = new ContextMenu();
			contextMenuItemDict = new Dictionary<string, MenuItem>();

			foreach (string p in new string[] {
				"Undo", "-",
				"Cut", "Copy", "Paste", "Paste Raw Text", "Delete", "-",
				"Select All",
			})
			{
				if (p == "-")
				{
					ContextMenu.MenuItems.Add("-");
				}
				else
				{
					ContextMenu.MenuItems.Add(
						contextMenuItemDict[p] = new MenuItem(p, OnContextMenuItemClick)
					);
				}
			}

			// scrollbar

			ScrollBar = new Carboscrollbar(OnScrollBarDragged, null, null, 17, 8);

			// events

			BackColorChanged += OnBackColorChanged;
			ForeColorChanged += OnForeColorChanged;

			ContextMenu.Popup += OnContextMenuPopup;
		}

		// scrollbar init!!
		override protected void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);

			ScrollBar.Parent?.Controls.Remove(ScrollBar);

			if (isScrollBarVisible)
				Parent.AddControl(ScrollBar); // add the scrollbar to the parent

			OnLayout(null);
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		public Action<StringCollection> OnFilePasted;
		public Action<Image> OnImagePasted;
		public Action<Stream> OnAudioPasted;

		[DefaultValue(BorderStyle.None)]
		public BorderStyle BorderStyleWhenEditing { get; set; } = BorderStyle.None;

		[DefaultValue(typeof(Color), "Transparent")]
		public Color BackColorWhenEditing { get; set; } = Color.Transparent;

		[DefaultValue(typeof(Color), "DimGray")]
		public Color WatermarkColor { get; set; } = Color.DimGray;

		[DefaultValue(true)]
		public bool ImageSelectable { get; set; } = true;

		/// <summary>[Override] The text in this Carbotextbox.</summary>
		override public string Text
		{
			get => RawText;

			set
			{
				base.Text = value;

				if (!Focused)
				{
					if (base.Text == "")
						OnLeave(null);
					else if (Parent != null)
						OnEnter(null);
				}

				TabSize = tabSize;
			}
		}

		/// <summary>[Override] The text without watermark in this Carbotextbox.</summary>
		public string RawText
		{
			get
			{
				if (base.Text.Length >= 4 && base.Text.Substring(base.Text.Length - 4) == "  \t ")
					return "";

				return base.Text;
			}
		}

		/// <summary>[Override] The Rtf text of this CarboRichTextbox.</summary>
		new public string Rtf
		{
			get
			{
				if (RawText == "")
					return "";

				return base.Rtf;
			}

			set
			{
				base.Rtf = value;

				if (!Focused)
				{
					if (base.Text == "")
						OnLeave(null);
					else if (Parent != null)
						OnEnter(null);
				}
			}
		}

		/// <summary>A gray text that will show up when the Carbotextbox is empty and deselected.</summary>
		public string Watermark
		{
			get => rawWatermark;

			set
			{
				rawWatermark = value;
				watermark = value + "  \t ";

				// update waterprint display

				if (!Focused && ContainsOnlyWatermark)
				{
					base.Text = watermark;

					OnLeave(null);
				}
			}
		}

		[DefaultValue(4)]
		public int TabSize
		{
			get => tabSize;

			set
			{
				tabSize = value;

				const int setTabStopMessageCode = 0x00CB;

				SendMessage(Handle, setTabStopMessageCode, 1, new int[] {
					value * TextRenderer.MeasureText(" ", Font).Width / 4,
				});
			}
		}

		public bool ContainsOnlyWatermark
		{
			get => base.Text.Length >= 4 && base.Text.Substring(base.Text.Length - 4) == "  \t ";
		}

		[DefaultValue(true)]
		public bool Editable
		{
			get => !ReadOnly;

			set => ReadOnly = !value;
		}

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		public Carboscrollbar ScrollBar { get; protected set; }

		protected Dictionary<string, MenuItem> contextMenuItemDict;
		protected Color backColor;
		protected Color foreColor;
		protected Regex regex;
		protected string restrict;
		protected string watermark;
		protected string rawWatermark;
		protected int tabSize = 8;
		protected bool isShowingWatermark;
		protected bool isScrollBarVisible = true;

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		public void SetForeColor(Color color)
		{
			foreColor = color;

			if (RawText != "")
				base.ForeColor = color;
		}

		new public void Paste()
		{
			if (Clipboard.ContainsText())
				base.Paste();
			else if (Clipboard.ContainsFileDropList())
				OnFilePasted?.Invoke(Clipboard.GetFileDropList());
			else if (Clipboard.ContainsImage())
				OnImagePasted?.Invoke(Clipboard.GetImage());
			else if (Clipboard.ContainsAudio())
				OnAudioPasted?.Invoke(Clipboard.GetAudioStream());
		}

		public void PasteRawText()
		{
			SelectedText = Clipboard.GetText();
		}

		public void ForcePaste()
		{
			base.Paste();
		}

		public void AppendImage(Image image, bool autoNewLines = true)
		{
			bool temp = Editable;
			Editable = true;

			if (autoNewLines)
				AppendText("\n");

			Clipboard.SetImage(image);

			ForcePaste();

			if (autoNewLines)
				AppendText("\n\n");

			Editable = temp;
		}

		override public void Refresh()
		{
			base.Refresh();

			UpdateTextLocation();
		}

		#endregion

		#region ########################### PRIVATE METHODS #############################

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		static protected extern IntPtr SendMessage(IntPtr handle, int message, int wParam, int[] lParam);

		[DllImport("User32.dll", EntryPoint = "PostMessageA")]
		static protected extern bool SendMessage(IntPtr handle, int message, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll", EntryPoint = "ShowCaret")]
		static protected extern long ShowCaret(IntPtr hwnd);

		[DllImport("User32.dll", EntryPoint = "HideCaret")]
		static protected extern int HideCaret(IntPtr handle);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		static protected extern int GetScrollPos(IntPtr handle, Orientation barOrientation);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		static protected extern int SetScrollPos(IntPtr handle, Orientation barOrientation, int position, bool redraw);

		[DllImport("User32.dll", EntryPoint = "PostMessageA")]
		static protected extern bool PostMessage(IntPtr handle, int message, int wParam, int lParam);

		protected void UpdateTextLocation()
		{
			SetScrollPos(Handle, Orientation.Vertical, ScrollBar.Value, true);

			const int updateMessageCode = 0x115;

			PostMessage(Handle, updateMessageCode, 0x10000 * ScrollBar.Value + 4, 0);
		}

		protected void UpdateScrollBarLocation()
		{
			ScrollBar.Value = GetScrollPos(Handle, Orientation.Vertical);
		}

		protected void UpdateScrollBarVisibility()
		{
			if (isScrollBarVisible = ScrollBar.Total > ScrollBar.Capacity)
			{
				if (ScrollBar.Parent == null)
					Parent?.AddControl(ScrollBar); // this is fixing a stupid C# bug!!

				// this can guarantee that the scrollbar is displayed
				// do not use ScrollBar.Visible = true instead, unless you're very
				// sure that your Trash Studio isn't working right and will probably show it
			}
			else
			{
				ScrollBar.Parent?.Controls.Remove(ScrollBar);
				// again, don't use ScrollBar.visible = false
				// because once it's false, it won't be set to true again.
			}
		}

		#endregion

		#region ############################### EVENTS ##################################

		#region *************** BASICS ***************

		override protected void WndProc(ref Message m)
		{
			const int mouseWheelMessageCode0 = 0x20A, mouseWheelMessageCode1 = 0x20E;

			// optimized scrolling (without smooth animations)
			if (m.Msg == mouseWheelMessageCode0 || m.Msg == mouseWheelMessageCode1)
			{
				if (ScrollBar.Visible)
				{
					ScrollBar.Value -= Math.Sign((int)m.WParam) * SystemInformation.MouseWheelScrollLines * 15;

					UpdateTextLocation();
				}
			}
			else
			{
				base.WndProc(ref m);
			}

			if (ReadOnly)
				HideCaret(Handle);
		}

		protected void OnBackColorChanged(object sender, EventArgs e)
		{
			BackColorChanged -= OnBackColorChanged;

			backColor = BackColor;
			ScrollBar.BackColor = ControlPaint.Light(BackColor, .20f);
		}

		protected void OnForeColorChanged(object sender, EventArgs e)
		{
			ForeColorChanged -= OnForeColorChanged;

			foreColor = ForeColor;
			ScrollBar.ForeColor = ControlPaint.Light(BackColor, .65f);
		}

		override protected void OnEnter(EventArgs e)
		{
			base.OnEnter(e);

			if (ReadOnly)
				HideCaret(Handle);

			if (RawText == "")
			{
				base.Text = "";
				base.ForeColor = foreColor;
			}
		}

		override protected void OnLeave(EventArgs e)
		{
			base.OnLeave(e);

			if (string.IsNullOrEmpty(rawWatermark))
				return;

			if (base.Text == "")
			{
				isShowingWatermark = true;

				base.Text = watermark;
				base.ForeColor = WatermarkColor;
			}
		}

		override protected void OnReadOnlyChanged(EventArgs e)
		{
			base.OnReadOnlyChanged(e);

			if (Focused && ReadOnly)
				HideCaret(Handle);

			if (BorderStyleWhenEditing != BorderStyle.None)
				BorderStyle = ReadOnly ? BorderStyle.None : BorderStyleWhenEditing;

			if (BackColorWhenEditing != Color.Transparent)
				BackColor = ReadOnly ? backColor : BackColorWhenEditing;

			TabSize = tabSize;

			contextMenuItemDict["Undo"].Enabled =
				contextMenuItemDict["Cut"].Enabled =
				contextMenuItemDict["Paste"].Enabled =
				contextMenuItemDict["Paste Raw Text"].Enabled =
				contextMenuItemDict["Delete"].Enabled = Editable;
		}

		#endregion

		#region *************** HOTKEYS & CONTEXT MENU ***************

		override protected bool ProcessCmdKey(ref Message message, Keys keys)
		{
			switch (keys)
			{
				case Keys.Control | Keys.V:
					if (contextMenuItemDict["Paste"].Enabled)
						Paste();

					return true;

				case Keys.Control | Keys.Shift | Keys.V:
					if (contextMenuItemDict["Paste Raw Text"].Enabled)
						PasteRawText();

					return true;
			}

			return base.ProcessCmdKey(ref message, keys);
		}

		protected void OnContextMenuPopup(object sender, EventArgs e)
		{
			if (Editable)
			{
				contextMenuItemDict["Paste Raw Text"].Enabled = Clipboard.ContainsText();
				contextMenuItemDict["Paste"].Enabled = contextMenuItemDict["Paste Raw Text"].Enabled
					|| Clipboard.ContainsImage() || Clipboard.ContainsFileDropList();

				contextMenuItemDict["Cut"].Enabled = SelectionLength > 0;
			}

			contextMenuItemDict["Copy"].Enabled = SelectionLength > 0;
		}

		protected void OnContextMenuItemClick(object sender, EventArgs e)
		{
			switch ((sender as MenuItem).Text)
			{
				case "Undo":
					tra.ce(UndoActionName);
					Undo();
					break;

				case "Cut":
					Cut();
					break;

				case "Copy":
					Copy();
					break;

				case "Paste":
					Paste();
					break;

				case "Paste Raw Text":
					PasteRawText();
					break;

				case "Delete":
					SendKeys.Send("{BACKSPACE}");
					break;

				case "Select All":
					SelectAll();
					break;
			}
		}

		#endregion

		#region *************** SCROLLBAR ***************

		override protected void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);

			if (Visible)
			{
				if (isScrollBarVisible)
					Parent?.AddControl(ScrollBar);
			}
			else
			{
				ScrollBar.Parent?.Controls.Remove(ScrollBar);
			}
		}

		override protected void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);

			ScrollBar.Location = new Point(Right - ScrollBar.Width, Top);

			ScrollBar.Height = ScrollBar.Capacity = Height;

			if (ReadOnly)
				HideCaret(Handle);

			UpdateScrollBarVisibility();
		}

		override protected void OnTextChanged(EventArgs e)
		{
			if (Editable && isShowingWatermark)
			{
				if (!ContainsOnlyWatermark)
					isShowingWatermark = false;

				return;
			}

			base.OnTextChanged(e);
		}

		override protected void OnContentsResized(ContentsResizedEventArgs e)
		{
			base.OnContentsResized(e);

			if (e.NewRectangle.Location.IsEmpty) // THIS IS TO FIX A STUPID C# BUG
				return;

			ScrollBar.Total = e.NewRectangle.Height;

			UpdateScrollBarVisibility();
		}

		override protected void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);

			UpdateScrollBarLocation();
		}

		override protected void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			MouseMove += OnMouseMove;
			MouseUp += OnMouseUp;

			if (ReadOnly)
				HideCaret(Handle);

			UpdateScrollBarLocation();
		}

		protected void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (ReadOnly)
				HideCaret(Handle);

			if (this.IsMouseEntered())
				return;

			UpdateScrollBarLocation();
		}

		protected void OnMouseUp(object sender, MouseEventArgs e)
		{
			if (ReadOnly)
				HideCaret(Handle);

			MouseMove -= OnMouseMove;
			MouseUp -= OnMouseUp;
		}

		protected void OnScrollBarDragged(int value)
		{
			UpdateTextLocation();
		}

		#endregion

		#region *************** OPTIONS ***************

		protected override void OnSelectionChanged(EventArgs e)
		{
			base.OnSelectionChanged(e);

			if (!ImageSelectable && SelectionType == RichTextBoxSelectionTypes.Object)
				SelectionLength = 0;
		}

		#endregion

		#endregion

	}

}

#region ****** EXTENSIONS ******

//internal struct MPoint
//{

//	public MPoint(Fixed x, Fixed y)
//	{
//		X = x;
//		Y = y;
//	}

//	public Fixed X, Y;

//}

//internal struct Fixed
//{

//	public Fixed(short fract, short value)
//	{
//		Fract = fract;
//		Value = value;
//	}

//	public short Fract, Value;

//}

#endregion