using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Cat : FarmAnimal
    {

/*        public override string Sound
        {
            get
            {
                if (IsAsleep)
                {
                    return "purrr";
                }
                return base.Sound;
            }
        }*/

        public Cat() : base("Cat", "meow")
        {
        }

        public override string Eat()
        {
            return "Being very finnicky and turning its nose up at cat food...";
        }
    }
}
