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
        public ActionClick(String click, int x1, int y1, int x2, int y2, bool isDoubleClick, bool isDrag, int dragSpeed)
        {
            Type = (int)ActionType.Click;
            SelectedClick = click;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            IsDoubleClick = isDoubleClick;
            IsDrag = isDrag;
            DragSpeed = dragSpeed;
        }

        public String SelectedClick { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public bool IsDoubleClick { get; set; }
        public bool IsDrag { get; set; }
        public int DragSpeed { get; set; }

        public override string ToString()
        {
            return "Action Clic; Clic : " + SelectedClick + "; X : " + X1 + "; Y : " + Y1 +
                "; X2 : " + X2 + "; Y2 : " + Y2 + "; IsDoubleClick : " + IsDoubleClick + "; IsDrag : " + IsDrag + "; DragSpeed : " + DragSpeed;
        }
    }
}
