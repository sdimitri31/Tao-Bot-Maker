using System.Windows.Forms;

namespace Tao_Bot_Maker
{
    public class ActionKey : Action
    {
        public ActionKey(Keys key, string errorMessage = "")
        {
            Type = (int)ActionType.Key;
            ErrorMessage = errorMessage;
            Key = key;
        }

        public Keys Key { get; set; }

        public override string ToString()
        {
            string text = "";
            text +=         Properties.strings.action + " : " + Properties.strings.ActionName_Key;
            text += " | " + Properties.strings.action_Member_Key + " : " + Controller.Utils.GetFormatedKeysString(Key);

            return text;
        }
    }
}
