using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using Tao_Bot_Maker.View;
using static System.Windows.Forms.Control;

namespace Tao_Bot_Maker.Helpers
{
    public static class AppThemeHelper
    {
        public static AppTheme LightTheme()
        {
            var myTheme = new AppTheme
            {
                BackColorElevationOne = Color.White,
                BackColorElevationTwo = Color.FromArgb(230, 230, 230),
                BackColorElevationThree = Color.FromArgb(200, 200, 200),
                BackColorElevationFour = Color.FromArgb(180, 180, 180),
                BackColorElevationFive = Color.FromArgb(150, 150, 150),
                BackColorElevationSix = Color.FromArgb(100, 100, 100),
                ForeColor = Color.Black,
                HighlightBackColor = SystemColors.Highlight,
                HighlightForeColor = SystemColors.HighlightText,
                HoverBackColor = Color.LightBlue,
                HoverForeColor = Color.Black,
                PressedBackColor = Color.DarkBlue,
                PressedForeColor = Color.White,
                DisabledTextColor = SystemColors.GrayText
            };

            return myTheme;
        }

        public static AppTheme DarkTheme()
        {
            var myTheme = new AppTheme
            {
                BackColorElevationOne = Color.FromArgb(26, 26, 26),
                BackColorElevationTwo = Color.FromArgb(33, 33, 33),
                BackColorElevationThree = Color.FromArgb(50, 50, 50),
                BackColorElevationFour = Color.FromArgb(80, 80, 80),
                BackColorElevationFive = Color.FromArgb(100, 100, 100),
                BackColorElevationSix = Color.FromArgb(120, 120, 120),
                ForeColor = Color.White,
                HighlightBackColor = SystemColors.Highlight,
                HighlightForeColor = SystemColors.HighlightText,
                HoverBackColor = Color.LightBlue,
                HoverForeColor = Color.Black,
                PressedBackColor = Color.DarkBlue,
                PressedForeColor = Color.White,
                DisabledTextColor = SystemColors.GrayText
            };

            return myTheme;
        }

        public static Color GetElevationColor(AppTheme theme, int elevation)
        {
            switch (elevation)
            {
                case 0:
                    return theme.BackColorElevationOne;
                case 1:
                    return theme.BackColorElevationTwo;
                case 2:
                    return theme.BackColorElevationThree;
                case 3:
                    return theme.BackColorElevationFour;
                case 4:
                    return theme.BackColorElevationFive;
                case 5:
                    return theme.BackColorElevationSix;
                default:
                    return theme.BackColorElevationOne;
            }
        }

        public static void ApplyTheme(AppTheme theme, Form form, int elevation = 0)
        {
            form.BackColor = GetElevationColor(theme, elevation);
            form.ForeColor = theme.ForeColor;

            foreach (Control control in form.Controls)
            {
                ApplyThemeToControl(theme, control, elevation + 1);
            }
        }

        private static void ApplyThemeToControl(AppTheme theme, Control control, int elevation)
        {
            if (control.Parent.BackColor == Color.Transparent)
            {
                elevation--;
            }
            switch (control)
            {
                case Button button:
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = GetElevationColor(theme, elevation);
                    button.ForeColor = theme.ForeColor;
                    button.FlatAppearance.BorderColor = GetElevationColor(theme, elevation - 1);
                    button.FlatAppearance.MouseOverBackColor = theme.HoverBackColor;
                    // Handle button hover and disabled text colors
                    button.MouseEnter += (sender, e) => button.ForeColor = theme.HoverForeColor;
                    button.MouseLeave += (sender, e) => button.ForeColor = theme.ForeColor;
                    button.EnabledChanged += (sender, e) => button.ForeColor = button.Enabled ? theme.ForeColor : theme.DisabledTextColor;
                    break;

                case Label label:
                    label.ForeColor = theme.ForeColor;
                    label.EnabledChanged += (sender, e) => label.ForeColor = label.Enabled ? theme.ForeColor : theme.DisabledTextColor;
                    break;

                case TextBox textBox:
                    textBox.BackColor = GetElevationColor(theme, elevation);
                    textBox.ForeColor = theme.ForeColor;
                    break;

                case ActionTypeCustomListItem actionTypeCustomListItem:
                    actionTypeCustomListItem.SurfaceColor = GetElevationColor(theme, elevation);
                    actionTypeCustomListItem.TextColor = theme.ForeColor;
                    actionTypeCustomListItem.HighlightBackColor = theme.HighlightBackColor;
                    actionTypeCustomListItem.HighlightForeColor = theme.HighlightForeColor;
                    actionTypeCustomListItem.HoverBackColor = theme.HoverBackColor;
                    actionTypeCustomListItem.HoverForeColor = theme.HoverForeColor;
                    actionTypeCustomListItem.PressedBackColor = theme.PressedBackColor;
                    actionTypeCustomListItem.PressedForeColor = theme.PressedForeColor;
                    break;
                case ActionCustomListItem actionCustomListItem:
                    break;
                case TableLayoutPanel table:
                    table.BackColor = Color.Transparent;
                    table.ForeColor = theme.ForeColor;
                    break;
                case Panel panel:
                    if (panel.BackColor == Color.Transparent)
                        break;
                    panel.BackColor = GetElevationColor(theme, elevation);
                    panel.ForeColor = theme.ForeColor;
                    break;
                case MenuStrip menuStrip:
                    ApplyThemeToMenuStrip(theme, menuStrip);
                    break;

            }

            if (!(control is MenuStrip) && control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ApplyThemeToControl(theme, child, elevation + 1);
                }
            }
        }
        private static void ApplyThemeToMenuStrip(AppTheme theme, MenuStrip menuStrip)
        {
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
            menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable(theme));
            menuStrip.BackColor = GetElevationColor(theme, 0);
            menuStrip.ForeColor = theme.ForeColor;

            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                ApplyThemeToMenuItem(theme, menuItem);
            }
        }


        private static void ApplyThemeToMenuItem(AppTheme theme, ToolStripMenuItem menuItem)
        {
            menuItem.BackColor = GetElevationColor(theme, 0);
            menuItem.ForeColor = theme.ForeColor;
            menuItem.MouseEnter += (sender, e) => menuItem.ForeColor = theme.ForeColor;
            menuItem.MouseLeave += (sender, e) => menuItem.ForeColor = theme.ForeColor;
            menuItem.EnabledChanged += (sender, e) => menuItem.ForeColor = menuItem.Enabled ? theme.ForeColor : theme.DisabledTextColor;


            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    ApplyThemeToMenuItem(theme, subMenuItem);

                    subItem.BackColor = GetElevationColor(theme, 1); // Color dropdown menu items
                }
                else if (subItem is ToolStripSeparator separator)
                {
                    separator.Paint += (sender, e) =>
                    {
                        e.Graphics.FillRectangle(new SolidBrush(GetElevationColor(theme, 1)), e.ClipRectangle);
                        e.Graphics.DrawLine(new Pen(GetElevationColor(theme, 2)), e.ClipRectangle.Left, e.ClipRectangle.Height / 2, e.ClipRectangle.Right, e.ClipRectangle.Height / 2);
                    };
                }
            }

            if (menuItem.DropDown is ContextMenuStrip contextMenuStrip)
            {
                contextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable(theme));
            }
        }

    }
    public class CustomColorTable : ProfessionalColorTable
    {
        private readonly AppTheme _theme;

        public CustomColorTable(AppTheme theme)
        {
            _theme = theme;
        }

        public override Color MenuItemSelected => _theme.BackColorElevationThree; // Selected dropdown menu item
        public override Color MenuItemBorder => _theme.BackColorElevationFour; // Border around Selected dropdown menu item
        public override Color MenuBorder => _theme.BackColorElevationThree; // Border around menu item (File, Edit, etc) and dropdown menu
        public override Color MenuItemPressedGradientBegin => _theme.BackColorElevationTwo; // Pressed menu item (File, Edit, etc)
        public override Color MenuItemPressedGradientMiddle => _theme.BackColorElevationTwo;// Pressed menu item (File, Edit, etc)
        public override Color MenuItemPressedGradientEnd => _theme.BackColorElevationTwo; // Pressed menu item (File, Edit, etc)
        public override Color MenuItemSelectedGradientBegin => _theme.BackColorElevationTwo; // Hovered menu item (File, Edit, etc)
        public override Color MenuItemSelectedGradientEnd => _theme.BackColorElevationTwo; // Hovered menu item (File, Edit, etc)
        public override Color ToolStripDropDownBackground => _theme.BackColorElevationTwo; // Border around dropdown menu except left side

        // Customizing the arrow color for submenu items
        public override Color ImageMarginGradientBegin => _theme.BackColorElevationTwo; // Border left side around dropdown menu
        public override Color ImageMarginGradientMiddle => _theme.BackColorElevationTwo; // Border left side around dropdown menu
        public override Color ImageMarginGradientEnd => _theme.BackColorElevationTwo; // Border left side around dropdown menu

    }
}
