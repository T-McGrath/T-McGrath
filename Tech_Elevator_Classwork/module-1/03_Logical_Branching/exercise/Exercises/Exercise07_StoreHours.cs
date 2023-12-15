using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Exercises.LogicalBranching
{
    /*
     * Shelia's Seashell Store has a new website. Shelia wants to display if the store is open when someone views the website.
     * The following problems have you implement the logic to indicate if the store is open.
     * 
     * You're given an integer that represents the current hour in each problem.
     * The store is open if the current hour is equal to or greater than the open time and less than the closing time.
     * 
     * Hours are represented in 24-hour format:
     *      1am = 1
     *      2am = 2...
     *      12pm = 12
     *      1pm = 13
     *      2pm = 14...
     *      11pm = 23
     *      12am = 0
     */
    public class StoreHours
    {
        /*
        * Shelia's Seashell Store is open between 8 am (hour 8) and 5 pm (hour 17).
        * Implement the logic to determine if the store is open based on the current hour.
        *
        * IsStoreOpen(8) ➔ true
        * IsStoreOpen(12) ➔ true
        * IsStoreOpen(17) ➔ false
        * IsStoreOpen(22) ➔ false 
        */   
        public bool IsStoreOpen(int currentHour)
        {
            // Needs to be closed AT 5 PM exactly.
            if (currentHour >= 8 && currentHour < 17)
            {
                return true;
            }
            return false;
        }

        /*
         * Shelia forgot to take into account the day of the week.
         * Her store is only open between 8 am (hour 8) and 5 pm (hour 17) on Monday (day M), Wednesday (day W), and Friday (day F).
         * Implement the logic to determine if the store is open based on the current hour and the current day.
         * 
         * NOTE: This problem uses a char to represent the current day of the week. You can use the following key:
         * Monday = 'M'
         * Wednesday = 'W'
         * Friday = 'F'
         * Saturday = 'S'
         * 
         * The char for the current day is only uppercase.
         * 
         * IsStoreOpen(8, 'M') ➔ true
         * IsStoreOpen(12, 'W') ➔ true
         * IsStoreOpen(12, 'S') ➔ false
         */
        public bool IsStoreOpen(int currentHour, char currentDay)
        {
            if(currentHour >= 8 && currentHour < 17)
            {
                if (currentDay == 'M' || currentDay == 'W' || currentDay == 'F')
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * Shelia's Seashell Store is open between 8 am (hour 8) and 5 pm (hour 17) on Monday (day M),
         * Wednesday (day W), and Friday (day F).
         * In the summer, the store is open for additional hours. On Wednesday (day W) the store stays
         * open until 8 pm (hour 20) and is also open Saturday (day S) from 9 am (hour 9) to 3 pm (hour 15).
         *
         * Implement the logic to determine if the store is open based on the current hour, the current day,
         * and if it's summer.
         *
         * IsStoreOpen(8, 'M', true) ➔ true
         * IsStoreOpen(12, 'W', false) ➔ true
         * IsStoreOpen(12, 'S', false) ➔ false
         * IsStoreOpen(9, 'S', true) ➔ true
         */
        public bool IsStoreOpen(int currentHour, char currentDay, bool isSummer)
        {
            if (currentDay == 'M' || (currentDay == 'W' && !isSummer) || currentDay == 'F')
            {
                if (currentHour >= 8 && currentHour < 17)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (currentDay == 'W') //&& isSummer)...don't need this, but could add it to make the code more clear?
            {
                if (currentHour >= 8 && currentHour < 20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (currentDay == 'S' && isSummer)
            {
                if (currentHour >= 9 && currentHour < 15)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
