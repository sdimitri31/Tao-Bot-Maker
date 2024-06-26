using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public abstract class Action
    {
        public abstract string ActionType { get; set; }

        public abstract Task Execute();

        public abstract bool Validate(out string errorMessage);

        public abstract override String ToString();
    }
}
