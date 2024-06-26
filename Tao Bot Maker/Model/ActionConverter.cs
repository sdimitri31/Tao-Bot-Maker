using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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
            JObject jsonObject = JObject.Load(reader);
            string actionType = jsonObject["ActionType"].ToString();
            Action target = null;

            switch (actionType)
            {
                case "MouseAction":
                    target = new MouseAction();
                    break;
                //case "WaitAction":
                //    target = new WaitAction();
                //    break;
                case "TextAction":
                    target = new TextAction();
                    break;
                //case "KeyAction":
                //    target = new KeyAction();
                //    break;
                //case "SequenceAction":
                //    target = new SequenceAction();
                //    break;
                //case "ImageAction":
                //    target = new ImageAction();
                //    break;
            }  

            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jsonObject = new JObject();
            JToken token = JToken.FromObject(value, serializer);
            jsonObject.Add("ActionType", JToken.FromObject(value.GetType().Name));
            jsonObject.Merge(token);
            jsonObject.WriteTo(writer);
        }
    }
}
