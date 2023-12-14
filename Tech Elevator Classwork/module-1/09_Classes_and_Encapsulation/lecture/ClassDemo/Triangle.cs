using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class Triangle
    {
        // Properties (special variables, basically...capitalize first letter)
        public static int NumberOfSides { get => 3; } // => means "such that"...the get is done such that the value is 3
        public double Height { get; set; }
        public double Base {get; set;}
        public double Side2Length { get; set; }
        public double Side3Length { get; set; }
        public string FillColor { get; set; }
        public string OutlineColor { get; set; }

        // Constructor(s)
        public Triangle(double height, double theBase, double side2, double side3, string fillColor, string outlineColor)
        {
            Height = height;
            Base = theBase;
            Side2Length = side2;
            Side3Length = side3;
            FillColor = fillColor;
            OutlineColor = outlineColor;
        }

        public Triangle(double theBase, double side2, double side3)
        {
            Base = theBase;
            Side2Length = side2;
            Side3Length = side3;
        }

        public Triangle()
        {

        }

        // Methods (behavior)
        public static double CalculateTheAreaOfAnyTriangle(double theBase, double height)
        {
            return 0.5 * theBase * height;
        }
        public double CalculateArea()
        {
            return 0.5 * Base * Height; // Could use this.Base and this.Height, but it is unnecessary.
        }

        public double CalculatePerimeter()
        {
            return Base + Side2Length + Side3Length;
        }
    }
}
