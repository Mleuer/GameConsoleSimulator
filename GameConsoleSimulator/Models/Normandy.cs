using SFML.Graphics;
using static GameConsoleSimulator.Config.Configuration;
using static GameConsoleSimulator.Util.Util;

namespace GameConsoleSimulator.Models
{
    public class Normandy : GameObject
    {
       static Texture defaultNormandyTexture = new Texture(ImageFileDirectoryPath + Slash + "Normandy.png");
       public GameObject ThanixCannon { get; }

        public Normandy() : base(defaultNormandyTexture)
        {
            this.CenterOrigin();
            this.MovementDistance = (6, 0);
            Texture laser = new Texture(ImageFileDirectoryPath + Slash + "Laser.png");
            ThanixCannon = new GameObject(laser);
            this.StowThanixCannon();
        }

        public void StowThanixCannon()
        {
            ThanixCannon.Visible = false;
        }
        public void FireThanixCannon()
        {
            ThanixCannon.Visible = true;
            
        }
        
    }
}