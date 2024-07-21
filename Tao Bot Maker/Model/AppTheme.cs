using System.Drawing;

namespace Tao_Bot_Maker.View
{
    public class AppTheme
    {
        // For surfaces
        public Color BackColorElevationZero { get; set; }
        public Color BackColorElevationOne { get; set; }
        public Color BackColorElevationTwo { get; set; }
        public Color BackColorElevationThree { get; set; }
        public Color BackColorElevationFour { get; set; }
        public Color BackColorElevationFive { get; set; }
        public Color BackColorElevationSix { get; set; }
        public Color BackColorElevationSeven { get; set; }
        public Color BackColorElevationEight { get; set; }
        public Color BackColorElevationNine { get; set; }
        public Color BackColorElevationTen { get; set; }

        // For text
        public Color ForeColor { get; set; }
        public Color DisabledTextColor { get; set; }
        public Color LinkForeColor { get; set; }

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

        // Constructor for easy initialization
        public AppTheme()
        {
            // Set default colors
            BackColorElevationZero = Color.White;
            BackColorElevationOne = Color.FromArgb(245, 245, 245);
            BackColorElevationTwo = Color.FromArgb(235, 235, 235);
            BackColorElevationThree = Color.FromArgb(225, 225, 225);
            BackColorElevationFour = Color.FromArgb(215, 215, 215);
            BackColorElevationFive = Color.FromArgb(205, 205, 205);
            BackColorElevationSix = Color.FromArgb(195, 195, 195);
            BackColorElevationSeven = Color.FromArgb(185, 185, 185);
            BackColorElevationEight = Color.FromArgb(175, 175, 175);
            BackColorElevationTen = Color.FromArgb(155, 155, 155);
            HighlightBackColor = SystemColors.Highlight;
            HighlightBorderColor = SystemColors.Highlight;
            HighlightForeColor = SystemColors.HighlightText;
            HoverBackColor = Color.FromArgb(200, 200, 200);
            HoverBorderColor = Color.FromArgb(180, 180, 180);
            HoverForeColor = Color.Black;
            PressedBackColor = Color.DarkBlue;
            PressedBorderColor = Color.DarkBlue;
            PressedForeColor = Color.White;
            ForeColor = Color.Black;
            LinkForeColor = Color.Blue;
            DisabledTextColor = SystemColors.GrayText;
        }
    }

}
