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
using BitEdTool.ViewModel.Asset;
using System.Diagnostics;
using System.Collections;

namespace BitEdTool.ViewModel
{
    public class AssetListViewModel:ToolViewModel
    {
        private AssetListEntryViewModel selectedSprite;
        private AssetListEntryViewModel selectedScreen;
        private AssetListEntryViewModel selectedObject;

        private ObservableCollection<AssetListEntryViewModel> screenViewModels;
        private ObservableCollection<AssetListEntryViewModel> spriteViewModels;
        private ObservableCollection<AssetListEntryViewModel> objectViewModels;
        //Commands
        public RelayCommand AddScreenCommand { get; set; }
        public RelayCommand AddSpriteCommand { get; set; }
        public RelayCommand AddObjectCommand { get; set; }
        //Selected Entities
        public AssetListEntryViewModel SelectedSprite {
            get { return selectedSprite; }
            set
            {
                if(selectedSprite != value)
                {
                    selectedSprite = value;
                    RaisePropertyChanged("SelectedSprite");
                    SelectedAssetChangedMessage.Send(value);
                }
            }
        }
        public AssetListEntryViewModel SelectedScreen
        {
            get { return selectedScreen; }
            set
            {
                if (selectedScreen != value)
                {
                    selectedScreen = value;
                    RaisePropertyChanged("SelectedScreen");
                    SelectedAssetChangedMessage.Send(value);
                }
            }
        }
        public AssetListEntryViewModel SelectedObject
        {
            get { return selectedObject; }
            set
            {
                if (selectedObject != value)
                {
                    selectedObject = value;
                    RaisePropertyChanged("SelectedObject");
                    SelectedAssetChangedMessage.Send(value);
                }
            }
        }
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
            //Commands
            AddScreenCommand = new RelayCommand(AddScreen);
            AddSpriteCommand = new RelayCommand(AddSprite);
            AddObjectCommand = new RelayCommand(AddObject);
            //assetViewModels
            screenViewModels = new ObservableCollection<AssetListEntryViewModel>();
            spriteViewModels = new ObservableCollection<AssetListEntryViewModel>();
            objectViewModels = new ObservableCollection<AssetListEntryViewModel>();
            //Collection events
            App.ApplicationContainer.ProjectObjects.CollectionChanged += AssetCollectionChanged;
            App.ApplicationContainer.ProjectScreens.CollectionChanged += AssetCollectionChanged;
            App.ApplicationContainer.ProjectSprites.CollectionChanged += AssetCollectionChanged;
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
        void AddObject()
        {
            App.AddObject();
        }
        //event handlers for model collections
        private void AssetCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            BaseAsset addedAsset = e.NewItems[0] as BaseAsset;
            if(addedAsset == null)
            {
                Debug.WriteLine("Added Asset was Null");
                throw new ArgumentNullException("Added Asset was null");
            }
            Debug.WriteLine("Adding " + addedAsset.Name);
            if (addedAsset is AssetScreen)
            {
                //Does the model exists in our viewmodels?
               if(!ModelExistInViewModels(screenViewModels,addedAsset))
               {
                   AssetListEntryViewModel assetVM = new AssetListEntryViewModel(addedAsset);
                   screenViewModels.Add(assetVM);
               }
            }
            else if (addedAsset is AssetSprite)
            {
                //Does the model exists in our viewmodels?
                if (!ModelExistInViewModels(spriteViewModels, addedAsset))
                {
                    SpriteViewModel assetVM = new SpriteViewModel(addedAsset as AssetSprite);
                    spriteViewModels.Add(assetVM);
                }
            }
            else if(addedAsset is AssetObject)
            {
                if(!ModelExistInViewModels(objectViewModels,addedAsset))
                {
                    ObjectViewModel objectVM = new ObjectViewModel(addedAsset as AssetObject);
                }
            }
        }
        
        private bool ModelExistInViewModels(IEnumerable collection, BaseAsset model)
        {
            if (model == null)
                return false;

            foreach(AssetListEntryViewModel assetVM in collection)
            {
                if(assetVM.Model==model)
                {
                    return true;
                }
            }
            return false;
        }
        


}
}
