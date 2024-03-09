using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

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
        private static readonly bool    _defaultIsCurrentPosClick = false;
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
        public static ActionClick CreateAction(string click, int x1, int y1, int x2, int y2, bool isDoubleClick, bool isDrag, int dragSpeed, bool isCurrentPosClick)
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

            ActionClick action = new ActionClick(click, x1, y1, x2, y2, isDoubleClick, isDrag, dragSpeed, isCurrentPosClick, errorMessage);

            return action;
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
                    Log.Write("ValidateCoord(" + coord + ") Result : false", Log.ERROR);
                    return false;
                }
                coordsList += coord + ", ";
            }

            Log.Write("ValidateCoord(" + coordsList + ") Result : true", Log.TRACE);
            return true;
        }

        private static bool ValidateClick(string click, out string errorMessage)
        {
            errorMessage = "";

            if ((click != null) && ((click == "left") || (click == "middle") || (click == "right") || (click == "move")))
            {
                Log.Write("ValidateClick(" + click + ") Result : true", Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_ClickNotSelected;
                Log.Write("ValidateClick(" + click + ") Result : false", Log.ERROR);
                return false;
            }
        }

        private static bool ValidateDragSpeed(int dragSpeed, out string errorMessage)
        {
            errorMessage = "";

            if ((dragSpeed >= 1) && (dragSpeed <= 5))
            {
                Log.Write("ValidateDragSpeed(" + dragSpeed + ") Result : true", Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_DragSpeedWrongInterval;
                Log.Write("ValidateDragSpeed(" + dragSpeed + ") Result : false", Log.ERROR);
                return false;
            }
        }

        public static ActionClick GetActionFromControl(ActionClickPanel panel)
        {
            ActionClick action = CreateAction(panel.SelectedClick, panel.X1, panel.Y1, panel.X2, panel.Y2, panel.IsDoubleClick, panel.IsDrag, panel.DragSpeed, panel.IsCurrentPosClick);

            return action;
        }

        public static ActionClick GetActionFromXElement(XElement xmlAction)
        {
            //Version ajusting and crash prevention
            string errors = string.Empty;

            string selectedClick = _defaultClick;
            if (xmlAction.Attribute("clic") != null)
            {
                selectedClick = xmlAction.Attribute("clic").Value.ToLower();
            }
            else
            {
                errors += Properties.strings.action_Member_Click + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int x1 = _defaultX1;
            if (xmlAction.Attribute("x") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("x").Value, out x1))
                {
                    errors += Properties.strings.action_Member_X1 + " : " +
                        Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_X1 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int y1 = _defaultY1;
            if (xmlAction.Attribute("y") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("y").Value, out y1))
                {
                    errors += Properties.strings.action_Member_Y1 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_Y1 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int x2 = _defaultX2;
            if (xmlAction.Attribute("x2") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("x2").Value, out x2))
                {
                    errors += Properties.strings.action_Member_X2 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_X2 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int y2 = _defaultY2;
            if (xmlAction.Attribute("y2") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("y2").Value, out y2))
                {
                    errors += Properties.strings.action_Member_Y2 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_Y2 + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int dragSpeed = _defaultDragSpeed;
            if (xmlAction.Attribute("dragSpeed") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("dragSpeed").Value, out dragSpeed))
                {
                    errors += Properties.strings.action_Member_DragSpeed + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_DragSpeed + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            bool isDoubleClick = _defaultIsDoubleClick;
            if (xmlAction.Attribute("isDoubleClick") != null)
            {
                if (xmlAction.Attribute("isDoubleClick").Value.ToLower() == "true")
                    isDoubleClick = true;
            }
            else
            {
                errors += Properties.strings.action_Member_IsDoubleClick + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            bool isDrag = _defaultIsDrag;
            if (xmlAction.Attribute("isDrag") != null)
            {
                if (xmlAction.Attribute("isDrag").Value.ToLower() == "true")
                    isDrag = true;
            }
            else
            {
                errors += Properties.strings.action_Member_IsDrag + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            bool isCurrentPosClick = _defaultIsCurrentPosClick;
            if (xmlAction.Attribute("isCurrentPosClick") != null)
            {
                if (xmlAction.Attribute("isCurrentPosClick").Value.ToLower() == "true")
                    isCurrentPosClick = true;
            }
            else
            {
                errors += Properties.strings.action_Member_IsCurrentPosClick + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            ActionClick action = CreateAction(selectedClick, x1, y1, x2, y2, isDoubleClick, isDrag, dragSpeed, isCurrentPosClick);

            action.ErrorMessage = errors + action.ErrorMessage;

            return action;
        }
    }
}
