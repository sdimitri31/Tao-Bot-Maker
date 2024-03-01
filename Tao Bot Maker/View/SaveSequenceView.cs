using BlueMystic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;

namespace Tao_Bot_Maker.View
{
    public partial class SaveSequenceView : Form
    {
        public String ReturnValueSequenceName { get; set; }
        private int mode;
        private SequenceController sequenceToSave;

        public SaveSequenceView(SequenceController sequenceToSave)
        {
            InitializeComponent();
            DarkModeCS DM = new DarkModeCS(this, SettingsController.GetTheme(), false);
            Localization();

            this.mode = 0;
            this.ActiveControl = textBox_SaveName;
            this.sequenceToSave = sequenceToSave;
            LoadSequencesList();
        }
        private void Localization()
        {
            button_Cancel.Text = Properties.strings.button_Cancel;
            button_Ok.Text = Properties.strings.button_OK;
            tabPage1.Text = Properties.strings.tab_NewSequence;
            tabPage2.Text = Properties.strings.tab_ReplaceSequence;
            Text = Properties.strings.title_SaveSequenceDialog;
        }

        private void SetMode(int tabIndex)
        {
            this.mode = tabIndex;
            if(this.mode == 0)
            {
                this.ActiveControl = textBox_SaveName;
            }
        }

        private void LoadSequencesList()
        {
            flatComboBox_SelectSave.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            try
            {
                flatComboBox_SelectSave.SelectedIndex = 0;
            }
            catch { }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMode(flatTabControl1.SelectedIndex);
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                if(!SequenceXmlManager.IsNameUsed(textBox_SaveName.Text))
                {
                    SequenceXmlManager.SaveSequence(textBox_SaveName.Text, sequenceToSave);
                    ReturnValueSequenceName = textBox_SaveName.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //Prevent closing
                    MessageBox.Show("Name already used");
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                string sequenceName = flatComboBox_SelectSave.SelectedItem.ToString();
                SequenceXmlManager.SaveSequence(sequenceName, sequenceToSave);
                ReturnValueSequenceName = sequenceName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
