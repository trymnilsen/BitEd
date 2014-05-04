using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdTool.Messages.Assets;
using BitEdLib.Model.Assets;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows;

namespace BitEdTool.ViewModel.Asset
{
    public class AssetListEntryViewModel:DocumentViewModel
    {
        private Point viewportPosition;
        private Point viewportLastPoint;
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand OpenCommand { get; private set; }
        public RelayCommand<MouseEventArgs> MouseMoveCommand { get; set; }
        public Rect BackgroundScrollViewport
        {
            get { return new Rect(viewportPosition.X % 16, viewportPosition.Y % 16, 16, 16); }
        }

        public AssetListEntryViewModel(BaseAsset model)
            :base(model)
        {
            this.Model = model;
            OpenCommand = new RelayCommand(OpenAsset);
            MouseMoveCommand = new RelayCommand<MouseEventArgs>(ScrollScreen);
        }
        //Commands
        void OpenAsset()
        {
            Debug.WriteLine("Opening " + Model.Name);
            RequestOpenAssetMessage.Send(this);
        }
        void ScrollScreen(MouseEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                UIElement element = e.OriginalSource as UIElement;
                Point point = e.GetPosition(element);

                float deltaX = (float)point.X - (float)viewportLastPoint.X;
                float deltaY = (float)point.Y - (float)viewportLastPoint.Y;

                Debug.WriteLine("Moving" + deltaX + "/" + deltaY);
                viewportPosition.X += deltaX;
                viewportPosition.Y += deltaY;
                viewportLastPoint = point;
                RaisePropertyChanged("BackgroundScrollViewport");
            }
        }
    }
}
