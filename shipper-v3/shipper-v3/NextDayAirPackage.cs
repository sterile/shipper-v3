/*
 * Grading ID: E3780
 * Program: 1A
 * Due Date: September 21 2020
 * Course: CIS 200-76
 * Description: Creates the NextDayAirPackage class.
 */

using System;

namespace shipper_v3
{
    class NextDayAirPackage : AirPackage
    {
        private decimal _expressFee; // Backing field for the express fee.

        /*
         * Preconditions: All arguments are not null.
         * Postcondition: A NextDayAirPackage object is created.
         */
        public NextDayAirPackage(Address origin, Address destination, double length, double width, double height,
            double weight, decimal expressFee) : base(origin, destination, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }

        public decimal ExpressFee
        {
            /*
            * Preconditions: None
            * Postcondition: The express fee is returned.
            */
            get => _expressFee;

            /*
             * Preconditions: The express fee is greater than $0.00
             * Postcondition: The express fee is set to the value provided.
             */
            private set
            {
                if (value <= decimal.Zero)
                    throw new ArgumentOutOfRangeException(nameof(ExpressFee), value, $"{nameof(ExpressFee)} must be greater than {decimal.Zero:C}.");

                _expressFee = value;
            }
        }

        /*
         * Preconditions: None
         * Postcondition: Returns the cost to send a package between two destinations.
         */
        public override decimal CalcCost()
        {
            decimal baseCharge,             // The base charge for shipping
                heavyCharge = decimal.Zero, // The additional fee for a heavy shipment.
                largeCharge = decimal.Zero, // The additional fee for a large shipment.
                dimensions,                 // Overall dimensions of the package.
                weight;                     // Overall weight of the package.

            const decimal BASE_DIMENSION_CHARGE = 0.35M, // Cost multiplied by total dimensions
                BASE_WEIGHT_CHARGE = 0.25M,              // Cost multiplied by total weight
                HEAVY_CHARGE = 0.20M,                    // Surcharge for a heavy package
                LARGE_CHARGE = 0.22M;                    // Surcharge for a large package

            weight = Convert.ToDecimal(Weight);
            dimensions = Convert.ToDecimal(Length + Width + Height);

            baseCharge = (BASE_DIMENSION_CHARGE * dimensions) + (BASE_WEIGHT_CHARGE * weight) + ExpressFee;

            if (IsHeavy())
                heavyCharge = HEAVY_CHARGE * weight; // Calculate heavy charge

            if (IsLarge())
                largeCharge = LARGE_CHARGE * dimensions; // Calculate large charge

            return baseCharge + heavyCharge + largeCharge;
        }
    }
}
