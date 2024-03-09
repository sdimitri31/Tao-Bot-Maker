
using System.Windows.Forms;
using System.Xml.Linq;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.View;

namespace Tao_Bot_Maker
{
    public class ActionWaitController
    {
        //Default values
        private static readonly int _defaultWaitTime = 0;
        private static readonly int _defaultWaitTimeMax = 1;
        private static readonly bool _defaultIsRandomInterval = false;

        public static ActionWait CreateAction(int waitTime, int waitTimeMax, bool isRandomInterval)
        {
            string errorMessage = string.Empty;

            if (!ValidateWaitTime(waitTime, out string error))
            {
                errorMessage += error + "\r\n";
                waitTime = _defaultWaitTime;
            }

            if(isRandomInterval)
                if (!ValidateWaitTimeMax(waitTimeMax, waitTime, out error))
                {
                    errorMessage += error + "\r\n";
                    waitTimeMax = _defaultWaitTimeMax;
                }

            return new ActionWait(waitTime, waitTimeMax, isRandomInterval, errorMessage);
        }

        private static bool ValidateWaitTime(int waitTime, out string errorMessage)
        {
            errorMessage = string.Empty;

            if ((waitTime >= 0) && (waitTime <= 2147483646))
            {
                Log.Write("ValidateWaitTime(" + waitTime + ") Result : true", Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_WaitTime;
                Log.Write("ValidateWaitTime(" + waitTime + ") Result : false", Log.ERROR);
                return false;
            }
        }
        
        private static bool ValidateWaitTimeMax(int waitTimeMax, int waitTime, out string errorMessage)
        {
            errorMessage = string.Empty;

            if ((waitTimeMax >= 0) && (waitTimeMax <= 2147483646) && (waitTime < waitTimeMax))
            {
                Log.Write("ValidateWaitTimeMax(" + waitTimeMax + ") Result : true", Log.TRACE);
                return true;
            }
            else
            {
                errorMessage = Properties.strings.action_ErrorMessage_WaitTimeMax;
                Log.Write("ValidateWaitTimeMax(" + waitTimeMax + ") Result : false", Log.ERROR);
                return false;
            }
        }

        private static int ConvertWaitTimeInMS(int waitTime, string unit)
        {
            switch(unit)
            {
                case "ms":
                    return waitTime;
                case "s":
                    return waitTime * 1000;
                case "min":
                    return waitTime * 1000 * 60;
                case "h":
                    return waitTime * 1000 * 60 * 60;
                default: return waitTime;
            }
        }

        public static ActionWait GetActionFromControl(ActionWaitPanel panel)
        {
            int waitTimeInMS = ConvertWaitTimeInMS(panel.WaitTime, panel.WaitTimeUnit);
            int waitTimeMaxInMS = ConvertWaitTimeInMS(panel.WaitTimeMax, panel.WaitTimeMaxUnit);

            ActionWait action = CreateAction(waitTimeInMS, waitTimeMaxInMS, panel.IsRandomInterval);

            return action;
        }

        public static ActionWait GetActionFromXElement(XElement xmlAction)
        {
            //Version ajusting and crash prevention
            string errors = string.Empty;

            int waitTime = _defaultWaitTime;
            if (xmlAction.Attribute("waitTime") == null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Value, out waitTime))
                {
                    errors += Properties.strings.action_Member_WaitTime + " : " +
                        Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else if (xmlAction.Attribute("waitTime") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("waitTime").Value, out waitTime))
                {
                    errors += Properties.strings.action_Member_WaitTime + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_WaitTime + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            int waitTimeMax = _defaultWaitTimeMax;
            if (xmlAction.Attribute("waitTimeMax") != null)
            {
                //If parsing error
                if (!int.TryParse(xmlAction.Attribute("waitTimeMax").Value, out waitTimeMax))
                {
                    errors += Properties.strings.action_Member_WaitTimeMax + " : " +
                    Properties.strings.action_ErrorMessage_AttributeParsingError + " \r\n";
                }
            }
            else
            {
                errors += Properties.strings.action_Member_WaitTimeMax + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            bool isRandomInterval = _defaultIsRandomInterval;
            if (xmlAction.Attribute("isRandomInterval") != null)
            {
                if (xmlAction.Attribute("isRandomInterval").Value.ToLower() == "true")
                    isRandomInterval = true;
            }
            else
            {
                errors += Properties.strings.action_Member_IsRandomInterval + " : " +
                    Properties.strings.action_ErrorMessage_AttributeNotFound + " \r\n";
            }

            ActionWait action = CreateAction(waitTime, waitTimeMax, isRandomInterval);

            action.ErrorMessage = errors + action.ErrorMessage;

            return action;
        }

    }
}
