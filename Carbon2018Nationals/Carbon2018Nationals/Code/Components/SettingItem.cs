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

	public partial class SettingItem : UserControl
	{

		/// ############################# CONSTRUCTOR ###############################

		public SettingItem()
		{
			InitializeComponent();
		}

		public SettingItem(string title, string description, int selectedIndex, params string[] args)
		{
			InitializeComponent();

			Title = title;
			Description = description;
			Values = args;
			SelectedIndex = selectedIndex;

			Editable = false;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public Action<int> OnValueChanged { get; set; }

		public string Title
		{
			get => TitleLabel.Text;

			set => TitleLabel.Text = value;
		}

		public string Description
		{
			get => DescriptionLabel.Text;

			set => DescriptionLabel.Text = value;
		}

		public string[] Values
		{
			get => ValueComboBox.Items.Cast<dynamic>().Select(x => (string)x).ToArray();

			set
			{
				ValueComboBox.Items.Clear();
				ValueComboBox.Items.AddRange(value);
			}
		}

		public int SelectedIndex
		{
			get => ValueComboBox.SelectedIndex;

			set => ValueComboBox.SelectedIndex = value;
		}

		public string SelectedText
		{
			get => ValueLabel.Text;
		}

		public bool Editable
		{
			get => ValueComboBox.Visible;

			set
			{
				ValueComboBox.Visible = value;
				ValueLabel.Visible = !value;
			}
		}

		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################



		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################

		override protected void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);

			TitleLabel.ForeColor = ForeColor;
		}

		override protected void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);

			ValueLabel.Left = Width - 218;
			ValueComboBox.Left = Width - 172;
		}

		protected void OnValueComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			ValueLabel.Text = ValueComboBox.Text;

			OnValueChanged?.Invoke(SelectedIndex);
		}

	}

}
