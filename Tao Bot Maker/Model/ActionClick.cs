using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker
{
    class ActionClick : Action
    {
        public ActionClick()
        {
            Type = (int)ActionType.Click;
        }
        public ActionClick(String click, int x, int y)
        {
            Type = (int)ActionType.Click;
            SelectedClick = click;
            X = x;
            Y = y;
        }

        public String SelectedClick { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return "Action Clic; Clic : " + SelectedClick + "; X : " + X + "; Y : " + Y;
        }
    }
}
