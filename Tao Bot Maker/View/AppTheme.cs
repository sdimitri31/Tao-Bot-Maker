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
        public Color ForeColor { get; set; }

        // For selected surfaces and text
        public Color HighlightBackColor { get; set; }
        public Color HighlightForeColor { get; set; }

        // For hovered surfaces
        public Color HoverBackColor { get; set; }
        public Color HoverForeColor { get; set; }

        // For pressed state
        public Color PressedBackColor { get; set; }
        public Color PressedForeColor { get; set; }


        public Color DisabledTextColor { get; set; }

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

            HighlightBackColor = Color.Blue;
            HighlightForeColor = Color.White;

            HoverBackColor = Color.LightBlue;
            HoverForeColor = Color.Black;

            PressedBackColor = Color.DarkBlue;
            PressedForeColor = Color.White;
        }
    }

}
