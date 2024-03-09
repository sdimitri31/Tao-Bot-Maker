using System;

namespace Tao_Bot_Maker
{
    public class ActionKey : Action
    {
        public ActionKey(string errorMessage = "")
        {
            Type = (int) ActionType.Key;
            ErrorMessage = errorMessage;
        }
        public ActionKey(string key, string errorMessage = "")
        {
            Type = (int)ActionType.Key;
            ErrorMessage = errorMessage;
            Key = key;
        }

        public string Key { get; set; }

        public override string ToString()
        {
            string text = "";
            text +=         Properties.strings.action + " : " + Properties.strings.ActionName_Key;
            text += " | " + Properties.strings.action_Member_Key + " : " + Key;

            return text;
        }
    }
}
