﻿using System;
using System.Collections.Generic;
using System.Text;

namespace shipper_v3
{
    class NextDayAirPackage : AirPackage
    {
        private decimal _expressFee;
        public NextDayAirPackage(Address origin, Address destination, double length, double width, double height, double weight, decimal expressFee) : base(origin, destination, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }

        private decimal ExpressFee // Does the get need to be public??
        {
            get => _expressFee;
            set
            {
                if (value <= decimal.Zero)
                    throw new ArgumentOutOfRangeException(nameof(ExpressFee), value, $"{nameof(ExpressFee)} must be greater than {decimal.Zero:C}.");

                _expressFee = value;
            }
        }

        public override decimal CalcCost()
        {
            decimal baseCharge,
                heavyCharge = decimal.Zero,
                largeCharge = decimal.Zero,
                dimensions,
                weight;

            const decimal BASE_DIMENSION_CHARGE = 0.35M,
                BASE_WEIGHT_CHARGE = 0.25M,
                HEAVY_CHARGE = 0.20M,
                LARGE_CHARGE = 0.22M;

            weight = Convert.ToDecimal(Weight);
            dimensions = Convert.ToDecimal(Length + Width + Height);

            baseCharge = (BASE_DIMENSION_CHARGE * dimensions) + (BASE_WEIGHT_CHARGE * weight) + ExpressFee;

            if (IsHeavy())
                heavyCharge = HEAVY_CHARGE * weight;

            if (IsLarge())
                largeCharge = LARGE_CHARGE * baseCharge;

            return baseCharge + heavyCharge + largeCharge;
        }
    }
}
