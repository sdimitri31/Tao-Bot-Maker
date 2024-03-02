
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;
using static System.Windows.Forms.LinkLabel;

namespace Tao_Bot_Maker
{
    public class ActionClickController
    {
        /// <summary>
        /// Check if every data needed to create an ActionClick are in range
        /// </summary>
        /// <param name="click">Expected : "left", "middle" or "right"</param>
        /// <param name="x1">Expected : int between -999999 and 999999</param>
        /// <param name="y1">Expected : int between -999999 and 999999</param>
        /// <param name="x2">Expected : int between -999999 and 999999</param>
        /// <param name="y2">Expected : int between -999999 and 999999</param>
        /// <param name="isDoubleClick">Expected : true or false</param>
        /// <param name="isDrag">Expected : true or false</param>
        /// <param name="dragSpeed">Expected : int between 1 and 5</param>
        /// <returns>ActionClick if all test passed. string errorMessage if something was wrong</returns>
        public static (ActionClick actionClick, string errorMessage) CreateActionClick(String click, int x1, int y1, int x2, int y2, bool isDoubleClick, bool isDrag, int dragSpeed)
        {
            int errorCount = 0;
            String errorMessage = "";

            int[] array2 = { x1, x2, y1, y2 };
            if (!ValidateCoord(array2, out string error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            if (!ValidateClick(click, out error))
            {
                errorCount++;
                errorMessage += error + "\r\n";
            }

            if(!ValidateDragSpeed(dragSpeed, out error))
            {
                errorCount++;
                errorMessage += error;
            }

            ActionClick actionClick = null;

            if (errorCount == 0)
            {
                actionClick = new ActionClick(click, x1, y1, x2, y2, isDoubleClick, isDrag, dragSpeed);
            }

            //Return Error message if there is an error
            if (actionClick == null)
                return (null, errorMessage);
            //Or ActionClick if no error
            else
                return (actionClick, "");
        }

        private static bool ValidateCoord(int[] coords, out string errorMessage)
        {
            errorMessage = "";
            string coordsList = "";

            foreach (int coord in coords)
            {
                if ((coord < -999999) || (coord > 999999))
                {
                    errorMessage = Properties.strings.action_ErrorMessage_InvalidCoords;
                    Log.Write("ValidateCoord(" + coord + ") Result : false", LogFramework.Log.ERROR);
                    return false;
                }
                coordsList += coord + ", ";
            }

            Log.Write("ValidateCoord(" + coordsList + ") Result : true", LogFramework.Log.TRACE);
            return true;
        }

        private static bool ValidateClick(string click, out string errorMessage)
        {
            errorMessage = "";

            if ((click != null) && ((click == "left") || (click == "middle") || (click == "right")))
            {
                Log.Write("ValidateClick(" + click + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_ClickNotSelected;
                Log.Write("ValidateClick(" + click + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        private static bool ValidateDragSpeed(int dragSpeed, out string errorMessage)
        {
            errorMessage = "";

            if ((dragSpeed >= 1) && (dragSpeed <= 5))
            {
                Log.Write("ValidateDragSpeed(" + dragSpeed + ") Result : true", LogFramework.Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_DragSpeedWrongInterval;
                Log.Write("ValidateDragSpeed(" + dragSpeed + ") Result : false", LogFramework.Log.ERROR);
                return false;
            }
        }

        public static Action GetActionFromControl(ActionClickPanel panel)
        {
            var (actionClick, errorMessage) = CreateActionClick(panel.SelectedClick, panel.X1, panel.Y1, panel.X2, panel.Y2, panel.IsDoubleClick, panel.IsDrag, panel.DragSpeed); ;

            if (string.IsNullOrEmpty(errorMessage))
                return actionClick;
            else
            {
                Log.Write(errorMessage, LogFramework.Log.ERROR);
                MessageBox.Show(errorMessage);
            }
            return null;
        }

    }
}
