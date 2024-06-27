﻿using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public abstract class Action
    {
        public abstract ActionType Type { get; set; }

        public abstract Task Execute();
        public abstract Task Execute(int x, int y);

        public abstract bool Validate(out string errorMessage);

        public abstract override String ToString();

        public virtual void Update(Action newAction)
        {
            this.Type = newAction.Type;
        }
    }
}
