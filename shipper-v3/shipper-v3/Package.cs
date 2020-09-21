/*
 * Grading ID: E3780
 * Program: 1A
 * Due Date: September 21 2020
 * Course: CIS 200-76
 * Description: Creates the abstract Package class.
 */

using System;

namespace shipper_v3
{
    abstract class Package : Parcel
    {
        // Backing fields 
        private double _length, // Length of package
            _width,             // Width of package
            _height,            // Height of package
            _weight;            // Weight of package

        /*
         * Preconditions: All arguments are not null.
         * Postcondition: A Package object is abstractly created.
         */
        public Package(Address origin, Address destination, double length, double width,
            double height, double weight) : base(origin, destination)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        public double Length
        {
            /*
             * Preconditions: None
             * Postcondition: The length is returned.
             */
            get => _length;

            /*
             * Preconditions: The value provided is not negative.
             * Postcondition: Length is set to the value provided.
             */
            set
            {
                if (Double.IsNegative(value))
                    throw new ArgumentOutOfRangeException(nameof(Length), value, $"{nameof(Length)} must be a positive number.");

                _length = value;
            }
        }

        public double Width
        {
            /*
             * Preconditions: None
             * Postcondition: The width is returned.
             */
            get => _width;

            /*
             * Preconditions: The value provided is not negative.
             * Postcondition: Width is set to the value provided.
             */
            set
            {
                if (Double.IsNegative(value))
                    throw new ArgumentOutOfRangeException(nameof(Width), value, $"{nameof(Width)} must be a positive number.");

                _width = value;
            }
        }

        public double Height
        {
            /*
             * Preconditions: None
             * Postcondition: The height is returned.
             */
            get => _height;

            /*
             * Preconditions: The value provided is not negative.
             * Postcondition: Height is set to the value provided.
             */
            set
            {
                if (Double.IsNegative(value))
                    throw new ArgumentOutOfRangeException(nameof(Height), value, $"{nameof(Height)} must be a positive number.");

                _height = value;
            }
        }

        public double Weight
        {
            /*
             * Preconditions: None
             * Postcondition: The weight is returned.
             */
            get => _weight;

            /*
             * Preconditions: The value provided is not negative.
             * Postcondition: Weight is set to the value provided.
             */
            set
            {
                if (Double.IsNegative(value))
                    throw new ArgumentOutOfRangeException(nameof(Weight), value, $"{nameof(Weight)} must be a positive number.");

                _weight = value;
            }
        }

        /*
         * Preconditions: None
         * Postcondition: Returns a formatted string.
         */
        public override string ToString() => base.ToString() +
            $"{Environment.NewLine}{nameof(Length)} {nameof(Width)} {nameof(Height)} {nameof(Weight)}{Environment.NewLine}" +
            "------ ----- ------ ------" +
            $"{Environment.NewLine}{Length,-1} {Width,6} {Height,7} {Weight,6}{Environment.NewLine}";
    }
}
