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
    }
}
