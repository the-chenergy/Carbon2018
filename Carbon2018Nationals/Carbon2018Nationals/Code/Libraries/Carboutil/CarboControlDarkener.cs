using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carboutil
{

	public class CarboControlDarkener
	{

		/// ########################## PUBLIC PROPERTIES ############################



		/// ######################### PRIVATE PROPERTIES ############################

		static protected Dictionary<Control, Color> origBackColordict = new Dictionary<Control, Color>();
		static protected Dictionary<Control, Color> origForeColorDict = new Dictionary<Control, Color>();
		static protected Dictionary<Control, Color> darkBackColorDict = new Dictionary<Control, Color>();

		/// ########################### PUBLIC METHODS ##############################

		static public void Darken(Control control, float percentage = .25f)
		{
			if (darkBackColorDict.ContainsKey(control) && darkBackColorDict[control] == control.BackColor)
				return;

			origBackColordict[control] = control.BackColor;
			origForeColorDict[control] = control.ForeColor;

			control.BackColor = darkBackColorDict[control] = ControlPaint.Dark(control.BackColor, percentage);
			control.ForeColor = ControlPaint.Dark(control.ForeColor, percentage);
		}

		static public void Undarken(Control control)
		{
			if (!darkBackColorDict.ContainsKey(control) || darkBackColorDict[control] != control.BackColor)
				return;

			control.BackColor = origBackColordict[control];
			control.ForeColor = origForeColorDict[control];
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
