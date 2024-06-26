﻿using System;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;
using Action = Tao_Bot_Maker.Model.Action;

namespace Tao_Bot_Maker.View
{
    public partial class SequenceActionPropertiesPanel : UserControl, IActionPropertiesPanel
    {
        public SequenceActionPropertiesPanel()
        {
            InitializeComponent();
            InitializeSequence();
        }

        public Action GetAction()
        {
            SequenceAction sequenceAction = new SequenceAction(
                sequenceName: sequenceComboBox.SelectedItem.ToString(),
                repeatCount: (int)repeatCountNumericUpDown.Value
            );

            return sequenceAction;
        }

        public void InitializeSequence()
        {
            sequenceComboBox.Items.Clear();
            SequenceController sequenceController = new SequenceController();
            foreach (var sequenceName in sequenceController.GetAllSequenceNames())
            {
                sequenceComboBox.Items.Add(sequenceName);
            }
        }

    }
}
