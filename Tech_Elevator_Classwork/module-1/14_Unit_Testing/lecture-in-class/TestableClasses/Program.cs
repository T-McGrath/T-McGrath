using System;
using TestableClasses.Classes;

namespace TestableClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            LoopsAndArrayExercises loopy = new LoopsAndArrayExercises();
            //middle way
            int[] array1 = { 40, 50, 60 };
            int[] array2 = { 400, 500, 600 };
            int[] answer = loopy.MiddleWay(array1, array2);
            //Console.WriteLine("The array gives us back the first number is: " +answer[1] + "and the second number is: , " + answer[2]);
            Console.WriteLine(loopy.ArrayDisplay(answer));
        }
    }
}
