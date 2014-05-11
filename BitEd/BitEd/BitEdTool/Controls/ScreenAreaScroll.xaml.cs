using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ScreenAreaScroll.xaml
    /// </summary>
    public partial class ScreenAreaScroll : UserControl
    {
        private Point position;
        private Point lastPoint;

        public ScreenAreaScroll()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                UIElement element = e.OriginalSource as UIElement;
                Point point = e.GetPosition(element);

                float deltaX = (float)point.X - (float)lastPoint.X;
                float deltaY = (float)point.Y - (float)lastPoint.Y;

                position.X += deltaX;
                position.Y += deltaY;
                lastPoint = point;

                ScreenScroll = position;
                ViewportRect = new Rect(position.X % 32, position.Y % 32, 32, 32);
                //RaisePropertyChanged("BackgroundScrollViewPort");
            }
        }

        public static readonly DependencyProperty ScreenScrollProperty = DependencyProperty.Register("ScreenScroll", typeof(Point), typeof(ScreenAreaScroll), new UIPropertyMetadata(new Point(0,0)));
        public Point ScreenScroll
        {
            get { return (Point)GetValue(ScreenScrollProperty); }
            set { SetValue(ScreenScrollProperty, value); }
        }

        public static readonly DependencyProperty ViewportRectProperty = DependencyProperty.Register("ViewportRect", typeof(Rect), typeof(ScreenAreaScroll), new UIPropertyMetadata(new Rect(0, 0, 32, 32)));
        public Rect ViewportRect
        {
            get { return (Rect)GetValue(ViewportRectProperty); }
            set { SetValue(ViewportRectProperty, value); }
        }

    }
}
