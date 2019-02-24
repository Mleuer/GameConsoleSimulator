using SFML.Graphics;
using static GameConsoleSimulator.Config.Configuration;
using static GameConsoleSimulator.Util.Util;

namespace GameConsoleSimulator.Models
{
    public class Normandy : GameObject
    {
       static Texture defaultNormandyTexture = new Texture(ImageFileDirectoryPath + Slash + "Normandy.png");

        public Normandy() : base(defaultNormandyTexture)
        {
            this.CenterOrigin();
            this.MovementDistance = (6, 0);
        }
        
    }
}