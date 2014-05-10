using BitEdLib.IO;
using BitEdLib.Model.Assets.Sprite;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BitEdTool.ViewModel.Timeline
{
    public class TimelineSpriteViewModel:ViewModelBase
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
                if(filePath != value)
                {
                    filePath = value;
                    RaisePropertyChanged("FilePath");
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
        public TimelineSpriteViewModel(SpriteFrame model)
        {
            this.Model = model;
        }
        private void LoadAsset()
        {
            using(FileStream fs = new FileStream(FilePath,FileMode.Open))
            {

            }
        }
    }
}
