using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class WaitAction : BotAction
    {
        private int milliseconds;

        public WaitAction(int milliseconds)
        {
            this.milliseconds = milliseconds;
        }

        public override async Task Execute()
        {
            // Attente du nombre de millisecondes spécifié
            await Task.Delay(milliseconds);
            Console.WriteLine($"Wait action executed for {milliseconds} ms.");
        }
    }
}
