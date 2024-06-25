using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class SequenceAction : BotAction
    {
        private BotAction[] actions;
        private int repeatCount;

        public SequenceAction(BotAction[] actions, int repeatCount = 1)
        {
            this.actions = actions;
            this.repeatCount = repeatCount;
        }

        public override async Task Execute()
        {
            // Exécute chaque action dans la séquence le nombre de fois spécifié
            for (int i = 0; i < repeatCount; i++)
            {
                foreach (var action in actions)
                {
                    await action.Execute();
                }
            }
        }
    }
}
