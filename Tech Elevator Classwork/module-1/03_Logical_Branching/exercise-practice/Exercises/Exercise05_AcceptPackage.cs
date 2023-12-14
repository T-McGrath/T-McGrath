using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Exercises.LogicalBranching
{
    /*
     * Scamper Shipping Company specializes in small, local deliveries.
     * The problems below ask you to implement logic if they can accept a package for delivery.
     *
     * Note: all weights are in pounds, and all dimensions are in inches.
     */
    public class PackageAcceptance
    {
        // You can use these constants in your solutions.
        private const int MaxWeightPounds = 40;
        private const int MaxCubicInches = 6912;
        private const int MaxDimensionInches = 66;

        /*
         * Scamper Shipping accepts packages as long as they are 40 pounds or less.
         * Implement the logic to determine if Scamper Shipping accepts a package based on the weight provided.
         * 
         * AcceptPackage(20) ➔ true
         * AcceptPackage(40) ➔ true
         * AcceptPackage(50) ➔ false
         */
        public bool AcceptPackage(int weightInPounds)
        {
            return false;
        }
        
        /*
         * Scamper Shipping delivers packages by hand, and some packages can be awkward to carry.
         * Scamper decides that in addition to the package being no more than 40 pounds, they must also limit its size.
         * Scamper won't deliver packages greater than four cubic feet (6912 cubic inches).
         * 
         * Implement the logic to determine if Scamper Shipping accepts a package based on the weight, length, width, and height provided.
         * NOTE: You can calculate cubic inches by multiplying the length, width, and height.
         *
         * AcceptPackage(20, 4, 5, 10) ➔ true
         * AcceptPackage(40, 10, 20, 50) ➔ false
         * AcceptPackage(50, 4, 5, 10) ➔ false
         */
        public bool AcceptPackage(int weightInPounds, int lengthInInches, int widthInInches, int heightInInches)
        {
            return false;
        }

        /* 
         * All was well until a customer showed up with a 16-foot garden hose laid out straight in a 2x2x194 inch shipping box.
         * The package was less than the weight and cubic foot restrictions, but at over 16 feet long,
         * it couldn't fit in the van, and they needed to tie it to the roof. So, they added another rule.
         * 
         * In addition to weighing no more than 40 pounds and not more than four cubic feet,
         * no single dimension can be greater than five and a half feet (66 inches) without paying a surcharge.
         * 
         * Implement the logic to determine if Scamper Shipping accepts a package based on
         * the weight, length, width, and height provided, as well as if they've paid the surcharge.
         * 
         * AcceptPackage(20, 4, 5, 10, false) ➔ true
         * AcceptPackage(40, 10, 20, 50, true) ➔ false
         * AcceptPackage(40, 10, 10, 69, false) ➔ false
         * AcceptPackage(40, 10, 10, 69, true) ➔ true
         * AcceptPackage(40, 10, 10, 70, true) ➔ false
         * AcceptPackage(50, 4, 5, 10, true) ➔ false
         */
        public bool AcceptPackage(int weightInPounds, int lengthInInches, int widthInInches, int heightInInches, bool isSurchargePaid)
        {
            return false;
        }
    }
}
