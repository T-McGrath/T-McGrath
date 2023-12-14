using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class Triangle
    {

        public static int NumberOfSides = 3;
        //public int NumberOfSides { get => 3; }
        public double Height { get; set; }

        public double Side1Length { get; set; }

        public double Side2Length { get; set;}

        public double Side3Length { get; set;}

        public string FillColor { get;  set; }

        public string OutlineColor { get; set; }

        public static double CalculateTheAreaOfAnyTriangle(double theBase, double height)
        {
            return (1 / 2) * theBase * height;
        }

        public double CalculateArea()
        {
            //can use the "this" keyword like this.Side1Length and this.Height if that makes it easier for you to conceptualize
            return 0.5 * Side1Length * Height;
        }

        public double CalculatePerimeter()
        {
            return Side1Length + Side2Length+ Side3Length;
        }
        public Triangle(double side1length, double side2length, double side3length)
        {

            Side1Length = side1length;
            Side2Length = side2length;
            Side3Length = side3length;
        }
        public Triangle(double height, double side1Length, double side2Length, double side3Length, string fillColor, string outlineColor)
        {
            Height = height;
            Side1Length = side1Length;
            Side2Length = side2Length;
            Side3Length = side3Length;
            FillColor = fillColor;
            OutlineColor = outlineColor;
        }

        public Triangle()
        {

        }
    }
}
