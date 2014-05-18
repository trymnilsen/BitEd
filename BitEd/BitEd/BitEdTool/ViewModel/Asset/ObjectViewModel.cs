﻿using BitEdLib.Model.Assets;
using BitEdLib.Model.Node;
using BitEdTool.Messages.Assets;
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
        public ObservableCollection<NodeViewModel> Nodes { get; set; }
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
