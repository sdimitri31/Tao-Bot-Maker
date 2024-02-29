
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

        public static Action GetActionFromControl(panel_ActionClick panel)
        {
            int errorCount = 0;
            String errorMessage = "";
            ActionClick actionClick = null;

            //X1
            int x1 = panel.X1;
            if (x1 < -999999 || x1 > 999999)
            {
                errorCount++;
                errorMessage += "Erreur : X1 should be a number between -999999 and 999999\r\n";
            }

            //X2
            int x2 = panel.X2;
            if (x2 < -999999 || x2 > 999999)
            {
                errorCount++;
                errorMessage += "Erreur : X2 should be a number between -999999 and 999999\r\n";
            }

            //Y1
            int y1 = panel.Y1;
            if (y1 < -999999 || y1 > 999999)
            {
                errorCount++;
                errorMessage += "Erreur : Y1 should be a number between -999999 and 999999\r\n";
            }

            //Y2
            int y2 = panel.Y2;
            if (y2 < -999999 || y2 > 999999)
            {
                errorCount++;
                errorMessage += "Erreur : Y2 should be a number between -999999 and 999999\r\n";
            }

            //Selected click
            string selectedClick = panel.SelectedClick;
            if (selectedClick == null)
            {
                errorCount++;
                errorMessage += "Erreur : A clic must be selected\r\n";
            }

            bool isDoubleClick = panel.IsDoubleClick;
            bool isDrag = panel.IsDrag;

            int dragSpeed = panel.DragSpeed;

            if (errorCount == 0)
            {
                actionClick = new ActionClick(selectedClick, x1, y1, x2, y2, isDoubleClick, isDrag, dragSpeed);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
           
            return actionClick;
        }

    }
}
