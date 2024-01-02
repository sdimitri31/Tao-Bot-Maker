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
    public partial class ActionSequencePanel : UserControl
    {
        public ActionSequencePanel()
        {
            InitializeComponent();
            comboBoxPanelActionSequence.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
        }

        public ActionSequencePanel(Action action)
        {
            InitializeComponent();
            comboBoxPanelActionSequence.Items.AddRange(SequenceXmlManager.SequencesList().ToArray());
            SequencePath = ((ActionSequence)action).SequencePath;
        }

        public String SequencePath
        {
            get
            {
                try
                {
                    if (comboBoxPanelActionSequence.SelectedItem != null)
                    {
                        String sequenceName = comboBoxPanelActionSequence.SelectedItem.ToString();
                        return sequenceName;
                    }
                    return "";
                }
                catch
                {
                    return null;
                }
            }
            set { comboBoxPanelActionSequence.SelectedItem = value.ToString(); }
        }
    }
}
