using System.Drawing;

namespace Tao_Bot_Maker.View
{
    public class AppTheme
    {
        // For surfaces
        public Color BackColorElevationOne { get; set; }
        public Color BackColorElevationTwo { get; set; }
        public Color BackColorElevationThree { get; set; }
        public Color BackColorElevationFour { get; set; }
        public Color BackColorElevationFive { get; set; }
        public Color BackColorElevationSix { get; set; }

        // For selected surfaces and text
        public Color HighlightBackColor { get; set; }
        public Color HighlightBorderColor { get; set; }
        public Color HighlightForeColor { get; set; }

        // For hovered surfaces
        public Color HoverBackColor { get; set; }
        public Color HoverBorderColor { get; set; }
        public Color HoverForeColor { get; set; }

        // For pressed state
        public Color PressedBackColor { get; set; }
        public Color PressedBorderColor { get; set; }
        public Color PressedForeColor { get; set; }


        public Color ForeColor { get; set; }
        public Color DisabledTextColor { get; set; }
        public Color LinkForeColor { get; set; }

        // Constructor for easy initialization
        public AppTheme()
        {
            // Set default colors or you can set them dynamically
            BackColorElevationOne = Color.White;
            BackColorElevationTwo = Color.LightGray;
            BackColorElevationThree = Color.Gray;
            BackColorElevationFour = Color.DarkGray;
            BackColorElevationFive = Color.DimGray;
            BackColorElevationSix = Color.Black;
            ForeColor = Color.Black;
            DisabledTextColor = SystemColors.GrayText;
            LinkForeColor = Color.LightBlue;

            HighlightBackColor = Color.Blue;
            HighlightBorderColor = Color.LightGray;
            HighlightForeColor = Color.White;

            HoverBackColor = Color.LightBlue;
            HoverBorderColor = Color.LightGray;
            HoverForeColor = Color.Black;

            PressedBackColor = Color.DarkBlue;
            PressedBorderColor = Color.DarkGray;
            PressedForeColor = Color.White;
        }
    }

}
