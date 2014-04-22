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
        public EntityGameScreen model;
        public ScreenViewModel()
        {
            model = new EntityGameScreen();
            model.Name = "Screen";
            this.Title = "Yadda";
        }
    }
}
