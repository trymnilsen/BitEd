using BitEdLib.Model.Assets;
using BitEdLib.Model.Node;
using comp = BitEdLib.Model.Logic.Components;
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
    public class ObjectViewModel:AssetListEntryViewModel
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
            //Create a viewmodels for our model data
            NodeViewModel nodeVM = new NodeViewModel(model);

            Nodes.Add(nodeVM);
           // (InspectableComponents as ObservableCollection<IInspectableComponent>).Add();
        }
        public override IEnumerable<IInspectableComponent> InspectableComponents
        {
            get { return generateComponentsList(); }
            set
            {
                base.InspectableComponents = value;
            }
        }

        private IEnumerable<IInspectableComponent> generateComponentsList()
        {
            //First fetch our properties and physics components
            //Then fetch the nodes witch are triggers/events
        }
    }
}
