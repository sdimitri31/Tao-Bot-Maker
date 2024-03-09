using System.Collections.Generic;
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
            flatComboBox_SequenceName.Items.AddRange(sequenceListFiltered.ToArray());
            
            if (action != null)
            {
                SequenceName = ((ActionSequence)action).SequenceName;
            }
        }

        private void Localization()
        {
            label_Sequence.Text = Properties.strings.label_Sequence;
        }

        public string SequenceName
        {
            get
            {
                try
                {
                    if (flatComboBox_SequenceName.SelectedItem != null)
                    {
                        string sequenceName = flatComboBox_SequenceName.SelectedItem.ToString();
                        return sequenceName;
                    }
                    return "";
                }
                catch
                {
                    return null;
                }
            }
            set { flatComboBox_SequenceName.SelectedItem = value.ToString(); }
        }
    }
}
