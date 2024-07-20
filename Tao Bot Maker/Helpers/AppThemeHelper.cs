using Microsoft.Win32;
using System;
using System.Drawing;
using System.Reflection;
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
                BackColorElevationZero = Color.White,
                BackColorElevationOne = Color.FromArgb(245, 245, 245),
                BackColorElevationTwo = Color.FromArgb(235, 235, 235),
                BackColorElevationThree = Color.FromArgb(225, 225, 225),
                BackColorElevationFour = Color.FromArgb(215, 215, 215),
                BackColorElevationFive = Color.FromArgb(205, 205, 205),
                BackColorElevationSix = Color.FromArgb(195, 195, 195),
                BackColorElevationSeven = Color.FromArgb(185, 185, 185),
                BackColorElevationEight = Color.FromArgb(175, 175, 175),
                BackColorElevationNine = Color.FromArgb(165, 165, 165),
                BackColorElevationTen = Color.FromArgb(155, 155, 155),
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
                BackColorElevationZero = Color.Black,
                BackColorElevationOne = Color.FromArgb(20, 20, 20),
                BackColorElevationTwo = Color.FromArgb(30, 30, 30),
                BackColorElevationThree = Color.FromArgb(40, 40, 40),
                BackColorElevationFour = Color.FromArgb(50, 50, 50),
                BackColorElevationFive = Color.FromArgb(60, 60, 60),
                BackColorElevationSix = Color.FromArgb(70, 70, 70),
                BackColorElevationSeven = Color.FromArgb(80, 80, 80),
                BackColorElevationEight = Color.FromArgb(90, 90, 90),
                BackColorElevationNine = Color.FromArgb(100, 100, 100),
                BackColorElevationTen = Color.FromArgb(110, 110, 110),
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
            if (elevation < 0)
            {
                return theme.BackColorElevationZero;
            }
            else if (elevation > 10)
            {
                return theme.BackColorElevationTen;
            }

            switch (elevation)
            {
                case 0:
                    return theme.BackColorElevationZero;
                case 1:
                    return theme.BackColorElevationOne;
                case 2:
                    return theme.BackColorElevationTwo;
                case 3:
                    return theme.BackColorElevationThree;
                case 4:
                    return theme.BackColorElevationFour;
                case 5:
                    return theme.BackColorElevationFive;
                case 6:
                    return theme.BackColorElevationSix;
                case 7:
                    return theme.BackColorElevationSeven;
                case 8:
                    return theme.BackColorElevationEight;
                case 9:
                    return theme.BackColorElevationNine;
                case 10:
                    return theme.BackColorElevationTen;
            }

            return theme.BackColorElevationTen;
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
            if ((control.Parent.BackColor == Color.Transparent))
            {
                elevation--;
            }
            switch (control)
            {
                case ContextMenuStrip contextMenuStrip:
                    ApplyThemeToContextMenuStrip(theme, contextMenuStrip, elevation);
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
                    ApplyThemeToMenuStrip(theme, menuStrip, elevation);
                    break;
                case ToolStrip toolStrip:
                    ApplyThemeToToolStrip(theme, toolStrip, elevation);
                    break;
                default:
                    var controlType = control.GetType();
                    if (controlType.IsGenericType && controlType.GetGenericTypeDefinition() == typeof(CustomItemControl<>))
                    {
                        var method = typeof(AppThemeHelper).GetMethod(nameof(ApplyThemeToCustomListItem), BindingFlags.NonPublic | BindingFlags.Static);
                        var genericMethod = method.MakeGenericMethod(controlType.GetGenericArguments());
                        genericMethod.Invoke(null, new object[] { theme, control, elevation });
                    }
                    break;
            }

            if (!(control is MenuStrip) && !(control is ToolStrip) && !(control is ActionCustomListItem) && control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ApplyThemeToControl(theme, child, elevation + 1);
                }
            }
        }

        private static void ApplyThemeToContextMenuStrip(AppTheme theme, ContextMenuStrip contextMenuStrip, int elevation)
        {
            if (contextMenuStrip == null)
                return;

            contextMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip.Renderer = new CustomToolStripRenderer(theme, elevation);
            contextMenuStrip.BackColor = GetElevationColor(theme, elevation);
            contextMenuStrip.ForeColor = theme.ForeColor;

            foreach (ToolStripMenuItem menuItem in contextMenuStrip.Items)
            {
                ApplyThemeToMenuItem(theme, menuItem, elevation);
            }

        }

        private static void ApplyThemeToCustomListItem<T>(AppTheme theme, CustomItemControl<T> actionTypeCustomListItem, int elevation)
        {
            actionTypeCustomListItem.SurfaceColor = GetElevationColor(theme, elevation);
            actionTypeCustomListItem.TextColor = theme.ForeColor;
            actionTypeCustomListItem.HighlightBackColor = theme.HighlightBackColor;
            actionTypeCustomListItem.HighlightForeColor = theme.HighlightForeColor;
            actionTypeCustomListItem.HoverBackColor = GetElevationColor(theme, elevation + 1);
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
            actionCustomListItem.HoverBackColor = GetElevationColor(theme, elevation + 1);
            actionCustomListItem.HoverForeColor = theme.HoverForeColor;
            actionCustomListItem.PressedBackColor = theme.PressedBackColor;
            actionCustomListItem.PressedForeColor = theme.PressedForeColor;
        }

        private static void ApplyThemeToButton(AppTheme theme, Button button, int elevation)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = GetElevationColor(theme, elevation);
            button.ForeColor = theme.ForeColor;
            button.FlatAppearance.BorderColor = GetElevationColor(theme, elevation + 1);
            // Handle button hover and disabled text colors
            button.MouseEnter += (sender, e) =>
            {
                button.FlatAppearance.MouseOverBackColor = GetElevationColor(theme, elevation + 1);
                button.FlatAppearance.BorderColor = GetElevationColor(theme, elevation + 2);
                button.ForeColor = theme.ForeColor;
            };
            button.MouseLeave += (sender, e) =>
            {
                button.BackColor = GetElevationColor(theme, elevation);
                button.FlatAppearance.BorderColor = GetElevationColor(theme, elevation + 1);
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
            if (flowLayoutPanel.BackColor != Color.Transparent)
                flowLayoutPanel.BackColor = GetElevationColor(theme, elevation);
            flowLayoutPanel.ForeColor = theme.ForeColor;
            ApplyThemeToContextMenuStrip(theme, flowLayoutPanel.ContextMenuStrip, elevation);
        }

        private static void ApplyThemeToPanel(AppTheme theme, Panel panel, int elevation)
        {
            if (panel.BackColor != Color.Transparent)
                panel.BackColor = GetElevationColor(theme, elevation);
            panel.ForeColor = theme.ForeColor;
        }

        private static void ApplyThemeToMenuStrip(AppTheme theme, MenuStrip menuStrip, int elevation)
        {
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
            menuStrip.Renderer = new CustomToolStripRenderer(theme, elevation);
            menuStrip.BackColor = GetElevationColor(theme, elevation);
            menuStrip.ForeColor = theme.ForeColor;

            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                ApplyThemeToMenuItem(theme, menuItem, elevation);
            }
        }

        private static void ApplyThemeToMenuItem(AppTheme theme, ToolStripMenuItem menuItem, int elevation)
        {
            menuItem.BackColor = GetElevationColor(theme, elevation);
            menuItem.ForeColor = menuItem.Enabled ? theme.ForeColor : theme.DisabledTextColor;
            menuItem.MouseEnter += (sender, e) => menuItem.ForeColor = theme.ForeColor;
            menuItem.MouseLeave += (sender, e) => menuItem.ForeColor = theme.ForeColor;
            menuItem.EnabledChanged += (sender, e) => menuItem.ForeColor = menuItem.Enabled ? theme.ForeColor : theme.DisabledTextColor;

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    subItem.BackColor = GetElevationColor(theme, elevation); // Color dropdown menu items
                    ApplyThemeToMenuItem(theme, subMenuItem, elevation);
                }
                else if (subItem is ToolStripSeparator separator)
                {
                    separator.Paint += (sender, e) =>
                    {
                        e.Graphics.FillRectangle(new SolidBrush(GetElevationColor(theme, elevation)), e.ClipRectangle);
                        e.Graphics.DrawLine(new Pen(GetElevationColor(theme, elevation + 1)), e.ClipRectangle.Left, e.ClipRectangle.Height / 2, e.ClipRectangle.Right, e.ClipRectangle.Height / 2);
                    };
                }
            }
        }

        private static void ApplyThemeToToolStrip(AppTheme theme, ToolStrip toolStrip, int elevation)
        {
            toolStrip.RenderMode = ToolStripRenderMode.Professional;
            toolStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable(theme, elevation));
            toolStrip.BackColor = GetElevationColor(theme, elevation);
            toolStrip.ForeColor = theme.ForeColor;

            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item is ToolStripButton button)
                {
                    ApplyThemeToToolStripButton(theme, button, elevation);
                }
                else if (item is ToolStripSeparator separator)
                {
                    separator.Paint += (sender, e) =>
                    {
                        // Override the default rendering of the separator
                        e.Graphics.FillRectangle(new SolidBrush(GetElevationColor(theme, elevation)), e.ClipRectangle);
                        e.Graphics.DrawLine(new Pen(GetElevationColor(theme, elevation + 1)), e.ClipRectangle.Width / 2, e.ClipRectangle.Top + 5, e.ClipRectangle.Width / 2, e.ClipRectangle.Bottom - 5);
                    };
                }
                else if (item is ToolStripComboBox comboBox)
                {
                    ApplyThemeToToolStripComboBox(theme, comboBox, elevation);
                }
            }
        }

        private static void ApplyThemeToToolStripButton(AppTheme theme, ToolStripButton button, int elevation)
        {
            button.BackColor = GetElevationColor(theme, elevation);
            button.ForeColor = button.Enabled ? theme.ForeColor : theme.DisabledTextColor;

            void ApplyHoverStyle()
            {
                if (button.Enabled)
                {
                    button.BackColor = GetElevationColor(theme, elevation + 1);
                    button.ForeColor = theme.ForeColor;
                    button.Invalidate();
                }
            }

            void ApplyDefaultStyle()
            {
                button.BackColor = GetElevationColor(theme, elevation);
                button.ForeColor = button.Enabled ? theme.ForeColor : theme.DisabledTextColor;
                button.Invalidate();
            }

            void ApplyPressedStyle()
            {
                if (button.Enabled)
                {
                    button.BackColor = GetElevationColor(theme, elevation);
                    button.ForeColor = theme.ForeColor;
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
                    using (Pen penBorder = new Pen(Color.Transparent))
                    {
                        if (button.Selected)
                        {
                            button.BackColor = GetElevationColor(theme, elevation + 1);
                            penBorder.Color = GetElevationColor(theme, elevation + 2);
                            e.Graphics.DrawRectangle(penBorder, rect);
                        }

                        if (button.Pressed)
                        {
                            button.BackColor = GetElevationColor(theme, elevation);
                            penBorder.Color = GetElevationColor(theme, elevation + 1);
                            e.Graphics.DrawRectangle(penBorder, rect);
                        }
                    }
                }
            };

            button.Margin = new Padding(0, 5, 0, 5);
        }

        private static void ApplyThemeToToolStripComboBox(AppTheme theme, ToolStripComboBox comboBox, int elevation)
        {
            // Set background and foreground colors
            comboBox.BackColor = GetElevationColor(theme, elevation);
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
                                    ? GetElevationColor(theme, elevation + 1)
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
        private readonly int _elevation;

        public CustomColorTable(AppTheme theme, int elevation)
        {
            _theme = theme;
            _elevation = elevation;
        }

        public override Color MenuItemSelected => AppThemeHelper.GetElevationColor(_theme, _elevation + 1); // Hovered dropdown menu item
        public override Color MenuItemBorder => AppThemeHelper.GetElevationColor(_theme, _elevation + 2); // Border around Hovered dropdown menu item
        public override Color MenuBorder => AppThemeHelper.GetElevationColor(_theme, _elevation + 1); // Border around menu item (File, Edit, etc) and dropdown menu
        public override Color MenuItemPressedGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation); // Pressed menu item (File, Edit, etc)
        public override Color MenuItemPressedGradientMiddle => AppThemeHelper.GetElevationColor(_theme, _elevation);// Pressed menu item (File, Edit, etc)
        public override Color MenuItemPressedGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation); // Pressed menu item (File, Edit, etc)
        public override Color MenuItemSelectedGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation + 1); // Hovered menu item (File, Edit, etc)
        public override Color MenuItemSelectedGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation + 1); // Hovered menu item (File, Edit, etc)
        public override Color ToolStripDropDownBackground => AppThemeHelper.GetElevationColor(_theme, _elevation); // Border around dropdown menu except left side
        public override Color ImageMarginGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation); // Border left side around dropdown menu
        public override Color ImageMarginGradientMiddle => AppThemeHelper.GetElevationColor(_theme, _elevation); // Border left side around dropdown menu
        public override Color ImageMarginGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation); // Border left side around dropdown menu


        public override Color ToolStripBorder => AppThemeHelper.GetElevationColor(_theme, _elevation); // Border color around ToolStrip
        public override Color ToolStripContentPanelGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color ToolStripContentPanelGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color ToolStripPanelGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color ToolStripPanelGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color ToolStripGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color ToolStripGradientMiddle => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color ToolStripGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color OverflowButtonGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color OverflowButtonGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);
        public override Color OverflowButtonGradientMiddle => AppThemeHelper.GetElevationColor(_theme, _elevation + 1);

        public override Color ButtonSelectedGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation + 1); // Toolstrip button background
        public override Color ButtonSelectedGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation + 1); // Toolstrip button background
        public override Color ButtonSelectedGradientMiddle => AppThemeHelper.GetElevationColor(_theme, _elevation + 1); // Toolstrip button background
        public override Color ButtonSelectedBorder => AppThemeHelper.GetElevationColor(_theme, _elevation + 2); // Toolstrip button border
        public override Color ButtonPressedGradientBegin => AppThemeHelper.GetElevationColor(_theme, _elevation);
        public override Color ButtonPressedGradientEnd => AppThemeHelper.GetElevationColor(_theme, _elevation);
        public override Color ButtonPressedGradientMiddle => AppThemeHelper.GetElevationColor(_theme, _elevation);
    }

    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        private AppTheme theme;
        private int elevation;

        public CustomToolStripRenderer(AppTheme theme, int elevation) : base(new CustomColorTable(theme, elevation))
        {
            this.theme = theme;
            this.elevation = elevation;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            // Hide border when hovering a disabled menu item
            if (e.Item.Selected && !e.Item.Enabled)
            {
                ToolStripMenuItem item = e.Item as ToolStripMenuItem;
                Color color = AppThemeHelper.GetElevationColor(theme, elevation);
                Rectangle rect = new Rectangle(2, 0, item.Width - 4, item.Height - 1);
                using (Pen pen = new Pen(color))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
    }
}
