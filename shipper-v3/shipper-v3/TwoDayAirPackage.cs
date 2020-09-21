using System;
using System.Collections.Generic;
using System.Text;

namespace shipper_v3
{
    class TwoDayAirPackage : AirPackage
    {
        public enum Delivery { Early, Saver };
        private Delivery _delivery;
        public TwoDayAirPackage(Address origin, Address destination, double length, double width, double height, double weight, Delivery delivery) : base(origin, destination, length, width, height, weight)
        {
            DeliveryType = delivery;
        }

        public Delivery DeliveryType
        {
            get => _delivery;
            set
            {
                if (value >= Delivery.Early && value <= Delivery.Saver)
                    throw new ArgumentOutOfRangeException(nameof(DeliveryType), value, $"{nameof(DeliveryType)} must be {Delivery.Early} or {Delivery.Saver}.");

                _delivery = value;
            }
        }

        public override decimal CalcCost()
        {
            decimal charge,
                dimensions,
                weight;

            const decimal BASE_DIMENSION_CHARGE = 0.18M,
                BASE_WEIGHT_CHARGE = 0.20M,
                SAVER_DISCOUNT = 0.85M;

            weight = Convert.ToDecimal(Weight);
            dimensions = Convert.ToDecimal(Length + Width + Height);

            charge = (BASE_DIMENSION_CHARGE * dimensions) + (BASE_WEIGHT_CHARGE * weight);

            if (DeliveryType == Delivery.Saver)
                charge *= SAVER_DISCOUNT;

            return charge;
        }
    }
}
