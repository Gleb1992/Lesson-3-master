using System;
using System.Drawing;

namespace AsteroidGame
{
    abstract class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        abstract public void Draw();

        abstract public void Update();
    }
}