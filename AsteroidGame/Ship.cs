using System;
using System.Drawing;

namespace AsteroidGame
{
    class Ship : BaseObject
    {
        
        int energy = 100;
        Bitmap shipPNG;

        public int Energy
        {
            get { return energy; }
        }
        
        public void EnergyLow(int n)
        { 
            energy -= n;
        }
        
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            shipPNG = new Bitmap(@"spaceship.png", true);
        }
        
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(shipPNG, pos.X, pos.Y);
            //Game.buffer.Graphics.FillEllipse(Brushes.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }
        
        public override void Update()
        {
        }
        
        public void Up()
        {
                if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
        }
        
        public void Down()
        {
                if (pos.Y < Game.Height - 70) pos.Y = pos.Y + dir.Y;
        }

        public void Die()
        {
        
        }
     }
}

