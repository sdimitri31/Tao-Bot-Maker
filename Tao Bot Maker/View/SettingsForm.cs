using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.View.Setting;

namespace Tao_Bot_Maker.View
{
    public partial class SettingsForm : Form
    {
        private SettingsType SelectedSettingsType { get; set; }

        private readonly List<UserControl> panels;

        public SettingsForm(SettingsType selectedSettingsType = SettingsType.General)
        {
            InitializeComponent();
            //_ = new DarkModeCS(this, false);
            panels = new List<UserControl>();
            FillSettingsForm();
            LoadSettings();
            settingsTypelistBox.SelectedItem = selectedSettingsType;
        }

        private void FillSettingsForm()
        {
            foreach (SettingsType settingsType in Enum.GetValues(typeof(SettingsType)))
            {
                settingsTypelistBox.Items.Add(settingsType);
                AddPropertiesPanel(settingsType);
            }
        }

        private void AddPropertiesPanel(SettingsType settingsType)
        {
            UserControl panel = null;

            switch (settingsType)
            {
                case SettingsType.General:
                    panel = new GeneralSettingsPropertiesPanel();
                    break;
                case SettingsType.Hotkeys:
                    panel = new HotkeySettingsPropertiesPanel();
                    break;
                case SettingsType.Other:
                    panel = new OtherSettingsPropertiesPanel();
                    break;
                default:
                    break;
            }

            if (panel != null)
            {
                panel.Location = new Point(0, 0);
                panel.Visible = false;
                settingsPropertiesPanel.Controls.Add(panel);
                panels.Add(panel);
            }
        }

        private void ShowPanel(SettingsType settingsType)
        {
            foreach (UserControl panel in panels)
            {
                panel.Visible = (panel as ISettingsPropertiesPanel).GetType() == settingsType;
            }
        }

        private void SettingsTypelistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSettingsType = (SettingsType)settingsTypelistBox.SelectedIndex;
            ShowPanel(SelectedSettingsType);
        }

        private void LoadSettings()
        {
            foreach (UserControl panel in panels)
            {
                (panel as ISettingsPropertiesPanel).LoadSettings();
            }
        }

        private void SaveSettings()
        {
            foreach (UserControl panel in panels)
            {
                (panel as ISettingsPropertiesPanel).SaveSettings();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
