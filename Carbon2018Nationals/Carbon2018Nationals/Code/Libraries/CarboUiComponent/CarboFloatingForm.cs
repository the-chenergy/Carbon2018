using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarboUiComponent
{

	public partial class CarboFloatingForm : Form
	{

		/// ############################# CONSTRUCTOR ###############################

		public CarboFloatingForm()
		{
			InitializeComponent();

			Activate();
		}

		/// ########################## PUBLIC PROPERTIES ############################



		/// ######################### PRIVATE PROPERTIES ############################

		public CarboFormCover FormCover { get; protected set; }

		/// ########################### PUBLIC METHODS ##############################

		public void ShowForm(Form parent)
		{
			if (FormCover != null)
				return;

			FormCover = new CarboFormCover();
			FormCover.ShowCover(parent, this);

			Show(parent);

			parent.LocationChanged += OnParentLocationChanged;
			parent.ClientSizeChanged += OnParentClientSizeChanged;

			UpdateLocation();
		}

		/// ########################### PRIVATE METHODS #############################

		protected void UpdateLocation()
		{
			Point parentLocation = FormCover.Owner.PointToScreen(new Point());
			Size parentSize = FormCover.Owner.ClientSize;

			Left = parentLocation.X + (parentSize.Width - Width) / 2;
			Top = parentLocation.Y + (parentSize.Height - Height) / 2;
		}

		/// ############################### EVENTS ##################################

		override protected void OnFormClosing(FormClosingEventArgs e)
		{
			if (FormCover.Owner != null)
			{
				FormCover.Owner.LocationChanged -= OnParentLocationChanged;
				FormCover.Owner.ClientSizeChanged -= OnParentClientSizeChanged;

				FormCover.Owner.Activate();
				FormCover.Owner.BringToFront();
			}

			FormCover.Close();
			FormCover.Dispose();

			base.OnFormClosing(e);
		}

		protected void OnParentLocationChanged(object sender, EventArgs e)
		{
			UpdateLocation();
		}

		protected void OnParentClientSizeChanged(object sender, EventArgs e)
		{
			UpdateLocation();
		}

	}

}
