using LogFramework;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;
using static System.Windows.Forms.LinkLabel;

namespace Tao_Bot_Maker.Model
{
    public class MouseAction : Action
    {
        public enum MouseActionType
        {
            LeftClick,
            RightClick,
            MiddleClick,
            NoClick
        }
        public override string ActionType { get; set; }
        public MouseActionType ClickType { get; set; }
        public bool DoubleClick { get; set; }
        public bool Scroll { get; set; }
        public bool DragAndDrop { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public bool UseCurrentPosition { get; set; }
        public int? EndX { get; set; }
        public int? EndY { get; set; }
        public string MoveSpeed { get; set; }
        public int ScrollAmount { get; set; }
        public int ClickDuration { get; set; }

        private readonly MouseSimulator mouseSimulator;

        public MouseAction(
            MouseActionType clickType = MouseActionType.LeftClick,
            bool doubleClick = false,
            bool scroll = false,
            bool dragAndDrop = false,
            int startX = 0,
            int startY = 0,
            bool useCurrentPosition = false,
            int? endX = null,
            int? endY = null,
            string moveSpeed = "Medium",
            int scrollDuration = 0,
            int clickDuration = 0)
        {
            ActionType = ActionTypes.MouseAction.ToString();
            ClickType = clickType;
            DoubleClick = doubleClick;
            Scroll = scroll;
            DragAndDrop = dragAndDrop;
            StartX = startX;
            StartY = startY;
            UseCurrentPosition = useCurrentPosition;
            EndX = endX;
            EndY = endY;
            MoveSpeed = moveSpeed;
            ScrollAmount = scrollDuration;
            ClickDuration = clickDuration;
            mouseSimulator = new MouseSimulator();
        }

        public override async Task Execute()
        {
            int startX = UseCurrentPosition ? Cursor.Position.X : StartX;
            int startY = UseCurrentPosition ? Cursor.Position.Y : StartY;

            // Set the end coordinates for drag and drop or move actions
            int? endX = EndX.HasValue ? EndX.Value : (int?)null;
            int? endY = EndY.HasValue ? EndY.Value : (int?)null;

            // Determine the move speed
            int moveSpeed;
            switch (MoveSpeed.ToLower())
            {
                case "slow":
                    moveSpeed = 30;
                    break;
                case "medium":
                    moveSpeed = 10;
                    break;
                case "fast":
                    moveSpeed = 5;
                    break;
                default:
                    moveSpeed = 10;
                    break;
            }

            // Perform the mouse action
            if (Scroll)
            {
                await mouseSimulator.Scroll(ScrollAmount, ClickDuration);
            }
            else if (DragAndDrop && endX.HasValue && endY.HasValue)
            {
                await mouseSimulator.DragAndDrop(startX, startY, endX.Value, endY.Value, moveSpeed, ClickDuration);
            }
            else if (ClickType != MouseActionType.NoClick)
            {
                // Move to start position if not using current position
                if (!UseCurrentPosition)
                {
                    await mouseSimulator.Move(startX, startY, moveSpeed);
                }

                // Perform the click
                if (DoubleClick)
                {
                    switch (ClickType)
                    {
                        case MouseActionType.LeftClick:
                            await mouseSimulator.DoubleClick(ClickDuration);
                            break;
                        case MouseActionType.RightClick:
                            await mouseSimulator.RightClick(ClickDuration);
                            await Task.Delay(mouseSimulator.GetRandomDelay(ClickDuration));
                            await mouseSimulator.RightClick(ClickDuration);
                            break;
                        case MouseActionType.MiddleClick:
                            await mouseSimulator.MiddleClick(ClickDuration);
                            await Task.Delay(mouseSimulator.GetRandomDelay(ClickDuration));
                            await mouseSimulator.MiddleClick(ClickDuration);
                            break;
                    }
                }
                else
                {
                    switch (ClickType)
                    {
                        case MouseActionType.LeftClick:
                            await mouseSimulator.LeftClick(ClickDuration);
                            break;
                        case MouseActionType.RightClick:
                            await mouseSimulator.RightClick(ClickDuration);
                            break;
                        case MouseActionType.MiddleClick:
                            await mouseSimulator.MiddleClick(ClickDuration);
                            break;
                    }
                }
            }
            else if (endX.HasValue && endY.HasValue)
            {
                // Move without clicking
                await mouseSimulator.Move(endX.Value, endY.Value, moveSpeed);
            }
        }


        public override string ToString()
        {
            // Affiche les informations de l'action de la souris
            return $"Mouse action: {ActionType} ({StartX}, {StartY}) -> ({EndX}, {EndY})";
        }

        public override bool Validate(out string errorMessage)
        {
            int[] coords = new int[] { StartX, StartY, (int)EndX, (int)EndY };

            foreach (int coord in coords)
            {
                if ((coord < -999999) || (coord > 999999))
                {
                    errorMessage = "Coordinates must be between -999999 and 999999.";
                    return false;
                }
            }

            if (!Enum.IsDefined(typeof(MouseActionType), ClickType))
            {
                errorMessage = "ClickType must be MouseActionType.";
                return false;
            }

            if (string.IsNullOrEmpty(MoveSpeed))
            {
                errorMessage = "Typing speed cannot be empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
