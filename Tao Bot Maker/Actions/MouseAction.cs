using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Diagnostics;
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
        public enum MouseActionClickType
        {
            LeftClick,
            RightClick,
            MiddleClick,
            NoClick
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum MouseActionEventType
        {
            Click,
            DoubleClick,
            Scroll,
            DragAndDrop
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public override ActionType Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MouseActionClickType ClickType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MouseActionEventType EventType { get; set; }

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
            MouseActionClickType clickType = MouseActionClickType.LeftClick,
            MouseActionEventType eventType = MouseActionEventType.Click,
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
            EventType = eventType;
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
            if (EventType == MouseActionEventType.Scroll)
            {
                await mouseSimulator.Scroll(ScrollAmount, ClickDuration);
            }
            else if (EventType == MouseActionEventType.DragAndDrop)
            {
                switch (ClickType)
                {
                    case MouseActionClickType.LeftClick:
                        await mouseSimulator.DragAndDropLeftClick(StartX, StartY, EndX, EndY, moveSpeed, ClickDuration);
                        break;
                    case MouseActionClickType.RightClick:
                        await mouseSimulator.DragAndDropRightClick(StartX, StartY, EndX, EndY, moveSpeed, ClickDuration);
                        break;
                    case MouseActionClickType.MiddleClick:
                        await mouseSimulator.DragAndDropMiddleClick(StartX, StartY, EndX, EndY, moveSpeed, ClickDuration);
                        break;
                    case MouseActionClickType.NoClick:
                        await mouseSimulator.Move(EndX, EndY, moveSpeed);
                        break;
                }
            }
            else if (ClickType != MouseActionClickType.NoClick)
            {
                // Perform the click
                if (EventType == MouseActionEventType.DoubleClick)
                {
                    switch (ClickType)
                    {
                        case MouseActionClickType.LeftClick:
                            await mouseSimulator.DoubleClick(ClickDuration);
                            break;
                        case MouseActionClickType.RightClick:
                            await mouseSimulator.RightClick(ClickDuration);
                            await Task.Delay(mouseSimulator.GetRandomDelay(ClickDuration));
                            await mouseSimulator.RightClick(ClickDuration);
                            break;
                        case MouseActionClickType.MiddleClick:
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
                        case MouseActionClickType.LeftClick:
                            await mouseSimulator.LeftClick(ClickDuration);
                            break;
                        case MouseActionClickType.RightClick:
                            await mouseSimulator.RightClick(ClickDuration);
                            break;
                        case MouseActionClickType.MiddleClick:
                            await mouseSimulator.MiddleClick(ClickDuration);
                            break;
                    }
                }
            }
        }

        public override string ToString()
        {
            string actionDescription = "";

            if (EventType == MouseActionEventType.Scroll)
            {
                string scrollBy = String.Format(Resources.Strings.MouseActionToStringScrollBy, ScrollAmount);
                string atCoords = String.Format(Resources.Strings.MouseActionToStringAtCoordinates);
                string coords = string.Format(Resources.Strings.CoordinatesFormat, StartX, StartY);
                actionDescription += $"{scrollBy} {atCoords} {coords}";
            }
            else if (EventType == MouseActionEventType.DragAndDrop)
            {
                string startCoords = string.Format(Resources.Strings.CoordinatesFormat, StartX, StartY);
                string endCoords = string.Format(Resources.Strings.CoordinatesFormat, EndX, EndY);
                string dragAndDrop = String.Format(Resources.Strings.MouseActionToStringDragAndDropFrom, startCoords, endCoords);
                actionDescription += dragAndDrop;
            }
            else
            {
                string doubleWord = Resources.Strings.MouseActionToStringDouble;
                string clickType = EventType == MouseActionEventType.DoubleClick ? $"{doubleWord} " : "";
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
            Logger.Log($"Validating MouseAction", TraceEventType.Verbose);
            int[] coords = new int[] { StartX, StartY, EndX, EndY };

            foreach (int coord in coords)
            {
                if ((coord < -999999) || (coord > 999999))
                {
                    errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidIntervalFor, Resources.Strings.Coordinates, -999999, 999999);
                    return false;
                }
            }

            if (!Enum.IsDefined(typeof(MouseActionClickType), ClickType))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidValueFor, Resources.Strings.LabelClickType);
                return false;
            }

            if (!Enum.IsDefined(typeof(MouseActionEventType), EventType))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidValueFor, Resources.Strings.LabelMouseActionEventType);
                return false;
            }

            if ((MoveSpeed < 0) || (MoveSpeed > 2))
            {
                errorMessage = string.Format(Resources.Strings.ErrorMessageInvalidIntervalFor, Resources.Strings.LabelSpeed, 0, 2);
                return false;
            }

            Logger.Log($"Validated MouseAction", TraceEventType.Verbose);
            errorMessage = string.Empty;
            return true;
        }

    }
}
