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
        public override ActionType Type { get; set; }
        public MouseActionType ClickType { get; set; }
        public bool DoubleClick { get; set; }
        public bool Scroll { get; set; }
        public bool DragAndDrop { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public bool UseImageCoordsAsStart { get; set; }
        public bool UseImageCoordsAsEnd { get; set; }
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
            bool useImageCoordsAsStart = false,
            bool useImageCoordsAsEnd = false,
            bool useCurrentPosition = false,
            int? endX = null,
            int? endY = null,
            string moveSpeed = "Medium",
            int scrollAmount = 0,
            int clickDuration = 0)
        {
            Type = ActionType.MouseAction;
            ClickType = clickType;
            DoubleClick = doubleClick;
            Scroll = scroll;
            DragAndDrop = dragAndDrop;
            StartX = startX;
            StartY = startY;
            UseImageCoordsAsStart = useImageCoordsAsStart;
            UseImageCoordsAsEnd = useImageCoordsAsEnd;
            UseCurrentPosition = useCurrentPosition;
            EndX = endX;
            EndY = endY;
            MoveSpeed = moveSpeed;
            ScrollAmount = scrollAmount;
            ClickDuration = clickDuration;
            mouseSimulator = new MouseSimulator();
        }
        public override async Task Execute()
        {
            await Execute(0, 0);
        }

        public override async Task Execute(int x, int y)
        {
            int startX, startY;
            if (UseImageCoordsAsStart)
            {
                startX = x;
                startY = y;
            }
            else
            {
                startX = UseCurrentPosition ? Cursor.Position.X : StartX;
                startY = UseCurrentPosition ? Cursor.Position.Y : StartY;
            }

            // Set the end coordinates for drag and drop or move actions
            int? endX, endY;
            if (UseImageCoordsAsEnd)
            {
                endX = x;
                endY = y;
            }
            else
            {
                endX = EndX.HasValue ? EndX.Value : (int?)null;
                endY = EndY.HasValue ? EndY.Value : (int?)null;
            }

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

            // Move to start position if not using current position
            if (!UseCurrentPosition)
            {
                Logger.Log($"Moving cursor to ({startX}, {startY})");
                await mouseSimulator.Move(startX, startY, moveSpeed);
            }

            // Perform the mouse action
            if (Scroll)
            {
                Logger.Log($"Scrolling by {ScrollAmount}");
                await mouseSimulator.Scroll(ScrollAmount, ClickDuration);
            }
            else if (DragAndDrop && endX.HasValue && endY.HasValue)
            {
                Logger.Log($"Drag and drop from ({startX}, {startY}) to ({endX.Value}, {endY.Value})");
                await mouseSimulator.DragAndDrop(startX, startY, endX.Value, endY.Value, moveSpeed, ClickDuration);
            }
            else if (ClickType != MouseActionType.NoClick)
            {
                Logger.Log($"Performing {ClickType} click");
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
        }

        public override string ToString()
        {
            // Affiche les informations de l'action de la souris
            return $"Mouse action: {ClickType} ({StartX}, {StartY}) -> ({EndX}, {EndY})";
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

        public override void Update(Action newAction)
        {
            base.Update(newAction);
            var newMouseAction = newAction as MouseAction;
            if (newMouseAction != null)
            {
                this.ClickType = newMouseAction.ClickType;
                this.StartX = newMouseAction.StartX;
                this.StartY = newMouseAction.StartY;
                this.EndX = newMouseAction.EndX;
                this.EndY = newMouseAction.EndY;
                this.DragAndDrop = newMouseAction.DragAndDrop;
                this.DoubleClick = newMouseAction.DoubleClick;
                this.Scroll = newMouseAction.Scroll;
                this.ScrollAmount = newMouseAction.ScrollAmount;
                this.ClickDuration = newMouseAction.ClickDuration;
                this.UseCurrentPosition = newMouseAction.UseCurrentPosition;
                this.UseImageCoordsAsStart = newMouseAction.UseImageCoordsAsStart;
                this.UseImageCoordsAsEnd = newMouseAction.UseImageCoordsAsEnd;
                this.MoveSpeed = newMouseAction.MoveSpeed;
            }
        }
    }
}
