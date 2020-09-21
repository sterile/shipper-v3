using System;
using System.Collections.Generic;
using System.Text;

namespace shipper_v3
{
    abstract class Package : Parcel
    {
        private Address _origin,
            _destination;

        private double _length,
            _width,
            _height,
            _weight;

        public Package(Address origin, Address destination, double length, double width, double height, double weight) : base(origin, destination)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        public double Length
        {
            get => _length;
            set
            {
                if (Double.IsNegative(value))
                    throw new ArgumentOutOfRangeException(nameof(Length), value, $"{nameof(Length)} must be a positive number.");

                _length = value;
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                if (Double.IsNegative(value))
                    throw new ArgumentOutOfRangeException(nameof(Width), value, $"{nameof(Width)} must be a positive number.");

                _width = value;
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (Double.IsNegative(value))
                    throw new ArgumentOutOfRangeException(nameof(Height), value, $"{nameof(Height)} must be a positive number.");

                _height = value;
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (Double.IsNegative(value))
                    throw new ArgumentOutOfRangeException(nameof(Weight), value, $"{nameof(Weight)} must be a positive number.");

                _weight = value;
            }
        }

        public override string ToString() => base.ToString() +
            $"{nameof(Length)} {nameof(Width)} {nameof(Height)} {nameof(Weight)}{Environment.NewLine}" +
            "------ ----- ------ ------" +
            $"{Environment.NewLine}{Length,-6} {Width,6} {Height,12} {Weight,18}";
    }
}
