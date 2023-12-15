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
            FarmAnimal artie = new FarmAnimal("Aardvark", "sniff");
            Sheep gary = new Sheep();
            
            Tractor teri = new Tractor();

            Egg egg1 = roberta.LayEgg();
            


            Console.WriteLine($"{gary.Name} makes the sound {gary.Sound}");
            ISingable[] singables = new ISingable[] { fred, roberta, caleb, artie, gary, teri };
            

            foreach (ISingable item in singables)
            {
                SingSong(item);
            }

            ISellable[] sellables = new ISellable[] { caleb, gary };
            SellStuff(gary);
            SellStuff(caleb);

            SellStuff(egg1);

        }

        static void SingSong(ISingable item)
        {
            Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
            Console.WriteLine("And on his farm he had a " + item.Name + ", ee ay ee ay oh!");
            Console.WriteLine("With a " + item.Sound + " " + item.Sound + " here");
            Console.WriteLine("And a " + item.Sound + " " + item.Sound + " there");
            Console.WriteLine("Here a " + item.Sound + " there a " + item.Sound + " everywhere a " + item.Sound + " " + item.Sound);
            Console.WriteLine();
        }

        static void SellStuff(ISellable sellable)
        {
            Console.WriteLine(sellable.Buy());
        }
    }
}