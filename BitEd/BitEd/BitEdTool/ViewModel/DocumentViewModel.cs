using BitEdLib.Model.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{
    public class DocumentViewModel:PaneViewModel
    {
        public BaseAsset Model { get; set; }
        public DocumentViewModel(BaseAsset asset)
        {
            this.Title = asset.Name;
        }
    }
}
