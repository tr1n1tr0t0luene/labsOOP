using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace lab4
{
    class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger numerator;
        private BigInteger denominator;

        public MyFrac(BigInteger numerator, BigInteger denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            if (denominator < 0 & numerator < 0)
            {
                this.denominator = -denominator;
              
            }
         
           
            Simplify();
        }

        public MyFrac(int numerator, int denominator) : this(new BigInteger(numerator), new BigInteger(denominator))
        {
        }

        public MyFrac Add(MyFrac b)
        {
            BigInteger commonDenominator = denominator * b.denominator / BigInteger.GreatestCommonDivisor(denominator, b.denominator);
            BigInteger newNumerator = numerator * (commonDenominator / denominator) +
                                        b.numerator * (commonDenominator / b.denominator);
            return new MyFrac(newNumerator, commonDenominator);
        }


        public MyFrac Subtract(MyFrac b)
        {
            BigInteger commonDenominator = BigInteger.GreatestCommonDivisor(denominator, b.denominator);
            BigInteger newNumerator = numerator * (commonDenominator / denominator) -
                                       b.numerator * (commonDenominator / b.denominator);
            return new MyFrac(newNumerator, commonDenominator);
        }

        public MyFrac Multiply(MyFrac b)
        {
            return new MyFrac(numerator * b.numerator, denominator * b.denominator);
        }

        public MyFrac Divide(MyFrac b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return new MyFrac(numerator * b.denominator, denominator * b.numerator);
        }

        public int CompareTo(MyFrac other)
        {
            BigInteger commonDenominator = denominator * other.denominator / BigInteger.GreatestCommonDivisor(denominator, other.denominator);
            BigInteger thisNumerator = numerator * (commonDenominator / denominator);
            BigInteger otherNumerator = other.numerator * (commonDenominator / other.denominator);

            return thisNumerator.CompareTo(otherNumerator);
        }

        private void Simplify()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }

}
