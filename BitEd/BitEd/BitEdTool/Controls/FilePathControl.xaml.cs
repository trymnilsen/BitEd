using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitEdTool.Controls
{
    /// <summary>
    /// Interaction logic for FilePathControl.xaml
    /// </summary>
    public partial class FilePathControl : UserControl
    {
        public static readonly DependencyProperty CurrentFilePathProperty = DependencyProperty.Register("CurrentFilePath", typeof(string), typeof(FilePathControl), new UIPropertyMetadata("No File Selected"));

        public string CurrentFilePath
        {
            get { return (string)GetValue(CurrentFilePathProperty); }
            set { SetValue(CurrentFilePathProperty, value); }
        }

        public FilePathControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? dialogResult = fileDialog.ShowDialog();
            if (dialogResult == true)
            {
                FilepathTextBox.ToolTip = fileDialog.FileName;
                CurrentFilePath = fileDialog.FileName;
            }
        }
    }
}
