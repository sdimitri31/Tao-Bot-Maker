using System;
using System.Globalization;

namespace Tao_Bot_Maker.Helpers
{
    public static class CultureManager
    {
        public static event Action CultureChanged;

        public static void ChangeCulture(string culture)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
            CultureChanged?.Invoke();
        }
    }
}
