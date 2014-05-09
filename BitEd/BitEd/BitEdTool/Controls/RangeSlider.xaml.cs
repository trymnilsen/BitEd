using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for RangeSlider.xaml
    /// </summary>
    public partial class RangeSlider : UserControl
    {
        private static Point zeroPoint = new Point(0, 0);

        public RangeSlider()
        {
            InitializeComponent();
            SizeChanged += RangeSlider_SizeChanged;
            //
            GripWidth = 15;
        }

        void RangeSlider_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ActualSnap = CalculateSnapValue();
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (sender is Thumb)
            {
                Thumb dragged = sender as Thumb;
                double currentPos = dragged.TranslatePoint(zeroPoint, CanvasContainer).X + e.HorizontalChange;
                //Do some checks
                //1 Do not let it go out of bounds
                //2 Do not let it go past the other slider
                currentPos = Clamp(currentPos, 0, CanvasContainer.ActualWidth - 15);
                if(SnapToSnaps)
                {
                    currentPos = Math.Round(currentPos / ActualSnap) * ActualSnap;
                }
                if (dragged.Name == "LeftThumb")
                {
                    if (true || currentPos <= RightValue - GripWidth)
                    {
                        LeftValue = currentPos;
                        Canvas.SetLeft(dragged, currentPos);
                    }

                }
                else if (dragged.Name == "RightThumb")
                {
                    if (true || currentPos >= LeftValue + GripWidth)
                    {
                        RightValue = currentPos;
                        Canvas.SetLeft(dragged, currentPos);
                    }
                }
            }
        }

        private void CanvasContainer_Loaded(object sender, RoutedEventArgs e)
        {
            LeftValue = 0;
            RightValue = CanvasContainer.ActualWidth - 15;
            if(FullTrackBar)
            {
                ActiveTrack.Height = 14;
                Canvas.SetTop(ActiveTrack, 0);
            }
            ActualSnap = CalculateSnapValue();
        }
        private double CalculateSnapValue()
        {
            double snapFactor = Snap / (Maximum - Minimum);
            double calculatedSnap = ActualWidth * snapFactor;
            return calculatedSnap;
        }
        private double Clamp(double value, double min, double max)
        {
            if (value >= max)
            {
                return max;
            }
            if (value <= min)
            {
                return min;
            }
            return value;
        }
        ///////////////////
        //dependency Properties

        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(RangeSlider),new UIPropertyMetadata(0d));
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(RangeSlider),new UIPropertyMetadata(10d));
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty LeftValueProperty = DependencyProperty.Register("LeftValue", typeof(double), typeof(RangeSlider));
        public double LeftValue
        {
            get { return (double)GetValue(LeftValueProperty); }
            set { SetValue(LeftValueProperty, value); }
        }

        public static readonly DependencyProperty RightValueProperty = DependencyProperty.Register("RightValue", typeof(double), typeof(RangeSlider));
        public double RightValue
        {
            get { return (double)GetValue(RightValueProperty); }
            set { SetValue(RightValueProperty, value); }
        }

        public static readonly DependencyProperty SnapProperty = DependencyProperty.Register("Snap", typeof(double), typeof(RangeSlider), new UIPropertyMetadata(1d));
        public double Snap
        {
            get { return (double)GetValue(SnapProperty); }
            set { SetValue(SnapProperty, value); }
        }
        public static readonly DependencyProperty ActualSnapProperty = DependencyProperty.Register("ActualSnap", typeof(double), typeof(RangeSlider), new UIPropertyMetadata(1d));
        public double ActualSnap
        {
            get { return (double)GetValue(ActualSnapProperty); }
            set { SetValue(ActualSnapProperty, value); }
        }

        public static readonly DependencyProperty SnapToSnapsProperty = DependencyProperty.Register("SnapToSnaps", typeof(bool), typeof(RangeSlider), new UIPropertyMetadata(false));
        public bool SnapToSnaps
        {
            get { return (bool)GetValue(SnapToSnapsProperty); }
            set { SetValue(SnapToSnapsProperty, value); }
        }
        public static readonly DependencyProperty FullTrackBarProperty = DependencyProperty.Register("FullTrackBar", typeof(bool), typeof(RangeSlider), new UIPropertyMetadata(false));
        public bool FullTrackBar
        {
            get { return (bool)GetValue(FullTrackBarProperty); }
            set { SetValue(FullTrackBarProperty, value); }
        }

        public static readonly DependencyProperty GripWidthProperty = DependencyProperty.Register("GripWidth", typeof(double), typeof(RangeSlider), new UIPropertyMetadata(10d));
        public double GripWidth
        {
            get { return (double)GetValue(GripWidthProperty); }
            set { SetValue(GripWidthProperty, value); }
        }
        public static readonly DependencyProperty TrackBackgroundProperty = DependencyProperty.Register("TrackBackground", typeof(Brush), typeof(RangeSlider), new UIPropertyMetadata());
        public Brush TrackBackground
        {
            get { return (Brush)GetValue(TrackBackgroundProperty); }
            set { SetValue(TrackBackgroundProperty, value); }
        }
    }
}
