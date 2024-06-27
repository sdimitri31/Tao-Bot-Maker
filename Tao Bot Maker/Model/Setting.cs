
namespace Tao_Bot_Maker.Model
{
    public class Setting
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public SettingsType Type { get; set; }

        public Setting() { }

        public Setting(string name, string value, SettingsType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
    }
}
