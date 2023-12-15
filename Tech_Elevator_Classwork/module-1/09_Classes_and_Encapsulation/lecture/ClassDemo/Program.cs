namespace ClassDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle firstTriangle = new Triangle(7, 8 , 9.5);
            Console.WriteLine($"A triangle has {Triangle.NumberOfSides} sides.");
            Console.WriteLine("The first triangle's height is " + firstTriangle.Height + ".");
            Console.WriteLine("The first triangle's fill color is " + firstTriangle.FillColor + ".");
            firstTriangle.Base = 7;
            firstTriangle.Side2Length = 7;
            firstTriangle.Side3Length = 7;
            firstTriangle.Height = 9;
            firstTriangle.FillColor = "FFFFFF";
            firstTriangle.OutlineColor = "000000";
            double firstTrianglePerimeter = firstTriangle.CalculatePerimeter();
            Console.WriteLine("The first triangle's perimeter is " + firstTrianglePerimeter + ".");
            Console.WriteLine("The first triangle's area is " + firstTriangle.CalculateArea() + ".");
        }
    }
}