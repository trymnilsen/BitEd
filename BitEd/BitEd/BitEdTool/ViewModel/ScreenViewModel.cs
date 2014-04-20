using BitEdLib.Model.Entity;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{ 
    public class ScreenViewModel:PaneViewModel
    {
        public GameScreen model;
        public ScreenViewModel()
        {
            model = new GameScreen();
            model.Name = "Screen";
            this.Title = "Yadda";
        }
    }
}
