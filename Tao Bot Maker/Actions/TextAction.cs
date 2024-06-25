using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class TextAction : BotAction
    {
        private string textToType;

        public TextAction(string textToType)
        {
            this.textToType = textToType;
        }

        public override async Task Execute()
        {
            // Simulation de la saisie de texte
            Console.WriteLine($"Typing text: {textToType}");
            // Code pour simuler la frappe au clavier
            await Task.Delay(100); // Exemple : attente de 100 ms
        }
    }
}
