using BitEdLib.IO;
using BitEdLib.Model.Assets.Sprite;
using BitEdTool.Util;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using sysIO = System.IO;
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
        private FileInfo assetFileInfo;
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
        public FileInfo AssetFileInfo {
            get { return assetFileInfo; }
            set
            {
                if(assetFileInfo != value)
                {
                    assetFileInfo = value;
                    RaisePropertyChanged("AssetFileInfo");
                }
            }
        }
        public EAssetError ErrorType { get; set; }
        public SpriteFrameViewModel(SpriteFrame model)
        {
            this.Model = model;
            this.assetFileInfo = new FileInfo();
        }
        private void LoadAsset()
        {
            if(!sysIO.File.Exists(filePath))
            {
                ErrorType = EAssetError.IOFileNotFound;
            }
            else
            {
                try
                {
                    byte[] imageBytes = sysIO.File.ReadAllBytes(filePath);
                    AssetSource = BytesConverter.GetBitmapFromBytes(imageBytes);
                    sysIO.FileInfo fileInfo = new sysIO.FileInfo(filePath);
                    FileInfo assetInfo = new FileInfo(fileInfo.CreationTime, fileInfo.Extension, fileInfo.Length);
                    AssetFileInfo = assetFileInfo;
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
