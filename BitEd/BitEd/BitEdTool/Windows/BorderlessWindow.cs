using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BitEdTool.Windows
{
    public class BorderlessWindow : Window, INotifyPropertyChanged
    {
        public Thickness WindowStateMargin
        {
            get
            {
                if(WindowState == WindowState.Maximized)
                {
                    Debug.WriteLine("Maximize Thinkness");
                    return new Thickness(8,10,8,10);
                }
                else
                {
                    return new Thickness(0);
                }
            }
        }
        public BorderlessWindow()
            : base()
        {
            this.DataContext = this;
        }
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            RaisePropertyChanged("WindowStateMargin");
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            else
            {
                Debug.WriteLine("hhdsf");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
