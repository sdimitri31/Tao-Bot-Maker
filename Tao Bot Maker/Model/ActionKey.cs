using System;

namespace Tao_Bot_Maker
{
    class ActionKey : Action
    {
        public ActionKey()
        {
            Type = (int) ActionType.Key;
        }
        public ActionKey(String key)
        {
            Type = (int)ActionType.Key;
            Key = key;
        }

        public String Key { get; set; }

        public override string ToString()
        {
            return "Action Touche; Touche : " + Key;
        }
    }
}
