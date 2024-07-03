namespace Tao_Bot_Maker.Model
{
    public class ActionTypeItem
    {
        public ActionType Type { get; }
        public string DisplayName { get; }

        public ActionTypeItem(ActionType type, string displayName)
        {
            Type = type;
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
