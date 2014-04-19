using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BitEdTool.ViewModel
{
    public class ScreenEditViewModel : ViewModelBase
    {
        private Point position;
        private Point lastPoint; 
        public RelayCommand<MouseEventArgs> MouseMoveCommand { get; set; }
        public RelayCommand<MouseButtonEventArgs> MousePressCommand { get; set; }
        public ObservableCollection<ScreenViewModel> ActiveScreens { get; set; }

        public Rect BackgroundScrollViewPort
        {
            get { return new Rect(position.X % 16, position.Y % 16, 16, 16); } 
        }

        public ScreenEditViewModel()
        {
            ActiveScreens = new ObservableCollection<ScreenViewModel>();
            MouseMoveCommand = new RelayCommand<MouseEventArgs>(ScrollScreen);
            lastPoint = new Point();
            position = new Point();
            ActiveScreens.Add(new ScreenViewModel());
        }
        void ScrollScreen(MouseEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                UIElement element = e.OriginalSource as UIElement;
                Point point = e.GetPosition(element);

                float deltaX = (float)point.X - (float)lastPoint.X;
                float deltaY = (float)point.Y - (float)lastPoint.Y;

                Debug.WriteLine("Moving" + deltaX + "/"+deltaY);
                position.X += deltaX;
                position.Y += deltaY;
                lastPoint = point;
                RaisePropertyChanged("BackgroundScrollViewPort");
            }
        }
    }
}
