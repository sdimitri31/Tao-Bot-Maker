using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public abstract class Action
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract ActionType Type { get; set; }

        public abstract Task Execute(CancellationToken token, int x = 0, int y = 0);

        public abstract bool Validate(out string errorMessage);

        public abstract override String ToString();

        public virtual void Update(Action newAction)
        {
            this.Type = newAction.Type;
        }
    }
}
