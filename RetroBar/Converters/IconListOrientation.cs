using ManagedShell.AppBar;
using RetroBar.Utilities;
using System.Windows.Controls;
using System;
using System.Windows.Data;
using System.Globalization;

namespace RetroBar.Converters
{
    public class IconListOrientation : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool horizontal = Settings.Instance.Edge is AppBarEdge.Top or AppBarEdge.Bottom;
            int rows = Settings.Instance.RowCount;
            bool forceHorizontal = false;

            if (values != null && values.Length > 2 && values[2] is bool b)
            {
                forceHorizontal = b;
            }

            if (forceHorizontal)
            {
                return Orientation.Horizontal;
            }

            if (horizontal && rows > 1)
            {
                return Orientation.Vertical;
            }

            return Orientation.Horizontal;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
