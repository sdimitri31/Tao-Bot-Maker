using System;
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
    public partial class ActionLoopPanel : UserControl
    {
        public ActionLoopPanel()
        {
            InitializeComponent();

            comboBoxPanelActionLoopSequence.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
        }
        public ActionLoopPanel(Action action)
        {
            InitializeComponent();

            comboBoxPanelActionLoopSequence.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            SequencePath = ((ActionLoop)action).SequencePath;
            NumberOfRepetitions = ((ActionLoop)action).NumberOfRepetitions;
        }

        public String SequencePath
        {
            get
            {
                try
                {
                    if (comboBoxPanelActionLoopSequence.SelectedItem != null)
                    {
                        String sequenceName = comboBoxPanelActionLoopSequence.SelectedItem.ToString();
                        return sequenceName;
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            set { comboBoxPanelActionLoopSequence.SelectedItem = value.ToString(); }
        }

        public int NumberOfRepetitions
        {
            get
            {
                try
                {
                    if (textBoxPanelBoucle_NbRepetition.Text != null)
                    {
                        int numberOfRepetition = Int32.Parse(textBoxPanelBoucle_NbRepetition.Text);
                        return numberOfRepetition;
                    }
                    return -1;
                }
                catch
                {
                    return -1;
                }
            }
            set { textBoxPanelBoucle_NbRepetition.Text = value.ToString(); }
        }
    }
}
