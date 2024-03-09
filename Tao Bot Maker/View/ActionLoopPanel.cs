using System.Collections.Generic;
using System.Windows.Forms;

namespace Tao_Bot_Maker.View
{
    public partial class ActionLoopPanel : UserControl
    {
        public ActionLoopPanel(ActionView actionView, Action action = null)
        {
            InitializeComponent();
            Localization();

            List<string> sequenceListFiltered = SequenceXmlManager.SequencesListFiltered(actionView.GetLoadedSequenceName());
            flatComboBox_SequenceName.Items.AddRange(sequenceListFiltered.ToArray());

            if (action != null)
            {
                SequenceName = ((ActionLoop)action).SequenceName;
                RepeatNumber = ((ActionLoop)action).RepeatNumber;
            }
        }

        private void Localization()
        {
            label_RepeatNumber.Text = Properties.strings.label_RepeatNumber;
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
                    return "";
                }
            }
            set { flatComboBox_SequenceName.SelectedItem = value.ToString(); }
        }

        public int RepeatNumber
        {
            get => (int)numericUpDown_RepeatNumber.Value;
            set => numericUpDown_RepeatNumber.Value = value;
        }
    }
}
