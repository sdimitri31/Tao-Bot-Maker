using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    // Classe de base abstraite pour les actions du bot
    public abstract class BotAction
    {
        // Méthode abstraite pour exécuter l'action
        public abstract Task Execute();

        // Méthode abstraite pour annuler l'action (optionnelle)
        public virtual void Cancel()
        {
            // Par défaut, aucune action d'annulation définie
        }
    }
}
