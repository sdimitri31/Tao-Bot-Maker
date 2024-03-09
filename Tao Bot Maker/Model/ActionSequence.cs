namespace Tao_Bot_Maker
{
    /// <summary>
    /// DEPRECATED DO NOT USE
    /// </summary>
    public class ActionSequence : Action
    {
        public ActionSequence(string errorMessage = "")
        {
            Type = (int)DeprecatedActionType.Sequence;
            ErrorMessage = errorMessage;
        }

        public ActionSequence(string sequenceName, string errorMessage = "")
        {
            Type = (int)DeprecatedActionType.Sequence;
            ErrorMessage= errorMessage;
            SequenceName = sequenceName;
        }
        public string SequenceName { get; set; }

        public override string ToString()
        {
            string text = Properties.strings.action_ErrorMessage_DeprecatedType;
            text += " | " + Properties.strings.action + " : " + Properties.strings.ActionName_Sequence;
            text += " | " + Properties.strings.action_Member_Sequence + " : " + SequenceName;
            
            return text;
        }
    }
}
