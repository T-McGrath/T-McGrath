using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public decimal Price { get; }

        public Pig() : base("Pig", "squeal")
        {
            Price = 3.50M;
        }

        public string Buy()
        {
            return Name + " costs an absolutely ridiculous price of $" + Price;
        }

    }
}
