using System;
using System.Windows.Forms;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionLoopController
    {
        public ActionLoopController() { }

        public static Action GetActionFromControl(ActionLoopPanel panel)
        {
            //Action Loop arguments
            String sequencePath = panel.SequencePath;
            int numberOfRepetition = panel.NumberOfRepetitions;
            ActionLoop actionLoop = null;

            //Error handling
            int errorCount = 0;
            String errorMessage = "";

            //Checking inputs
            if (sequencePath == "")
            {
                errorCount++;
                errorMessage += "Erreur : A sequence must be selected\r\n";
            }

            if(numberOfRepetition <= 0)
            {
                errorCount++;
                errorMessage += "Erreur : Number of repetition must be above 0\r\n";
            }

            //Creating action or returning error
            if (errorCount == 0)
            {
                actionLoop = new ActionLoop(sequencePath, numberOfRepetition);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }

            return actionLoop;
        }

    }
}
