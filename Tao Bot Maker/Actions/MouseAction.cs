using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class MouseAction : BotAction
    {
        public override async Task Execute()
        {
            // Implémentation spécifique pour l'action de la souris
            await Task.Delay(100); // Exemple : attente de 100 ms
            Console.WriteLine("Mouse action executed.");
        }
    }
}
