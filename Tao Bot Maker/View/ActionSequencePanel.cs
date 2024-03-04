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
        public ActionSequencePanel(ActionView actionView, Action action = null)
        {
            InitializeComponent();
            Localization();

            List<string> sequenceListFiltered = SequenceXmlManager.SequencesListFiltered(actionView.GetLoadedSequenceName());
            flatComboBoxPanelActionSequence.Items.AddRange(sequenceListFiltered.ToArray());
            
            if (action != null)
            {
                SequencePath = ((ActionSequence)action).SequencePath;
            }
        }

        private void Localization()
        {
            label_Sequence.Text = Properties.strings.label_Sequence;
        }

        public String SequencePath
        {
            get
            {
                try
                {
                    if (flatComboBoxPanelActionSequence.SelectedItem != null)
                    {
                        String sequenceName = flatComboBoxPanelActionSequence.SelectedItem.ToString();
                        return sequenceName;
                    }
                    return "";
                }
                catch
                {
                    return null;
                }
            }
            set { flatComboBoxPanelActionSequence.SelectedItem = value.ToString(); }
        }
    }
}
