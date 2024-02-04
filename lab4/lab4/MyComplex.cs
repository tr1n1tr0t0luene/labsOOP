﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class MyComplex : IMyNumber<MyComplex>
    {
        private double real;
        private double imaginary;

        public MyComplex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public MyComplex(int real, int imaginary) : this((double)real, (double)imaginary)
        {
        }

        public MyComplex Add(MyComplex b)
        {
            return new MyComplex(real + b.real, imaginary + b.imaginary);
        }

        public MyComplex Subtract(MyComplex b)
        {
            return new MyComplex(real - b.real, imaginary - b.imaginary);
        }

        public MyComplex Multiply(MyComplex b)
        {
            return new MyComplex(real * b.real - imaginary * b.imaginary, real * b.imaginary + imaginary * b.real);
        }

        public MyComplex Divide(MyComplex b)
        {
            double denominator = b.real * b.real + b.imaginary * b.imaginary;
            if (denominator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            double newReal = (real * b.real + imaginary * b.imaginary) / denominator;
            double newImaginary = (imaginary * b.real - real * b.imaginary) / denominator;
            return new MyComplex(newReal, newImaginary);
        }

        public override string ToString()
        {
            return $"{real} + {imaginary}i";
        }
    }
}
