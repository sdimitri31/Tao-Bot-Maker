using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tao_Bot_Maker.View;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace Tao_Bot_Maker.Helpers
{
    public static class AppThemeHelper
    {
        private const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string RegistryValueName = "AppsUseLightTheme";

        public static bool IsWindowsInDarkMode()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
                {
                    if (key != null)
                    {
                        object registryValueObject = key.GetValue(RegistryValueName);
                        if (registryValueObject != null)
                        {
                            int registryValue = (int)registryValueObject;
                            return registryValue == 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception if needed
                Console.WriteLine($"Error reading registry: {ex.Message}");
            }

            return false; // Default to light mode if unable to read the setting
        }

        public static AppTheme GetAppThemeFromName(string theme)
        {
            switch (theme)
            {
                case "Dark":
                    return DarkTheme();
                case "Light":
                    return LightTheme();
                default:
                    bool isDarkMode = IsWindowsInDarkMode();
                    return isDarkMode ? DarkTheme() : LightTheme();
            }
        }

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
                HighlightBackColor = SystemColors.Highlight,
                HighlightBorderColor = SystemColors.Highlight,
                HighlightForeColor = SystemColors.HighlightText,
                HoverBackColor = Color.FromArgb(200, 200, 200),
                HoverBorderColor = Color.FromArgb(180, 180, 180),
                HoverForeColor = Color.Black,
                PressedBackColor = Color.DarkBlue,
                PressedBorderColor = Color.DarkBlue,
                PressedForeColor = Color.White,
                ForeColor = Color.Black,
                LinkForeColor = Color.Blue,
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
                HighlightBackColor = SystemColors.Highlight,
                HighlightBorderColor = SystemColors.Highlight,
                HighlightForeColor = SystemColors.HighlightText,
                HoverBackColor = Color.FromArgb(50, 50, 50),
                HoverBorderColor = Color.FromArgb(80, 80, 80),
                HoverForeColor = Color.White,
                PressedBackColor = Color.DarkBlue,
                PressedBorderColor = Color.DarkBlue,
                PressedForeColor = Color.White,
                ForeColor = Color.White,
                LinkForeColor = Color.RoyalBlue,
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

        public static void ApplyThemeToControl(AppTheme theme, Control control, int elevation)
        {
            // Reduce elevation if transparent
            if (control.BackColor == Color.Transparent)
            {
                elevation--;
            }
            switch (control)
            {
                case ActionTypeCustomListItem actionTypeCustomListItem:
                    ApplyThemeToActionTypeCustomListItem(theme, actionTypeCustomListItem, elevation);
                    break;

                case ActionCustomListItem actionCustomListItem:
                    ApplyThemeToActionCustomListItem(theme, actionCustomListItem, elevation);
                    break;
                case Button button:
                    ApplyThemeToButton(theme, button, elevation);
                    break;
                case LinkLabel linkLabel:
                    ApplyThemeToLinkLabel(theme, linkLabel);
                    break;
                case Label label:
                    ApplyThemeToLabel(theme, label);
                    break;
                case TextBox textBox:
                    ApplyThemeToTextBox(theme, textBox, elevation);
                    break;
                case TableLayoutPanel table:
                    ApplyThemeToTableLayout(theme, table);
                    break;
                case FlowLayoutPanel flowLayoutPanel:
                    ApplyThemeToFlowLayoutPanel(theme, flowLayoutPanel, elevation);
                    break;
                case Panel panel:
                    ApplyThemeToPanel(theme, panel, elevation);
                    break;
                case MenuStrip menuStrip:
                    ApplyThemeToMenuStrip(theme, menuStrip);
                    break;
                case ToolStrip toolStrip:
                    ApplyThemeToToolStrip(theme, toolStrip);
                    break;
            }

            if (!(control is MenuStrip) && !(control is ToolStrip) && control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ApplyThemeToControl(theme, child, elevation + 1);
                }
            }
        }

        private static void ApplyThemeToActionTypeCustomListItem(AppTheme theme, ActionTypeCustomListItem actionTypeCustomListItem, int elevation)
        {
            actionTypeCustomListItem.SurfaceColor = GetElevationColor(theme, elevation);
            actionTypeCustomListItem.TextColor = theme.ForeColor;
            actionTypeCustomListItem.HighlightBackColor = theme.HighlightBackColor;
            actionTypeCustomListItem.HighlightForeColor = theme.HighlightForeColor;
            actionTypeCustomListItem.HoverBackColor = GetElevationColor(theme, elevation - 1);
            actionTypeCustomListItem.HoverForeColor = theme.HoverForeColor;
            actionTypeCustomListItem.PressedBackColor = theme.PressedBackColor;
            actionTypeCustomListItem.PressedForeColor = theme.PressedForeColor;
        }

        private static void ApplyThemeToActionCustomListItem(AppTheme theme, ActionCustomListItem actionCustomListItem, int elevation)
        {
            actionCustomListItem.SurfaceColor = GetElevationColor(theme, elevation);
            actionCustomListItem.TextColor = theme.ForeColor;
            actionCustomListItem.HighlightBackColor = theme.HighlightBackColor;
            actionCustomListItem.HighlightForeColor = theme.HighlightForeColor;
            actionCustomListItem.HoverBackColor = GetElevationColor(theme, elevation - 1);
            actionCustomListItem.HoverForeColor = theme.HoverForeColor;
            actionCustomListItem.PressedBackColor = theme.PressedBackColor;
            actionCustomListItem.PressedForeColor = theme.PressedForeColor;
        }

        private static void ApplyThemeToButton(AppTheme theme, Button button, int elevation)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = GetElevationColor(theme, elevation);
            button.ForeColor = theme.ForeColor;
            button.FlatAppearance.BorderColor = GetElevationColor(theme, elevation - 1);
            // Handle button hover and disabled text colors
            button.MouseEnter += (sender, e) =>
            {
                button.FlatAppearance.MouseOverBackColor = theme.HoverBackColor;
                button.FlatAppearance.BorderColor = theme.HoverBorderColor;
                button.ForeColor = theme.HoverForeColor;
            };
            button.MouseLeave += (sender, e) =>
            {
                button.BackColor = GetElevationColor(theme, elevation);
                button.FlatAppearance.BorderColor = GetElevationColor(theme, elevation - 1);
                button.ForeColor = theme.ForeColor;
            };
            button.EnabledChanged += (sender, e) => button.ForeColor = button.Enabled ? theme.ForeColor : theme.DisabledTextColor;
        }

        private static void ApplyThemeToLinkLabel(AppTheme theme, LinkLabel linkLabel)
        {
            linkLabel.LinkColor = theme.LinkForeColor;
            linkLabel.EnabledChanged += (sender, e) => linkLabel.ForeColor = linkLabel.Enabled ? theme.ForeColor : theme.DisabledTextColor;
        }


        private static void ApplyThemeToLabel(AppTheme theme, Label label)
        {
            label.ForeColor = theme.ForeColor;
            label.EnabledChanged += (sender, e) => label.ForeColor = label.Enabled ? theme.ForeColor : theme.DisabledTextColor;
        }

        private static void ApplyThemeToTextBox(AppTheme theme, TextBox textBox, int elevation)
        {
            textBox.BackColor = GetElevationColor(theme, elevation);
            textBox.ForeColor = theme.ForeColor;
        }

        private static void ApplyThemeToTableLayout(AppTheme theme, TableLayoutPanel table)
        {
            table.BackColor = Color.Transparent;
            table.ForeColor = theme.ForeColor;
        }

        private static void ApplyThemeToFlowLayoutPanel(AppTheme theme, FlowLayoutPanel flowLayoutPanel, int elevation)
        {
            flowLayoutPanel.BackColor = GetElevationColor(theme, elevation);
            flowLayoutPanel.ForeColor = theme.ForeColor;
        }

        private static void ApplyThemeToPanel(AppTheme theme, Panel panel, int elevation)
        {
            panel.BackColor = GetElevationColor(theme, elevation);
            panel.ForeColor = theme.ForeColor;
        }

        private static void ApplyThemeToMenuStrip(AppTheme theme, MenuStrip menuStrip)
        {
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
            menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable(theme));
            menuStrip.BackColor = theme.BackColorElevationOne;
            menuStrip.ForeColor = theme.ForeColor;

            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                ApplyThemeToMenuItem(theme, menuItem);
            }
        }

        private static void ApplyThemeToMenuItem(AppTheme theme, ToolStripMenuItem menuItem)
        {
            menuItem.BackColor = theme.BackColorElevationOne;
            menuItem.ForeColor = theme.ForeColor;
            menuItem.MouseEnter += (sender, e) => menuItem.ForeColor = theme.ForeColor;
            menuItem.MouseLeave += (sender, e) => menuItem.ForeColor = theme.ForeColor;
            menuItem.EnabledChanged += (sender, e) => menuItem.ForeColor = menuItem.Enabled ? theme.ForeColor : theme.DisabledTextColor;

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    ApplyThemeToMenuItem(theme, subMenuItem);
                    subItem.BackColor = theme.BackColorElevationTwo; // Color dropdown menu items
                }
                else if (subItem is ToolStripSeparator separator)
                {
                    separator.Paint += (sender, e) =>
                    {
                        e.Graphics.FillRectangle(new SolidBrush(theme.BackColorElevationTwo), e.ClipRectangle);
                        e.Graphics.DrawLine(new Pen(theme.BackColorElevationThree), e.ClipRectangle.Left, e.ClipRectangle.Height / 2, e.ClipRectangle.Right, e.ClipRectangle.Height / 2);
                    };
                }
            }

            if (menuItem.DropDown is ContextMenuStrip contextMenuStrip)
            {
                contextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable(theme));
            }
        }

        private static void ApplyThemeToToolStrip(AppTheme theme, ToolStrip toolStrip)
        {
            toolStrip.RenderMode = ToolStripRenderMode.Professional;
            toolStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable(theme));
            toolStrip.BackColor = theme.BackColorElevationOne;
            toolStrip.ForeColor = theme.ForeColor;

            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item is ToolStripButton button)
                {
                    ApplyThemeToToolStripButton(theme, button);
                }
                else if (item is ToolStripSeparator separator)
                {
                    separator.Paint += (sender, e) =>
                    {
                        // Override the default rendering of the separator
                        e.Graphics.FillRectangle(new SolidBrush(theme.BackColorElevationOne), e.ClipRectangle);
                        e.Graphics.DrawLine(new Pen(theme.BackColorElevationThree), e.ClipRectangle.Width / 2, e.ClipRectangle.Top + 5, e.ClipRectangle.Width / 2, e.ClipRectangle.Bottom - 5);
                    };
                }
                else if (item is ToolStripComboBox comboBox)
                {
                    ApplyThemeToToolStripComboBox(theme, comboBox);
                }
            }
        }

        private static void ApplyThemeToToolStripButton(AppTheme theme, ToolStripButton button)
        {
            button.BackColor = theme.BackColorElevationOne;
            button.ForeColor = button.Enabled ? theme.ForeColor : theme.DisabledTextColor;

            void ApplyHoverStyle()
            {
                if (button.Enabled)
                {
                    button.BackColor = theme.HoverBackColor;
                    button.ForeColor = theme.HoverForeColor;
                    button.Invalidate();
                }
            }

            void ApplyDefaultStyle()
            {
                button.BackColor = theme.BackColorElevationOne;
                button.ForeColor = button.Enabled ? theme.ForeColor : theme.DisabledTextColor;
                button.Invalidate();
            }

            void ApplyPressedStyle()
            {
                if (button.Enabled)
                {
                    button.BackColor = theme.PressedBackColor;
                    button.ForeColor = theme.PressedForeColor;
                    button.Invalidate();
                }
            }

            button.MouseEnter += (sender, e) => ApplyHoverStyle();
            button.MouseLeave += (sender, e) => ApplyDefaultStyle();
            button.MouseDown += (sender, e) => ApplyPressedStyle();
            button.MouseUp += (sender, e) => ApplyHoverStyle();
            button.EnabledChanged += (sender, e) => ApplyDefaultStyle();

            button.Paint += (sender, e) =>
            {
                if (button.Enabled)
                {
                    Rectangle rect = new Rectangle(0, 0, button.Width - 1, button.Height - 1);
                    using (Pen pen = new Pen(theme.HoverBorderColor))
                    {
                        if (button.BackColor == theme.HoverBackColor || button.BackColor == theme.PressedBackColor)
                        {
                            e.Graphics.DrawRectangle(pen, rect);
                        }
                    }
                }
            };

            button.Margin = new Padding(0, 5, 0, 5);
        }

        private static void ApplyThemeToToolStripComboBox(AppTheme theme, ToolStripComboBox comboBox)
        {
            // Set background and foreground colors
            comboBox.BackColor = theme.BackColorElevationTwo;
            comboBox.ForeColor = theme.ForeColor;

            // Custom painting for ComboBox dropdown
            comboBox.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.ComboBox.DrawItem += (sender, e) =>
            {
                if (e.Index < 0) return;

                e.DrawBackground();
                e.DrawFocusRectangle();

                // Determine the color based on the state
                Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                                    ? theme.HoverForeColor
                                    : theme.ForeColor;

                // Draw the text
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), e.Font, new SolidBrush(textColor), e.Bounds.Left + 3, e.Bounds.Top + 2);
            };

            // Adjust the margin for ComboBox
            comboBox.Margin = new Padding(0, 5, 0, 5);
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
        public override Color ImageMarginGradientBegin => _theme.BackColorElevationTwo; // Border left side around dropdown menu
        public override Color ImageMarginGradientMiddle => _theme.BackColorElevationTwo; // Border left side around dropdown menu
        public override Color ImageMarginGradientEnd => _theme.BackColorElevationTwo; // Border left side around dropdown menu


        public override Color ToolStripBorder => _theme.BackColorElevationOne; // Border color around ToolStrip
        public override Color ToolStripContentPanelGradientBegin => _theme.BackColorElevationTwo;
        public override Color ToolStripContentPanelGradientEnd => _theme.BackColorElevationTwo;
        public override Color ToolStripPanelGradientBegin => _theme.BackColorElevationTwo;
        public override Color ToolStripPanelGradientEnd => _theme.BackColorElevationTwo;
        public override Color ToolStripGradientBegin => _theme.BackColorElevationTwo;
        public override Color ToolStripGradientMiddle => _theme.BackColorElevationTwo;
        public override Color ToolStripGradientEnd => _theme.BackColorElevationTwo;
        public override Color OverflowButtonGradientBegin => _theme.BackColorElevationTwo;
        public override Color OverflowButtonGradientEnd => _theme.BackColorElevationTwo;
        public override Color OverflowButtonGradientMiddle => _theme.BackColorElevationTwo;

        public override Color ButtonSelectedGradientBegin => _theme.HoverBackColor; // Toolstrip button background
        public override Color ButtonSelectedGradientEnd => _theme.HoverBackColor; // Toolstrip button background
        public override Color ButtonSelectedGradientMiddle => _theme.HoverBackColor; // Toolstrip button background
        public override Color ButtonSelectedBorder => _theme.HoverBorderColor; // Toolstrip button border
    }

}
