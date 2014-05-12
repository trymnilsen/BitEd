using BitEdLib.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BitEdTool.Converters
{
    class AssetErrorToColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is EAssetError)
            {
                EAssetError errorType = (EAssetError)value;
                if(errorType == EAssetError.IOAccessError || 
                    errorType == EAssetError.IOError ||
                    errorType == EAssetError.IOFileNotFound)
                {
                    return new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
                else if(errorType == EAssetError.NoFileSet)
                {
                    return new SolidColorBrush(Color.FromRgb(255, 127, 32));
                }
            }
            return new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
