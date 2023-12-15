using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public abstract class Wall
    {
        public string Name { get; }
        public string Color { get; }

        public Wall(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public abstract int GetArea();
    }
}
