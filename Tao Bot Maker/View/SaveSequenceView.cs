﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.mode = 0;
            this.sequenceToSave = sequenceToSave;
            LoadSequencesList();
        }

        private void SetMode(int tabIndex)
        {
            this.mode = tabIndex;
        }

        private void LoadSequencesList()
        {
            comboBox_SelectSave.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            try
            {
                comboBox_SelectSave.SelectedIndex = 0;
            }
            catch { }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMode(tabControl.SelectedIndex);
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
                SequenceXmlManager.SaveSequence(comboBox_SelectSave.SelectedItem.ToString(), sequenceToSave);
                ReturnValueSequenceName = textBox_SaveName.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
