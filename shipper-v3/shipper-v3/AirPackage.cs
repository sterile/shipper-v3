using System;
using System.Collections.Generic;
using System.Text;

namespace shipper_v3
{
    abstract class AirPackage : Package
    {
        private const int HEAVY = 75,
            LARGE = 100;
        public AirPackage(Address origin, Address destination, double length, double width, double height, double weight) : base(origin, destination, length, width, height, weight)
        {
            // This area is left blank. No additional constructors needed.
        }

        public bool IsHeavy() => Weight >= HEAVY;

        public bool IsLarge() => (Length + Width + Height) >= LARGE;

        public override string ToString() => base.ToString() +
            $"{Environment.NewLine}Heavy: {IsHeavy()}" +
            $"{Environment.NewLine}Large: {IsLarge()}";
    }
}
