using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class ImageAction : BotAction
    {
        private string imageFilePath;

        public ImageAction(string imageFilePath)
        {
            this.imageFilePath = imageFilePath;
        }

        public override async Task Execute()
        {
            // Recherche et action basée sur une image
            // Exemple : recherche et clic sur l'image
            Console.WriteLine($"Searching for image: {imageFilePath}");
            await Task.Delay(100); // Exemple : attente de 100 ms
        }
    }
}
