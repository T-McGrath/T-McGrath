﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Egg : ISellable
    {
        public string Name { get; } = "Egg";

        public decimal Price { get; } = 0.25M;

        public string Buy()
        {
            return $"Each {Name} costs ${Price}.";
        }
    }
}
