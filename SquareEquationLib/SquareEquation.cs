namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {     
        double eps =Math.Pow(10, -9);
        double D = Math.Pow(b, 2) - (4*a*c);
        
        if ((Double.IsNaN(a)) || (Double.IsNaN(b)) ||(Double.IsNaN(c)))
        {
            throw new ArgumentException();
        }

        if ((Double.IsInfinity(a)) || (Double.IsInfinity(b)) ||(Double.IsInfinity(c)))
        {
            throw new ArgumentException();
        }

        if (Math.Abs(a)<eps)
        {
            throw new ArgumentException();
        }
    
        if (D>eps)
        {
            double x1 = -(b+Math.Sign(b)*Math.Sqrt(D))/(2*a);
            double x2 = c/x1;
            double[] array_x = {x1, x2};
            return array_x;
        }

        if (D<=eps & D>-eps)
        {
            double x1=-b/(2*a);
            double[] array_x = {x1};
            return array_x;
        }

        if (D<-eps)
        {
            double[] array_x = new double[0];
            return array_x;
        }
        throw new NotImplementedException();
        
    }
}
