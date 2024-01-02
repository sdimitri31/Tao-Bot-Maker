
using LogFramework;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionClickController
    {
        public ActionClickController() { }

        public static Action GetActionFromControl(ActionClickPanel panel)
        {
            int errorCount = 0;
            String errorMessage = "";
            ActionClick actionClick = null;

            //X1
            int x = panel.X;
            if (x < 0)
            {
                errorCount++;
                errorMessage += "Erreur : X should be a number greater or equal to 0\r\n";
            }

            //Y1
            int y = panel.Y;
            if (y < 0)
            {
                errorCount++;
                errorMessage += "Erreur : Y should be a number greater or equal to 0\r\n";
            }

            //SequenceIfFound
            string selectedClick = panel.SelectedClick;

            if (selectedClick == null)
            {
                errorCount++;
                errorMessage += "Erreur : A clic must be selected\r\n";
            }

            if (errorCount == 0)
            {
                actionClick = new ActionClick(selectedClick, x, y);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
           
            return actionClick;
        }

    }
}
