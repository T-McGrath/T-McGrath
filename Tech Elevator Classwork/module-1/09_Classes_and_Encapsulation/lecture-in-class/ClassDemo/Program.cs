namespace ClassDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Triangle firstTriangle = new Triangle(7, 8, 9.5);
            //Console.WriteLine("The first triangle's number of sides is: " + firstTriangle.NumberOfSides);
            Console.WriteLine("The first triangle's height is: " + firstTriangle.Height);
            Console.WriteLine("The first triangle's fill color is: " + firstTriangle.FillColor);
            firstTriangle.Side1Length = 7;
            firstTriangle.Side2Length = 7;
            firstTriangle.Side3Length = 7;
            firstTriangle.FillColor = "FFFFFF";
            firstTriangle.OutlineColor = "000000";
            firstTriangle.Height = 9;
            double firstTrianglePerimeter = firstTriangle.CalculatePerimeter();
            Console.WriteLine("The first triangle's perimeter is " + firstTrianglePerimeter);
            Console.WriteLine("The first triangle's area is " + firstTriangle.CalculateArea());
            double theTwoSides = firstTriangle.Side1Length + firstTriangle.Side2Length;
            Triangle newTriangle = new Triangle();
            int howManySidesDoesEveryTriangleHave = Triangle.NumberOfSides;
            double calculationOfAnArea = Triangle.CalculateTheAreaOfAnyTriangle(9.5, 6.5);

        }
    }
}
