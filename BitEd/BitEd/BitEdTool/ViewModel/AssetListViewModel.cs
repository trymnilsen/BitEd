﻿using BitEdLib.Application;
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
using System.Diagnostics;
using System.Collections;

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
            //Commands
            AddScreenCommand = new RelayCommand(AddScreen);
            AddSpriteCommand = new RelayCommand(AddSprite);
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
        //event handlers for model collections
        private void AssetCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Type assetType = e.NewItems[0].GetType();
            BaseAsset addedAsset = e.NewItems[0] as BaseAsset;
            if(addedAsset == null)
            {
                Debug.WriteLine("Added Asset was Null");
                throw new ArgumentNullException("Added Asset was null");
            }
            Debug.WriteLine("Adding " + addedAsset.Name);
            if(assetType == typeof(AssetScreen))
            {
                //Does the model exists in our viewmodels?
               if(!ModelExistInViewModels(screenViewModels,addedAsset))
               {
                   AssetListEntryViewModel assetVM = new AssetListEntryViewModel(addedAsset);
                   screenViewModels.Add(assetVM);
               }
            }
            else if(assetType == typeof(AssetSprite))
            {
                //Does the model exists in our viewmodels?
                if (!ModelExistInViewModels(spriteViewModels, addedAsset))
                {
                    AssetListEntryViewModel assetVM = new AssetListEntryViewModel(addedAsset);
                    spriteViewModels.Add(assetVM);
                }
            }
            else if(assetType == typeof(AssetObject))
            {

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
