using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            var myClassToDemoAMethod = new LectureExample();
            Console.WriteLine("Hello World!");
            bool isGreaterThanFive = myClassToDemoAMethod.ReturnTrueWhenGreaterThanFive(89);
            Console.WriteLine($"The answer to my question is { isGreaterThanFive}");
            
        }
    }
}
