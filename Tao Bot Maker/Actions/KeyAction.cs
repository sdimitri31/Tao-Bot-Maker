using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class KeyAction : BotAction
    {
        private ConsoleKey keyToPress;

        public KeyAction(ConsoleKey keyToPress)
        {
            this.keyToPress = keyToPress;
        }

        public override async Task Execute()
        {
            // Simulation d'appui sur une touche
            Console.WriteLine($"Pressing key: {keyToPress}");
            // Code pour simuler la pression de la touche
            await Task.Delay(100); // Exemple : attente de 100 ms
        }
    }
}
