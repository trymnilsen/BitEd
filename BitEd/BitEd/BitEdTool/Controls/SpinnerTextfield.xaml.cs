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
    /// Interaction logic for SpinnerTextfield.xaml
    /// </summary>
    public partial class SpinnerTextfield : UserControl
    {

    public static readonly DependencyProperty NumValueProperty = DependencyProperty.Register("NumValue", typeof(int), typeof(SpinnerTextfield));

    public int NumValue
    {
        get { return (int)GetValue(NumValueProperty); }
        set
        {
            SetValue(NumValueProperty, value);
            txtNum.Text = value.ToString();
        }
    }

    public SpinnerTextfield()
    {
        InitializeComponent();
        NumValue = 0;
        txtNum.Text = "0";
    }

    private void cmdUp_Click(object sender, RoutedEventArgs e)
    {
        NumValue++;
    }

    private void cmdDown_Click(object sender, RoutedEventArgs e)
    {
        NumValue--;
    }

    private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
    {
        int parsedNum = 0;
        if (!int.TryParse(txtNum.Text, out parsedNum))
            txtNum.Text = NumValue.ToString();
    }
    }
}
