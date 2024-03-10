namespace Tao_Bot_Maker
{
    public class ActionText : Action
    {
        public ActionText(string errorMessage = "")
        {
            Type = (int) ActionType.Text;
            ErrorMessage = errorMessage;
        }
        public ActionText(string text, string errorMessage = "")
        {
            Type = (int)ActionType.Text;
            ErrorMessage = errorMessage;
            Text = text;
        }

        public string Text { get; set; }

        public override string ToString()
        {
            string text = "";
            text +=         Properties.strings.action + " : " + Properties.strings.ActionName_Text;
            text += " | " + Properties.strings.action_Member_Text + " : " + Text;

            return text;
        }
    }
}
