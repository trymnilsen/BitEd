using BitEdLib.Model.Application;
using BitEdLib.Model.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Application
{
    public class Application
    {
        public int ScreenCreatedCount { get; private set; }
        public int SpriteCreatedCount { get; private set; }
        public int ObjectCreatedCount { get; private set; }

        public Game ApplicationContainer { get; set; }
        public Application()
        {
            ApplicationContainer = new Game();
        }
        public AssetScreen AddScreen()
        {
            AssetScreen newScreen = new AssetScreen();
            newScreen.Name = "Screen " + ScreenCreatedCount;
            ScreenCreatedCount++;

            ApplicationContainer.ProjectScreens.Add(newScreen);
            return newScreen;
        }
        public AssetSprite AddSprite()
        {
            AssetSprite newSprite = new AssetSprite();
            newSprite.Name = "Sprite " + SpriteCreatedCount;
            SpriteCreatedCount++;

            ApplicationContainer.ProjectSprites.Add(newSprite);
            return newSprite;
        }
        public AssetObject AddObject()
        {
            AssetObject newObject = new AssetObject();
            newObject.Name = "Object " + SpriteCreatedCount;
            SpriteCreatedCount++;

            ApplicationContainer.ProjectObjects.Add(newObject);
            return newObject;
        }

    }
}
