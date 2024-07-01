using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

[JsonConverter(typeof(StringEnumConverter))]
public enum ActionType
{
    CorruptAction = -1,
    MouseAction,
    WaitAction,
    TextAction,
    KeyAction,
    SequenceAction,
    ImageAction
}
