using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarboUiComponent
{

	public partial class CarboFormCover : Form
	{

		/// ############################# CONSTRUCTOR ###############################

		public CarboFormCover()
		{
			InitializeComponent();

			Click += OnClick;
			Activated += OnActivated;
			FormClosing += OnFormClosing;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public Form ChildForm { get; set; }

		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################

		public void ShowCover(Form parent, Form child = null)
		{
			ChildForm = child;

			Location = parent.PointToScreen(new Point());
			ClientSize = parent.ClientSize;

			Show(parent);

			foreach (Control p in parent.Controls)
				p.TabStop = false;

			const int disableAeroMessageCode = 3;

			// disable aero
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int value = 1;

				DwmSetWindowAttribute(parent.Handle, disableAeroMessageCode, ref value, 4);
			}

			parent.LocationChanged += OnOwnerLocationChanged;
			parent.ClientSizeChanged += OnOwnerClientSizeChanged;

			if (child != null)
				child.Select();
		}

		/// ########################### PRIVATE METHODS #############################

		[DllImport("dwmapi.dll")]
		static protected extern int DwmSetWindowAttribute(IntPtr handle, int attr, ref int value, int attrLen);

		/// ############################### EVENTS ##################################

		protected void OnOwnerLocationChanged(object sender, EventArgs e)
		{
			Location = Owner.PointToScreen(default);
		}

		protected void OnOwnerClientSizeChanged(object sender, EventArgs e)
		{
			ClientSize = Owner.ClientSize;
		}

		protected void OnClick(object sender, EventArgs e)
		{
			if (ChildForm != null)
				BeginInvoke(new Action(() => ChildForm.CancelButton?.PerformClick()));
		}

		protected void OnActivated(object sender, EventArgs e)
		{
			if (ChildForm == null)
				BeginInvoke(new Action(() => Owner.Activate()));
			else
				BeginInvoke(new Action(() => ChildForm.Activate()));
		}

		protected void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			Activated -= OnActivated;
			FormClosing -= OnFormClosing;

			if (Owner == null)
				return;
			
			Owner.LocationChanged -= OnOwnerLocationChanged;
			Owner.ClientSizeChanged -= OnOwnerClientSizeChanged;

			foreach (Control p in Owner.Controls)
				p.TabStop = true;

			const int disableAeroMessageCode = 3;

			// re-enable aero
			if (!Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
			{
				int value = 0;

				DwmSetWindowAttribute(Owner.Handle, disableAeroMessageCode, ref value, 4);
			}
		}

	}

}
