/*
 * Grading ID: E3780
 * Program: 1A
 * Due Date: September 21 2020
 * Course: CIS 200-76
 * Description: Creates the GroundPackage class.
 */

using System;

namespace shipper_v3
{
    class GroundPackage : Package
    {
        /*
         * Preconditions: All fields are not null.
         * Postcondition: A GroundPackage object is created.
         */
        public GroundPackage(Address origin, Address destination, double length, double width,
            double height, double weight) : base(origin, destination, length, width, height, weight)
        {
            // This area is left blank. Everything in the constructor is passed to the Package class.
        }

        /*
         * Preconditions: None
         * Postcondition: The distance (0-9) between two ZIP codes is returned.
         */
        public int ZoneDistance
        {
            get
            {
                const int DIVIDER = 10000; // Cheat to get us a whole number
                int larger,   // The larger ZIP
                    smaller,  // The smaller ZIP
                    distance; // The distance (based on ZIP) between destinations

                larger = Math.Max(OriginAddress.Zip, DestinationAddress.Zip);
                smaller = Math.Min(OriginAddress.Zip, DestinationAddress.Zip);

                distance = (larger / DIVIDER) - (smaller / DIVIDER);

                return distance;
            }
        }

        /*
         * Preconditions: None
         * Postcondition: Returns the cost to send a package between two destinations.
         */
        public override decimal CalcCost()
        {
            const double DIMENSION_CHARGE = 0.15, // Cost multiplied by total dimensions
                DISTANCE_CHARGE = 0.07;           // Cost multiplied by total distance

            const int ZONE_MIN = 1; // The minimum distance to charge between zones.

            return Convert.ToDecimal((DIMENSION_CHARGE * (Length + Width + Height)) + (DISTANCE_CHARGE * (ZoneDistance + ZONE_MIN) * Weight));
        }

        /*
         * Preconditions: None
         * Postcondition: Returns a formatted string.
         */
        public override string ToString() => base.ToString() + $"{Environment.NewLine}Zone Distance: {ZoneDistance}";
    }
}
