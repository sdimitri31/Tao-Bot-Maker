using System.Drawing;

namespace Tao_Bot_Maker.Model
{
    public class CustomItem<T>
    {
        public T Value { get; }
        public string DisplayName { get; }
        public Image Image { get; }

        public CustomItem(T value, string displayName, Image image = null)
        {
            Value = value;
            DisplayName = displayName;
            Image = image;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
