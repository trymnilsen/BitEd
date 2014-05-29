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
using BitEdLib.Model.Logic.Components;
using System.ComponentModel;
using BitEdLib.Model.Logic.Behaviours.Triggers;
using System.Windows;

namespace BitEdTool.ViewModel.Asset
{
    public class ObjectViewModel:AssetListEntryViewModel
    {
        private object selectedNode;
        private InspectorComponentViewModel physicsComponentVM;
        private InspectorComponentViewModel propertiesComponentVM;
        public ObservableCollection<NodeViewModel> Nodes { get; set; }
        public Object SelectedNode
        {
            get { return selectedNode; }
            set
            {
                if(selectedNode != value)
                {
                    selectedNode = value;
                    RaisePropertyChanged("SelectedNode");
                }
            }
        }
        public ObjectViewModel(AssetObject model)
            :base(model)
        {
            Nodes = new ObservableCollection<NodeViewModel>();
            //Create a viewmodels for our model's node data
            Nodes.Add(new NodeViewModel(new InitializeTrigger()));
            physicsComponentVM = new InspectorComponentViewModel(new PhysicsComponent());
            propertiesComponentVM = new InspectorComponentViewModel(new PropertiesComponent());
           // (InspectableComponents as ObservableCollection<IInspectableComponent>).Add();
        }

        public override IEnumerable<IInspectableComponent> InspectableComponents
        {
            get { return generateComponentsList(); }
            set { base.InspectableComponents = value; }
        }

        private IEnumerable<IInspectableComponent> generateComponentsList()
        {
            //For future trym reference this is overiden as we want to only get nodes (available in this class) with trigger as the node type as well as properties and physics
            //First fetch our properties and physics components
            //Then fetch the nodes witch are triggers/events
            List<IInspectableComponent> components = new List<IInspectableComponent>();
            components.Add(physicsComponentVM);
            components.Add(propertiesComponentVM);
            components.AddRange(Nodes.Where(x => x.Model.NodeType == ENodeType.Trigger));
            return components;
        }
    }
}
