using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao_Bot_Maker.Helpers;

namespace Tao_Bot_Maker.Model
{
    [JsonConverter(typeof(ActionConverter))]
    public class MouseAction : Action
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MouseActionType
        {
            LeftClick,
            RightClick,
            MiddleClick,
            NoClick
        }


        [JsonConverter(typeof(StringEnumConverter))]
        public override ActionType Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MouseActionType ClickType { get; set; }
        public bool DoubleClick { get; set; }
        public bool Scroll { get; set; }
        public bool DragAndDrop { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public bool UseImageCoordsAsStart { get; set; }
        public bool UseImageCoordsAsEnd { get; set; }
        public bool UseCurrentPosition { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int MoveSpeed { get; set; }
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
            int endX = 0,
            int endY = 0,
            int moveSpeed = 2,
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

        public override async Task Execute(CancellationToken token, int x, int y)
        {
            token.ThrowIfCancellationRequested();

            if (UseImageCoordsAsStart)
            {
                StartX = x;
                StartY = y;
            }
            else
            {
                StartX = UseCurrentPosition ? Cursor.Position.X : StartX;
                StartY = UseCurrentPosition ? Cursor.Position.Y : StartY;
            }

            // Set the end coordinates for drag and drop
            if (UseImageCoordsAsEnd)
            {
                EndX = x;
                EndY = y;
            }

            string executeAction = string.Format(Resources.Strings.InfoMessageExecuteAction, this.ToString());
            Logger.Log(executeAction);

            if (!Validate(out string errorMessage))
            {
                throw new Exception(errorMessage);
            }

            // Determine the move speed
            int moveSpeed;
            switch (MoveSpeed)
            {
                case 0:
                    moveSpeed = 30;
                    break;
                case 1:
                    moveSpeed = 10;
                    break;
                case 2:
                    moveSpeed = 5;
                    break;
                default:
                    moveSpeed = 10;
                    break;
            }

            // Move to start position if not using current position
            if (!UseCurrentPosition)
            {
                await mouseSimulator.Move(StartX, StartY, moveSpeed);
            }

            // Perform the mouse action
            if (Scroll)
            {
                await mouseSimulator.Scroll(ScrollAmount, ClickDuration);
            }
            else if (DragAndDrop)
            {
                switch (ClickType)
                {
                    case MouseActionType.LeftClick:
                        await mouseSimulator.DragAndDropLeftClick(StartX, StartY, EndX, EndY, moveSpeed, ClickDuration);
                        break;
                    case MouseActionType.RightClick:
                        await mouseSimulator.DragAndDropRightClick(StartX, StartY, EndX, EndY, moveSpeed, ClickDuration);
                        break;
                    case MouseActionType.MiddleClick:
                        await mouseSimulator.DragAndDropMiddleClick(StartX, StartY, EndX, EndY, moveSpeed, ClickDuration);
                        break;
                    case MouseActionType.NoClick:
                        await mouseSimulator.Move(EndX, EndY, moveSpeed);
                        break;
                }
            }
            else if (ClickType != MouseActionType.NoClick)
            {
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
            string actionDescription = "";

            if (Scroll)
            {
                string scrollBy = String.Format(Resources.Strings.MouseActionToStringScrollBy, ScrollAmount);
                string atCoords = String.Format(Resources.Strings.MouseActionToStringAtCoordinates);
                string coords = string.Format(Resources.Strings.CoordinatesFormat, StartX, StartY);
                actionDescription += $"{scrollBy} {atCoords} {coords}";
            }
            else if (DragAndDrop)
            {
                string startCoords = string.Format(Resources.Strings.CoordinatesFormat, StartX, StartY);
                string endCoords = string.Format(Resources.Strings.CoordinatesFormat, EndX, EndY);
                string dragAndDrop = String.Format(Resources.Strings.MouseActionToStringDragAndDropFrom, startCoords, endCoords);
                actionDescription += dragAndDrop;
            }
            else
            {
                string doubleWord = Resources.Strings.MouseActionToStringDouble;
                string clickType = DoubleClick ? $"{doubleWord} " : "";
                actionDescription += $"{clickType}{ClickType}";

                if (UseCurrentPosition)
                {
                    actionDescription += " " + Resources.Strings.MouseActionToStringAtCurrentPosition;
                }
                else if (UseImageCoordsAsStart)
                {
                    actionDescription += " " + Resources.Strings.MouseActionToStringAtImageCoordinates;
                }
                else
                {
                    string startCoords = string.Format(Resources.Strings.CoordinatesFormat, StartX, StartY);
                    string atCoords = String.Format(Resources.Strings.MouseActionToStringAtCoordinates);
                    actionDescription += $" {atCoords} {startCoords}";
                }
            }

            return actionDescription;
        }

        public override bool Validate(out string errorMessage)
        {
            int[] coords = new int[] { StartX, StartY, EndX, EndY };

            foreach (int coord in coords)
            {
                if ((coord < -999999) || (coord > 999999))
                {
                    errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidIntervalFor, Resources.Strings.Coordinates, 0, 2);
                    return false;
                }
            }

            if (!Enum.IsDefined(typeof(MouseActionType), ClickType))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidValueFor, Resources.Strings.LabelClickType);
                return false;
            }

            if ((MoveSpeed < 0) || (MoveSpeed > 2))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidIntervalFor, Resources.Strings.LabelSpeed, 0, 2);
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
