namespace Tao_Bot_Maker.Model
{
    public class ComboboxItemActionType
    {   
        public string DisplayText { get; set; }
        public object ActionTypeId { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
