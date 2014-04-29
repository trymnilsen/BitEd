﻿using GalaSoft.MvvmLight;
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
    public class WorkspaceViewModel : ViewModelBase
    {
        private Point position;
        private Point lastPoint;
        private bool showScene;
        public RelayCommand ShowSceneCommand { get; set; }
        public RelayCommand<MouseEventArgs> MouseMoveCommand { get; set; }
        public RelayCommand<MouseButtonEventArgs> MousePressCommand { get; set; }
        public ObservableCollection<ScreenViewModel> ActiveScreens { get; set; }
        public ObservableCollection<ToolViewModel> OpenTools { get; set; }

        public Rect BackgroundScrollViewPort
        {
            get { return new Rect(position.X % 16, position.Y % 16, 16, 16); } 
        }

        public WorkspaceViewModel()
        {
            ActiveScreens = new ObservableCollection<ScreenViewModel>();
            OpenTools = new ObservableCollection<ToolViewModel>();
            MouseMoveCommand = new RelayCommand<MouseEventArgs>(ScrollScreen);
            ShowSceneCommand = new RelayCommand(MakeSceneVisisble);
            lastPoint = new Point();
            position = new Point();
            ActiveScreens.Add(new ScreenViewModel());
            OpenTools.Add(new ToolViewModel("Scene","SceneViewTop"));
            OpenTools.Add(new AssetViewModel("SceneViewBottom"));
            OpenTools.Add(new ToolViewModel("Footer", "FooterLeft"));
            OpenTools.Add(new TimelineViewModel("Timeline", "FooterRight"));
            OpenTools.Add(new ToolViewModel("Output", "FooterLeft"));
            OpenTools.Add(new ToolViewModel("Inspector","Inspector"));
        }
        void MakeSceneVisisble()
        {
            //Debug.WriteLine("Changing show scene" + ShowScene);
            //ShowScene = !ShowScene;
            //Debug.WriteLine("ShowScene changed to" + ShowScene);
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
