
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;
using static System.Windows.Forms.LinkLabel;

namespace Tao_Bot_Maker
{
    public class ActionClickController
    {
        //Default values
        private static readonly string  _defaultClick = "left";
        private static readonly int     _defaultX1 = 0;
        private static readonly int     _defaultX2 = 0;
        private static readonly int     _defaultY1 = 0;
        private static readonly int     _defaultY2 = 0;
        private static readonly bool    _defaultIsDoubleClick = false;
        private static readonly bool    _defaultIsDrag = false;
        private static readonly int     _defaultDragSpeed = 1;

        /// <summary>
        /// Check if every data needed to create an ActionClick are in specs
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
        public static (ActionClick actionClick, string errorMessage) CreateAction(string click, int x1, int y1, int x2, int y2, bool isDoubleClick, bool isDrag, int dragSpeed)
        {
            string errorMessage = string.Empty;

            if (!ValidateClick(click, out string error))
            {
                errorMessage += error + "\r\n";
                click = _defaultClick;
            }

            int[] array2 = { x1, x2, y1, y2 };
            if (!ValidateCoord(array2, out error))
            {
                errorMessage += error + "\r\n";
                x1 = _defaultX1;
                x2 = _defaultX2;
                y1 = _defaultY1;
                y2 = _defaultY2;
            }

            if(!ValidateDragSpeed(dragSpeed, out error))
            {
                errorMessage += error;
                dragSpeed = _defaultDragSpeed;
            }

            ActionClick actionClick = new ActionClick(click, x1, y1, x2, y2, isDoubleClick, isDrag, dragSpeed);

            return (actionClick, errorMessage);
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

        public static (ActionClick action, string errorMessage) GetActionFromControl(ActionClickPanel panel)
        {
            var (actionClick, errorMessage) = CreateAction(panel.SelectedClick, panel.X1, panel.Y1, panel.X2, panel.Y2, panel.IsDoubleClick, panel.IsDrag, panel.DragSpeed);

            return (actionClick, errorMessage);
        }

        public static (ActionClick action, string errorMessage) GetActionFromXElement(XElement xmlAction)
        {
            //Version ajusting and crash prevention
            int dragSpeed = _defaultDragSpeed;
            int x1 = _defaultX1, x2 = _defaultX2, y1 = _defaultY1, y2 = _defaultY2;
            if (xmlAction.Attribute("x") != null) x1 = Int32.Parse(xmlAction.Attribute("x").Value);
            if (xmlAction.Attribute("y") != null) y1 = Int32.Parse(xmlAction.Attribute("y").Value);
            if (xmlAction.Attribute("x2") != null) x2 = Int32.Parse(xmlAction.Attribute("x2").Value);
            if (xmlAction.Attribute("y2") != null) y2 = Int32.Parse(xmlAction.Attribute("y2").Value);
            if (xmlAction.Attribute("dragSpeed") != null) dragSpeed = Int32.Parse(xmlAction.Attribute("dragSpeed").Value);

            bool isDoubleClick = _defaultIsDoubleClick, isDrag = _defaultIsDrag;
            if (xmlAction.Attribute("isDoubleClick") != null)
                if (xmlAction.Attribute("isDoubleClick").Value == "true")
                    isDoubleClick = true;

            if (xmlAction.Attribute("isDrag") != null)
                if (xmlAction.Attribute("isDrag").Value == "true")
                    isDrag = true;

            string selectedClick = _defaultClick;
            if (xmlAction.Attribute("clic") != null)
                selectedClick = xmlAction.Attribute("clic").Value;

            var (actionSequence, errorMessage) = CreateAction(selectedClick.ToLower(), x1, y1, x2, y2, isDoubleClick, isDrag, dragSpeed);

            return (actionSequence, errorMessage);
        }
    }
}
