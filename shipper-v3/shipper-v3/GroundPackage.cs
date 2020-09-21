using System;
using System.Collections.Generic;
using System.Text;

namespace shipper_v3
{
    class GroundPackage : Package
    {
        public GroundPackage(Address origin, Address destination, double length, double width, double height, double weight) : base(origin, destination, length, width, height, weight)
        {
            // This area is left blank. No additional constructors needed.
        }
        public int ZoneDistance
        {
            get
            {
                const int DIVIDER = 10000; // Cheat to get us a whole number
                int larger,   // The larger number
                    smaller,  // The smaller number
                    distance; // The distance (based on ZIP) between destinations

                larger = Math.Max(OriginAddress.Zip, DestinationAddress.Zip);
                smaller = Math.Min(OriginAddress.Zip, DestinationAddress.Zip);

                distance = (larger / DIVIDER) - (smaller / DIVIDER);

                return distance;
            }
        }

        public override decimal CalcCost()
        {
            const double DIMENSION_CHARGE = 0.15,
                DISTANCE_CHARGE = 0.07;

            const int ZONE_MIN = 1;

            return Convert.ToDecimal((DIMENSION_CHARGE * (Length + Width + Height)) + (DISTANCE_CHARGE * (ZoneDistance + ZONE_MIN) * Weight));
        }

        public override string ToString() => base.ToString() + $"{Environment.NewLine}Zone Distance: {ZoneDistance}";
    }
}
