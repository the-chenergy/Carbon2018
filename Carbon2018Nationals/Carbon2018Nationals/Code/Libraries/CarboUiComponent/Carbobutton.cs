using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarboUiComponent
{

	public partial class Carbobutton : Button
	{

		/// ############################# CONSTRUCTOR ###############################

		public Carbobutton()
		{
			InitializeComponent();
		}

		/// ########################## PUBLIC PROPERTIES ############################

		[DefaultValue(true)]
		public bool DisplayFocusCues { get; set; } = true;

		/// ######################### PRIVATE PROPERTIES ############################

		override protected bool ShowFocusCues
		{
			get
			{
				if (!DisplayFocusCues)
					return false;

				try
				{
					return Global.IsTabPressed;
				}
				finally
				{
					Global.IsTabPressed = false;
				}
			}
		}

		/// ########################### PUBLIC METHODS ##############################

		new public void SetStyle(ControlStyles styles, bool flag)
		{
			base.SetStyle(styles, flag);
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
