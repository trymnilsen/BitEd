using BitEdTool.ViewModel.Inspector;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel.Node
{
    class BehaviourViewModel:ViewModelBase,IInspectable
    {
        public string InspectableName
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
            get { throw new NotImplementedException(); }
        }

        public bool InspectorCanSetTag
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IInspectableComponent> InspectableComponents
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
        public BehaviourViewModel()
        {

        }
    }
}
