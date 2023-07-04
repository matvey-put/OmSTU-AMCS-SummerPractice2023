using Xunit;
using SquareEquationLib;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Theory]
        [InlineData(1,6,45)]
        [InlineData(5,3,7)]
        public void ZeroSolution(double a, double b, double c)
        {
            double [] x = SquareEquation.Solve(a, b, c);
            Assert.Equal(new double[0], x);
        }

        [Theory]
        [InlineData(1,4,4)]
        [InlineData(1,-6,9)]
        public void OneSolution(double a, double b, double c)
        {
            double x = SquareEquation.Solve(a, b, c)[0];
            Assert.Equal(0, Math.Abs(a * Math.Pow(x,2) + b*x + c), Math.Pow(10,-9));
        }
        
        [Theory]
        [InlineData(1,9,-36)]
        [InlineData(1,-15,36)]
        public void TwoSolution(double a, double b, double c)
        {
            double[] arrayx = SquareEquation.Solve(a, b, c);
            foreach(double x in arrayx)
            {
                Assert.Equal(0, Math.Abs(a * Math.Pow(x,2) + b*x + c), Math.Pow(10,-9));
            }
        }

        [Theory]
        [InlineData(0,7,8)]
        public void ANull(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(()=>SquareEquation.Solve(a, b, c));
        }
        
        [Theory]
        [InlineData(Double.NaN,7,8)]
        [InlineData(14,Double.NaN,1)]
        [InlineData(9,7,Double.NaN)]
        public void NotANumber(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(()=>SquareEquation.Solve(a, b, c));
        }

        [Theory]
        [InlineData(double.PositiveInfinity,7,8)]
        [InlineData(1,double.PositiveInfinity,8)]
        [InlineData(1,7,double.PositiveInfinity)]
        public void NumberPositiveInfinity(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(()=>SquareEquation.Solve(a, b, c));
        }

        [Theory]
        [InlineData(double.NegativeInfinity,7,8)]
        [InlineData(1,double.NegativeInfinity,8)]
        [InlineData(1,7,double.NegativeInfinity)]
        public void NumberNegativeInfinity(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(()=>SquareEquation.Solve(a, b, c));
        }
    }
}
