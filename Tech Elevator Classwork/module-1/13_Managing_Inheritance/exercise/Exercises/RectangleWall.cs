﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class RectangleWall : Wall
    {
        public int Length { get; }
        public int Height { get; }

        public RectangleWall(string name, string color, int length, int height) : base(name, color)
        {
            Length = length;
            Height = height;
        }

        public override int GetArea()
        {
            return Length * Height;
        }

        public override string ToString()
        {
            return $"{Name} ({Length}x{Height}) rectangle";
        }
    }
}
