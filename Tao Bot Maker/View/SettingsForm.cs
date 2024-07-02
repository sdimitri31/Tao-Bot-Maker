using BlueMystic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View.Setting;
using Settings = Tao_Bot_Maker.Model.Settings;

namespace Tao_Bot_Maker.View
{
    public partial class SettingsForm : Form
    {
        public SettingsType SelectedSettingsType { get; set; }
        private SettingsController SettingsController { get; set; }
        public Settings Settings { get; set; }

        private List<UserControl> panels;

        public SettingsForm(Settings settings, SettingsType settingsType = SettingsType.General)
        {
            InitializeComponent();
            //_ = new DarkModeCS(this, false);
            this.Settings = settings;
            panels = new List<UserControl>();
            FillSettingsTypeListBox();
            LoadSettings();
            settingsTypelistBox.SelectedItem = settingsType;
        }

        private void FillSettingsTypeListBox()
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
                (panel as ISettingsPropertiesPanel).LoadSettings(Settings);
            }
        }

        private void SaveSettings()
        {
            foreach (UserControl panel in panels)
            {
                (panel as ISettingsPropertiesPanel).SaveSettings(Settings);
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
