using Lecture.Farming;
using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // OLD MACDONALD
            //
            Cow fred = new Cow();
            Chicken roberta = new Chicken();
            Pig caleb = new Pig();
            //FarmAnimal artie = new FarmAnimal("Aardvark", "sniff");
            Sheep gary = new Sheep();

            //FarmAnimal[] animals;

            Tractor teri = new Tractor();

            Cat gwendolyn = new Cat();
            gwendolyn.IsAsleep = true;

            caleb.IsAsleep = true;
            gary.IsAsleep = true;

            Console.WriteLine(gary.Name + " makes the sound " + gary.Sound);
            ISingable[] singables = new ISingable[] { gwendolyn, fred, roberta, caleb, gary, teri };

            foreach (ISingable singable in singables)
            {
                SingSong(singable);
            }
            
            roberta.LayEgg();
            Console.WriteLine(roberta.Name + " laid that egg");
            FarmAnimal greg = new Chicken();
            //greg.LayEgg();
            Chicken greg2 = (Chicken)greg;
            Egg egg1 = greg2.LayEgg();

            //ISellable[] sellables = new ISellable[] { caleb, gary };
            SellStuff(gary);
            SellStuff(caleb);
            SellStuff(egg1);

            Console.WriteLine(greg.Eat());
            Console.WriteLine(greg2.Eat());
            Console.WriteLine(roberta.Eat());

        }

        static void SingSong(ISingable singable)
        {
            Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
            Console.WriteLine("And on his farm he had a " + singable.Name + ", ee ay ee ay oh!");
            Console.WriteLine("With a " + singable.Sound + " " + singable.Sound + " here");
            Console.WriteLine("And a " + singable.Sound + " " + singable.Sound + " there");
            Console.WriteLine("Here a " + singable.Sound + " there a " + singable.Sound + " everywhere a " + singable.Sound + " " + singable.Sound);
            Console.WriteLine();
        }

        static void SellStuff(ISellable sellable)
        {
            Console.WriteLine(sellable.Buy());
        }
    }
}