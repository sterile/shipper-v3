/*
 * Grading ID: E3780
 * Program: 1A
 * Due Date: September 21 2020
 * Course: CIS 200-76
 * Description: Creates the TwoDayAirPackage class.
 */

using System;

namespace shipper_v3
{
    class TwoDayAirPackage : AirPackage
    {
        public enum Delivery { Early, Saver }; // An enum with the values Early and Saver.
        private Delivery _delivery; // Backing field for the Delivery enum.

        /*
         * Preconditions: All arguments are not null.
         * Postcondition: A TwoDayAirPackage object is created.
         */
        public TwoDayAirPackage(Address origin, Address destination, double length, double width, double height,
            double weight, Delivery delivery) : base(origin, destination, length, width, height, weight)
        {
            DeliveryType = delivery;
        }

        public Delivery DeliveryType
        {
            /*
             * Preconditions: None
             * Postcondition: The delivery type is returned.
             */
            get => _delivery;

            /*
             * Preconditions: The value provided is a valid Delivery type.
             * Postcondition: DeliveryType is set to the value provided.
             */
            set
            {
                if (!Enum.IsDefined(typeof(Delivery), value))
                    throw new ArgumentOutOfRangeException(nameof(DeliveryType), value, $"{nameof(DeliveryType)} must be {Delivery.Early} or {Delivery.Saver}.");

                _delivery = value;
            }
        }

        /*
         * Preconditions: None
         * Postcondition: Returns the cost to send a package between two destinations.
         */
        public override decimal CalcCost()
        {
            decimal charge, // The overall cost for shipping
                dimensions, // Dimensions of the package
                weight;     // Weight of the package

            const decimal BASE_DIMENSION_CHARGE = 0.18M, // Cost multiplied by total dimensions
                BASE_WEIGHT_CHARGE = 0.20M,              // Cost multiplied by total weight
                SAVER_DISCOUNT = 0.85M;                  // Discount for selecting the saver option

            weight = Convert.ToDecimal(Weight);
            dimensions = Convert.ToDecimal(Length + Width + Height);

            charge = (BASE_DIMENSION_CHARGE * dimensions) + (BASE_WEIGHT_CHARGE * weight);

            if (DeliveryType == Delivery.Saver)
                charge *= SAVER_DISCOUNT; // Apply saver discount

            return charge;
        }
    }
}
