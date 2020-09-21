/*
 * Grading ID: E3780
 * Program: 1A
 * Due Date: September 21 2020
 * Course: CIS 200-76
 * Description: Creates the abstract AirPackage class.
 */

using System;

namespace shipper_v3
{
    abstract class AirPackage : Package
    {
        private const int HEAVY = 75, // The weight at which a package is considered heavy
            LARGE = 100;              // The dimensions at which a package is considered large

        /*
         * Preconditions: All arguments are not null.
         * Postcondition: An AirPackage object is abstractly created.
         */
        public AirPackage(Address origin, Address destination, double length, double width,
            double height, double weight) : base(origin, destination, length, width, height, weight)
        {
            // This area is left blank. No additional constructors needed.
        }

        /*
         * Preconditions: None
         * Postcondition: Returns a bool if Weight >= HEAVY
         */
        public bool IsHeavy() => Weight >= HEAVY;

        /*
         * Preconditions: None
         * Postcondition: Returns a bool if total dimensions >= LARGE.
         */
        public bool IsLarge() => (Length + Width + Height) >= LARGE;

        /*
         * Preconditions: None
         * Postcondition: Returns a formatted string.
         */
        public override string ToString() => base.ToString() +
            $"{Environment.NewLine}Heavy: {IsHeavy()}" +
            $"{Environment.NewLine}Large: {IsLarge()}";
    }
}
