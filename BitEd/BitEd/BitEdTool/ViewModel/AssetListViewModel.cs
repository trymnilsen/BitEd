using BitEdLib.Application;
using BitEdLib.Model.Assets;
using BitEdTool.Messages.Assets;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdLib.Model.Assets;
using BitEdTool.ViewModel.Asset;

namespace BitEdTool.ViewModel
{
    public class AssetListViewModel:ToolViewModel
    {
        private ObservableCollection<AssetListEntryViewModel> screenViewModels;
        private ObservableCollection<AssetListEntryViewModel> spriteViewModels;
        private ObservableCollection<AssetListEntryViewModel> objectViewModels;
        //Commands
        public RelayCommand AddScreenCommand { get; set; }
        public RelayCommand AddSpriteCommand { get; set; }
        public RelayCommand AddObjectCommand { get; set; }
        //Collection
        public ObservableCollection<AssetListEntryViewModel> Screens
        {
            get { return screenViewModels; }
        }
        public ObservableCollection<AssetListEntryViewModel> Sprites
        {
            get { return spriteViewModels; }
        }
        public ObservableCollection<AssetListEntryViewModel> Objects
        {
            get { return objectViewModels; }
        }
        public AssetListViewModel(Application app, string paneTarget)
            :base(app, "Assets",paneTarget)
        {
            AddScreenCommand = new RelayCommand(AddScreen);
            AddSpriteCommand = new RelayCommand(AddSprite);
        }
        
        //Command Methods
        void AddScreen()
        {
            BaseAsset screen = App.AddScreen();
            AssetListEntryViewModel screenVM = new AssetListEntryViewModel(screen);

        }
        void AddSprite()
        {
            App.AddSprite();
        }

}
}
