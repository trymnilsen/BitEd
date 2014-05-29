using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using BitEdTool.Messages.Assets;
using BitEdLib.Model.Assets;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows;
using BitEdTool.ViewModel.Inspector;

namespace BitEdTool.ViewModel.Asset
{
    public class AssetListEntryViewModel:DocumentViewModel, IInspectable
    {
        private Point viewportPosition;
        private Point viewportLastPoint;
        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand OpenCommand { get; private set; }
        public RelayCommand<MouseEventArgs> MouseMoveCommand { get; set; }
        private ObservableCollection<IInspectableComponent> inspectableComponents;
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
            inspectableComponents = new ObservableCollection<IInspectableComponent>();
            viewportPosition = new Point();
            viewportLastPoint = new Point();
        }
        //Commands
        void OpenAsset()
        {
            Debug.WriteLine("Opening " + Model.Name);
            RequestOpenAssetMessage.Send(this);
        }
        void ScrollScreen(MouseEventArgs e)
        {
            if (e.MiddleButton != MouseButtonState.Pressed) return;

            UIElement element = e.OriginalSource as UIElement;
            Point point = e.GetPosition(element);

            float deltaX = (float)point.X - (float)viewportLastPoint.X;
            float deltaY = (float)point.Y - (float)viewportLastPoint.Y;

            Debug.WriteLine("Moving2" + deltaX + "/" + deltaY);
            viewportPosition.X += deltaX;
            viewportPosition.Y += deltaY;
            viewportLastPoint = point;
            //RaisePropertyChanged("BackgroundScrollViewport");
        }
        public string InspectableName
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
            }
        }

        public string InspectableTag
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool InspectorCanSetName
        {
            get { return true; }
        }

        public bool InspectorCanSetTag
        {
            get { return false; }
        }

        public virtual IEnumerable<IInspectableComponent> InspectableComponents
        {
            get { return inspectableComponents; }
            set
            {
                inspectableComponents = (ObservableCollection<IInspectableComponent>)value;
            }
        }

    }
}
