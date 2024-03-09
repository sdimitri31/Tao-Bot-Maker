using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;

namespace Tao_Bot_Maker.View
{
    public partial class ActionWaitPanel : UserControl
    {
        public ActionWaitPanel(Action action = null)
        {
            InitializeComponent();
            Localization();

            string[] timeUnits = { "ms", "s", "min", "h" };

            flatComboBox_WaitTimeUnits.Items.AddRange(timeUnits);
            flatComboBox_WaitTimeUnits.SelectedIndex = 0;

            flatComboBox_WaitTimeMaxUnits.Items.AddRange(timeUnits);
            flatComboBox_WaitTimeMaxUnits.SelectedIndex = 0;

            if (action != null)
            {
                WaitTime = ((ActionWait)action).WaitTime;
                WaitTimeMax = ((ActionWait)action).WaitTimeMax;
                IsRandomInterval = ((ActionWait)action).IsRandomInterval;
            }
            UpdateButtonState();
        }

        private void Localization()
        {
            label_WaitTime.Text = Properties.strings.label_WaitTime;
            label_IsRandomInterval.Text = Properties.strings.label_IsRandomInterval;
            label_WaitTimeMax.Text = Properties.strings.label_WaitTimeMax;
        }

        public int WaitTime
        {
            get => (int)numericUpDown_WaitTime.Value;
            set => numericUpDown_WaitTime.Value = value;
        }

        public int WaitTimeMax
        {
            get => (int)numericUpDown_WaitTimeMax.Value;
            set => numericUpDown_WaitTimeMax.Value = value;
        }

        public bool IsRandomInterval
        {
            get { return checkBox_IsRandomInterval.Checked; }
            set { checkBox_IsRandomInterval.Checked = value; }
        }

        public string WaitTimeUnit
        {
            get => flatComboBox_WaitTimeUnits.SelectedItem.ToString();
            set => flatComboBox_WaitTimeUnits.SelectedItem = flatComboBox_WaitTimeUnits.FindStringExact(value);
        }

        public string WaitTimeMaxUnit
        {
            get => flatComboBox_WaitTimeMaxUnits.SelectedItem.ToString();
            set => flatComboBox_WaitTimeMaxUnits.SelectedItem = flatComboBox_WaitTimeMaxUnits.FindStringExact(value);
        }

        private void UpdateButtonState()
        {
            numericUpDown_WaitTimeMax.Enabled = IsRandomInterval; 
            flatComboBox_WaitTimeMaxUnits.Enabled = IsRandomInterval;
            label_WaitTimeMax.Enabled = IsRandomInterval;
            if (IsRandomInterval)
            {
                label_WaitTime.Text = Properties.strings.label_WaitTimeMin;
            }
            else
            {
                label_WaitTime.Text = Properties.strings.label_WaitTime;
            }
        }

        private void CheckBox_IsRandomInterval_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void FlatComboBox_WaitTimeUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown_WaitTime.Maximum = Utils.GetMaxIntValueFromTimeUnitInMS(WaitTimeUnit);
        }

        private void FlatComboBox_WaitTimeMaxUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown_WaitTimeMax.Maximum = Utils.GetMaxIntValueFromTimeUnitInMS(WaitTimeMaxUnit);
        }
    }
}
