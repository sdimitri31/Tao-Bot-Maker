﻿namespace Tao_Bot_Maker
{
    public class ActionClick : Action
    {
        public ActionClick(string errorMessage = "")
        {
            Type = (int)ActionType.Click;
            ErrorMessage = errorMessage;
        }
        public ActionClick(string click, int x1, int y1, int x2, int y2, bool isDoubleClick, bool isDrag, int dragSpeed, bool isCurrentPosClick, string errorMessage = "")
        {
            Type = (int)ActionType.Click;
            ErrorMessage = errorMessage;
            SelectedClick = click;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            IsDoubleClick = isDoubleClick;
            IsDrag = isDrag;
            DragSpeed = dragSpeed;
            IsCurrentPosClick = isCurrentPosClick;
        }

        public string SelectedClick { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public bool IsCurrentPosClick { get; set; }
        public bool IsDoubleClick { get; set; }
        public bool IsDrag { get; set; }
        public int DragSpeed { get; set; }

        public override string ToString()
        {
            string text = "";
            text +=         Properties.strings.action + " : " + Properties.strings.ActionName_Click;
            text += " | " + Properties.strings.action_Member_Click + " : " + SelectedClick;
            text += " | " + Properties.strings.action_Member_X1 + " : " + X1;
            text += " | " + Properties.strings.action_Member_Y1 + " : " + Y1;
            text += " | " + Properties.strings.action_Member_X2 + " : " + X2;
            text += " | " + Properties.strings.action_Member_Y2 + " : " + Y2;
            text += " | " + Properties.strings.action_Member_IsCurrentPosClick + " : " + IsCurrentPosClick;
            text += " | " + Properties.strings.action_Member_IsDoubleClick + " : " + IsDoubleClick;
            text += " | " + Properties.strings.action_Member_IsDrag + " : " + IsDrag;
            text += " | " + Properties.strings.action_Member_DragSpeed + " : " + DragSpeed;

            return text;
        }
    }
}
