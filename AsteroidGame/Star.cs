using System;
using System.Drawing;

namespace AsteroidGame
{
    class Star : BaseObject
    {
        Bitmap starPNG;

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            starPNG = new Bitmap(@"star.png", true );//newSize(20, 20));
        
        }

        public override void Draw()
        {
           // buffer.Graphics.DrawImage(image, 0, 0);

            Game.buffer.Graphics.DrawImage(starPNG, pos.X, pos.Y);

           // Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
           // Game.buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0) pos.X = Game.Width + size.Width;
        }

    }
}