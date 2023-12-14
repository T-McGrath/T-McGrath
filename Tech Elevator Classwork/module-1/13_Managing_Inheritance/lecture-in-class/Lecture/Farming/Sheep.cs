using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{


    public class Sheep : FarmAnimal, ISellable
    {

        public decimal Price { get; }

        public Sheep() : base("Sheep", "baaa")
        {
            Price = 200;
        }

        public override string Eat()
        {
            return "Eating sheep food...";
        }


    }
}

