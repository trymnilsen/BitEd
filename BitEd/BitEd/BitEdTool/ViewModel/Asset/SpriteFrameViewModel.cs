using BitEdLib.IO;
using BitEdLib.Model.Assets.Sprite;
using BitEdTool.Util;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BitEdTool.ViewModel.Asset
{
    public class SpriteFrameViewModel:ViewModelBase
    {
        private BitmapImage assetSource;
        private string filePath;
        //properties
        public SpriteFrame Model { get; set; }
        public string FilePath
        {
            get { return filePath; }
            set
            {
                Debug.WriteLine("SETTING PATH");
                if(filePath != value && value!="No File Selected")
                {
                    filePath = value;
                    RaisePropertyChanged("FilePath");
                    LoadAsset();
                }
            }
        }
        public BitmapImage AssetSource
        {
            get { return assetSource; }
            set
            {
                if (assetSource != value)
                {
                    assetSource = value;
                    RaisePropertyChanged("AssetSource");
                }
            }
        }
        public EAssetError ErrorType { get; set; }
        public SpriteFrameViewModel(SpriteFrame model)
        {
            this.Model = model;
        }
        private void LoadAsset()
        {
            if(!File.Exists(filePath))
            {
                ErrorType = EAssetError.IOFileNotFound;
            }
            else
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(filePath);
                    AssetSource = BytesConverter.GetBitmapFromBytes(imageBytes);
                    ErrorType = EAssetError.None;
                }
                catch(UnauthorizedAccessException uae)
                {
                    Debug.WriteLine(uae.ToString());
                    ErrorType = EAssetError.IOAccessError;
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    ErrorType = EAssetError.IOError;
                }
            }
        }
    }
}
