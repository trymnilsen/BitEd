using BitEdLib.Application;
using BitEdLib.Model.Assets;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{
    public class AssetViewModel:ToolViewModel
    {
        //Commands
        public RelayCommand AddScreenCommand { get; set; }
        public RelayCommand AddSpriteCommand { get; set; }
        public RelayCommand AddObjectCommand { get; set; }
        public RelayCommand<object> ClickAsset { get; set; }
        //Collection
        public ObservableCollection<AssetScreen> Screens
        {
            get { return App.ApplicationContainer.ProjectScreens; }
        }
        public ObservableCollection<AssetSprite> Sprites
        {
            get { return App.ApplicationContainer.ProjectSprites; }
        }
        public ObservableCollection<AssetObject> Objects
        {
            get { return App.ApplicationContainer.ProjectObjects; }
        }
        public AssetViewModel(Application app, string paneTarget)
            :base(app, "Assets",paneTarget)
        {
            AddScreenCommand = new RelayCommand(AddScreen);
            AddSpriteCommand = new RelayCommand(AddSprite);
        }
        
        //Command Methods
        void AddScreen()
        {
            App.AddScreen();
        }
        void AddSprite()
        {
            App.AddSprite();
        }
}
}
