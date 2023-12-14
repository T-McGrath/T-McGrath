using System;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal
    {
        public Chicken() : base("Chicken", "cluck")
        {
        }

        public Egg LayEgg()
        {
            return new Egg();
        }

        public override string Eat()
        {
            return "Pecking around the farmyard...";
        }
    }
}
