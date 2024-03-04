using System;

namespace Tao_Bot_Maker
{
    public class ActionKey : Action
    {
        public ActionKey()
        {
            Type = (int) ActionType.Key;
        }
        public ActionKey(string key)
        {
            Type = (int)ActionType.Key;
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
