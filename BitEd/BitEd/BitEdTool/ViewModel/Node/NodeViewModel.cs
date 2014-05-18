using BitEdLib.Model.Node;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public string NodeName
        {
            get { return Model.NodeName; }
        }
        public NodeViewModel(INode node)
        {
            this.Model = node;
        }
    }
}
