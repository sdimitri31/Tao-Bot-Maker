﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.View.Setting
{
    public partial class GeneralSettingsPropertiesPanel : UserControl, ISettingsPropertiesPanel
    {
        public GeneralSettingsPropertiesPanel()
        {
            InitializeComponent();
            InitializeLanguage();
            InitializeTheme();
        }

        public void InitializeLanguage()
        {
            this.languageComboBox.Items.AddRange(new object[] {
                "English",
                "Français"
            });
        }

        public void InitializeTheme()
        {
            this.themeComboBox.Items.AddRange(new object[] {
                "Auto",
                "Light",
                "Dark"
            });
        }

        public void LoadSettings(Settings settings)
        {
            languageComboBox.SelectedItem = settings.GetSettingValue<string>(Settings.SETTING_LANGUAGE);
            themeComboBox.SelectedItem = settings.GetSettingValue<string>(Settings.SETTING_THEME);
        }

        public void SaveSettings(Settings settings)
        {
            settings.SetSettingValue(Settings.SETTING_LANGUAGE, languageComboBox.SelectedItem.ToString(), SettingsType.General);
            settings.SetSettingValue(Settings.SETTING_THEME, themeComboBox.SelectedItem.ToString(), SettingsType.General);
        }

        SettingsType ISettingsPropertiesPanel.GetType()
        {
            return SettingsType.General;
        }
    }
}