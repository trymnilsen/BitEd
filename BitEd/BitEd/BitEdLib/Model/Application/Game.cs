using BitEdLib.Model.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Application
{
    public class Game
    {
        public ObservableCollection<AssetObject> ProjectObjects { get; set; }
        public ObservableCollection<AssetScreen> ProjectScreens { get; set; }
        public ObservableCollection<AssetSprite> ProjectSprites { get; set; }

        public Game()
        {
            ProjectObjects = new ObservableCollection<AssetObject>();
            ProjectScreens = new ObservableCollection<AssetScreen>();
            ProjectSprites = new ObservableCollection<AssetSprite>();
        }
    }
}
