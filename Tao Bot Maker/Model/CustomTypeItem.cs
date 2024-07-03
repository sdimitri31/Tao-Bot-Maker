namespace Tao_Bot_Maker.Model
{
    public class DisplayItem<T>
    {
        public T Value { get; }
        public string DisplayName { get; }

        public DisplayItem(T value, string displayName)
        {
            Value = value;
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
