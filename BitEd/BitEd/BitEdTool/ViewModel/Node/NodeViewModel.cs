using BitEdLib.Model.Node;
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
using System.Windows.Controls.Primitives;

namespace BitEdTool.ViewModel.Node
{
    public class NodeViewModel:ViewModelBase
    {
        private double positionX;
        private double positionY;
        private INode model;
        public INode Model
        {
            get
            {
                return model;
            }
            set
            {
                if(value!=model)
                {
                    model = value;
                    RaisePropertyChanged("Model");
                }
            }
        }
        public double NodePositionX
        {
            get
            {
                return positionX;
            }
            set
            {
                if(value!=positionX)
                {
                    positionX = value;
                    RaisePropertyChanged("NodePositionX");
                }
            }
        }
        public double NodePositionY
        {
            get
            {
                return positionY;
            }
            set
            {
                if (value != positionY)
                {
                    positionY = value;
                    RaisePropertyChanged("NodePositionY");
                }
            }
        }
        public ObservableCollection<INodePropertry> NodeProperties { get; set; }
        public string NodeName
        {
            get { return Model.NodeName; }
        }
        public RelayCommand<DragDeltaEventArgs> DragDeltaCommand { get; set; }
        public NodeViewModel(INode node)
        {
            NodePositionX = 20;
            NodePositionY = 20;
            this.Model = node;
            this.NodeProperties = new ObservableCollection<INodePropertry>();
            foreach(INodePropertry prop in node.Properties)
            {
                NodeProperties.Add(prop);
            }
            DragDeltaCommand = new RelayCommand<DragDeltaEventArgs>(NodeDragged);
        }
        public void NodeDragged(DragDeltaEventArgs e)
        {
            NodePositionX += e.HorizontalChange;
            NodePositionY += e.VerticalChange;
            Debug.WriteLine("Hmmmzz" + NodePositionX + "/" + NodePositionY);
        }
    }
}
