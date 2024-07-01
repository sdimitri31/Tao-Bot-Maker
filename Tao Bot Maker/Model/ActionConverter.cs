using BlueMystic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace Tao_Bot_Maker.Model
{
    public class ActionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Action).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Action target = new CorruptedAction();

            try
            {
                JObject jsonObject = JObject.Load(reader);
                if (!ValidateJson(jsonObject, out string errorMessage))
                {
                    Console.WriteLine($"Validation failed: {errorMessage}");
                    return target;
                }

                ActionType type = (ActionType)Enum.Parse(typeof(ActionType), jsonObject["Type"].ToString());

                switch (type)
                {
                    case ActionType.MouseAction:
                        target = new MouseAction();
                        break;
                    case ActionType.WaitAction:
                        target = new WaitAction();
                        break;
                    case ActionType.TextAction:
                        target = new TextAction();
                        break;
                    case ActionType.KeyAction:
                        target = new KeyAction();
                        break;
                    case ActionType.SequenceAction:
                        target = new SequenceAction();
                        break;
                    case ActionType.ImageAction:
                        target = new ImageAction();
                        break;
                    default:
                        return target;
                }

                serializer.Populate(jsonObject.CreateReader(), target);
                return target;
            }
            catch
            {
                return target;
            }

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "The value to serialize cannot be null.");
            }

            JObject jsonObject = new JObject();

            foreach (var prop in value.GetType().GetProperties())
            {
                if (prop.CanRead)
                {
                    var propValue = prop.GetValue(value);
                    jsonObject.Add(prop.Name, propValue != null ? JToken.FromObject(propValue, serializer) : JValue.CreateNull());
                }
            }

            jsonObject.WriteTo(writer);
        }

        private bool ValidateJson(JObject jsonObject, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Check if 'Type' property is present
            if (jsonObject["Type"] == null)
            {
                errorMessage = "Missing 'Type' property";
                return false;
            }

            // Validate the ActionType
            string actionType = jsonObject["Type"].ToString();
            if (!Enum.TryParse<ActionType>(actionType, out var typeObj))
            {
                errorMessage = $"Invalid 'Type' property value: {actionType}";
                return false;
            }

            ActionType type = (ActionType)typeObj;

            // Validate properties based on the ActionType
            switch (type)
            {
                case ActionType.ImageAction:
                    return ValidateImageAction(jsonObject, out errorMessage);
                case ActionType.TextAction:
                    return ValidateTextAction(jsonObject, out errorMessage);
                case ActionType.WaitAction:
                    return ValidateWaitAction(jsonObject, out errorMessage);
                case ActionType.SequenceAction:
                    return ValidateSequenceAction(jsonObject, out errorMessage);
                case ActionType.MouseAction:
                    return ValidateMouseAction(jsonObject, out errorMessage);
                case ActionType.KeyAction:
                    return ValidateKeyAction(jsonObject, out errorMessage);
                default:
                    errorMessage = $"Unknown action type: {actionType}";
                    return false;
            }
        }

        private bool ValidateImageAction(JObject jsonObject, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (jsonObject["ImageName"] == null ||
                jsonObject["StartX"] == null ||
                jsonObject["StartY"] == null ||
                jsonObject["EndX"] == null ||
                jsonObject["EndY"] == null ||
                jsonObject["Threshold"] == null ||
                jsonObject["Expiration"] == null)
            {
                errorMessage = "Missing required properties for ImageAction";
                return false;
            }

            if (!ValidateString(jsonObject["ImageName"], out errorMessage) ||
                !ValidateCoordinate(jsonObject["StartX"], out errorMessage) ||
                !ValidateCoordinate(jsonObject["StartY"], out errorMessage) ||
                !ValidateCoordinate(jsonObject["EndX"], out errorMessage) ||
                !ValidateCoordinate(jsonObject["EndY"], out errorMessage) ||
                !ValidateThreshold(jsonObject["Threshold"], out errorMessage) ||
                !ValidateExpiration(jsonObject["Expiration"], out errorMessage))
            {
                return false;
            }

            return true;
        }

        private bool ValidateTextAction(JObject jsonObject, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (jsonObject["TextToType"] == null || jsonObject["TypingSpeed"] == null)
            {
                errorMessage = "Missing required properties for TextAction";
                return false;
            }

            if (!ValidateString(jsonObject["TextToType"], out errorMessage) ||
                !ValidateInt(jsonObject["TypingSpeed"], 0, 1000, out errorMessage))
            {
                return false;
            }

            return true;
        }

        private bool ValidateWaitAction(JObject jsonObject, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (jsonObject["MinimumWait"] == null ||
                jsonObject["MaximumWait"] == null ||
                jsonObject["RandomizeWait"] == null)
            {
                errorMessage = "Missing required properties for WaitAction";
                return false;
            }

            if (!ValidateInt(jsonObject["MinimumWait"], 0, int.MaxValue, out errorMessage) ||
                !ValidateInt(jsonObject["MaximumWait"], 0, int.MaxValue, out errorMessage) ||
                !ValidateBool(jsonObject["RandomizeWait"], out errorMessage))
            {
                return false;
            }

            return true;
        }

        private bool ValidateSequenceAction(JObject jsonObject, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (jsonObject["SequenceName"] == null ||
                jsonObject["RepeatCount"] == null)
            {
                errorMessage = "Missing required properties for SequenceAction";
                return false;
            }

            if (!ValidateString(jsonObject["SequenceName"], out errorMessage) ||
                !ValidateInt(jsonObject["RepeatCount"], 0, int.MaxValue, out errorMessage))
            {
                return false;
            }

            return true;
        }

        private bool ValidateMouseAction(JObject jsonObject, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (jsonObject["ClickType"] == null ||
                jsonObject["DoubleClick"] == null ||
                jsonObject["Scroll"] == null ||
                jsonObject["DragAndDrop"] == null ||
                jsonObject["StartX"] == null ||
                jsonObject["StartY"] == null ||
                jsonObject["UseImageCoordsAsStart"] == null ||
                jsonObject["UseImageCoordsAsEnd"] == null ||
                jsonObject["UseCurrentPosition"] == null ||
                jsonObject["EndX"] == null ||
                jsonObject["EndY"] == null ||
                jsonObject["MoveSpeed"] == null ||
                jsonObject["ScrollAmount"] == null ||
                jsonObject["ClickDuration"] == null)
            {
                errorMessage = "Missing required properties for MouseAction";
                return false;
            }

            if (!ValidateEnum<MouseAction.MouseActionType>(jsonObject["ClickType"], out errorMessage) ||
                !ValidateBool(jsonObject["DoubleClick"], out errorMessage) ||
                !ValidateBool(jsonObject["Scroll"], out errorMessage) ||
                !ValidateBool(jsonObject["DragAndDrop"], out errorMessage) ||
                !ValidateCoordinate(jsonObject["StartX"], out errorMessage) ||
                !ValidateCoordinate(jsonObject["StartY"], out errorMessage) ||
                !ValidateBool(jsonObject["UseImageCoordsAsStart"], out errorMessage) ||
                !ValidateBool(jsonObject["UseImageCoordsAsEnd"], out errorMessage) ||
                !ValidateBool(jsonObject["UseCurrentPosition"], out errorMessage) ||
                !ValidateCoordinate(jsonObject["EndX"], out errorMessage) ||
                !ValidateCoordinate(jsonObject["EndY"], out errorMessage) ||
                !ValidateInt(jsonObject["MoveSpeed"], 0, int.MaxValue, out errorMessage) ||
                !ValidateInt(jsonObject["ScrollAmount"], int.MinValue, int.MaxValue, out errorMessage) ||
                !ValidateInt(jsonObject["ClickDuration"], 0, int.MaxValue, out errorMessage))
            {
                return false;
            }

            return true;
        }

        private bool ValidateKeyAction(JObject jsonObject, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (jsonObject["Key"] == null)
            {
                errorMessage = "Missing required properties for KeyAction";
                return false;
            }

            if (!int.TryParse(jsonObject["Key"].ToString(), out int keyInt))
            {
                errorMessage = "'Key' property is not a valid integer";
                return false;
            }

            if (!Helpers.KeyboardSimulator.IsValidKey(keyInt))
            {
                errorMessage = $"Invalid 'Key' value: {keyInt}";
                return false;
            }

            return true;
        }

        // Utility validation methods
        private bool ValidateString(JToken token, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (token.Type != JTokenType.String || string.IsNullOrEmpty(token.ToString()))
            {
                errorMessage = $"Invalid string value: {token}";
                return false;
            }
            return true;
        }

        private bool ValidateCoordinate(JToken token, out string errorMessage)
        {
            return ValidateInt(token, -999999, 999999, out errorMessage);
        }

        private bool ValidateThreshold(JToken token, out string errorMessage)
        {
            return ValidateInt(token, 0, 255, out errorMessage);
        }

        private bool ValidateExpiration(JToken token, out string errorMessage)
        {
            return ValidateInt(token, 0, 999999, out errorMessage);
        }

        private bool ValidateInt(JToken token, int minValue, int maxValue, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (token.Type != JTokenType.Integer || !int.TryParse(token.ToString(), out int value) || value < minValue || value > maxValue)
            {
                errorMessage = $"Invalid integer value: {token}";
                return false;
            }
            return true;
        }

        private bool ValidateBool(JToken token, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (token.Type != JTokenType.Boolean || !bool.TryParse(token.ToString(), out _))
            {
                errorMessage = $"Invalid boolean value: {token}";
                return false;
            }
            return true;
        }

        private bool ValidateEnum<TEnum>(JToken token, out string errorMessage) where TEnum : struct
        {
            errorMessage = string.Empty;
            if (token.Type != JTokenType.String || !Enum.TryParse<TEnum>(token.ToString(), out _))
            {
                errorMessage = $"Invalid enum value: {token}";
                return false;
            }
            return true;
        }

    }
}
