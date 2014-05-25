using BitEdLib.Model.Assets;
using BitEdLib.Model.Node;
using BitEdTool.Messages.Assets;
using BitEdTool.ViewModel.Inspector;
using BitEdTool.ViewModel.Node;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel.Asset
{
    public class ObjectViewModel:AssetListEntryViewModel, IInspectable
    {
        private object _selectedNode;
        public ObservableCollection<NodeViewModel> Nodes { get; set; }
        public Object SelectedNode
        {
            get { return _selectedNode; }
            set
            {
                if(_selectedNode != value)
                {
                    _selectedNode = value;
                    RaisePropertyChanged("SelectedNode");
                }
            }
        }
        public ObjectViewModel(AssetObject model)
            :base(model)
        {
            Nodes = new ObservableCollection<NodeViewModel>();
            //Add model to nodes
            //Create a viewmodel for it
            NodeViewModel nodeVM = new NodeViewModel(model);
            Nodes.Add(nodeVM);
        }
        

    }
}
