using BitEdLib.Model.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{
    public class AssetViewModel:ToolViewModel
    {
        public AssetViewModel(string paneTarget)
            :base("Assets",paneTarget)
        {
            
        }
        public ObservableCollection<AssetObject> ProjectObjects { get; set; }
        public ObservableCollection<AssetScreen> ProjectScreens { get; set; }
        public ObservableCollection<AssetSprite> ProjectSprites { get; set; }
    }
}
