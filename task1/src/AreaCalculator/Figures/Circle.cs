namespace AreaCalculator.Figures;

public class Circle : IFigure
{
    private double Radius { get; }

    public Circle(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius, "Radius must be positive.");

        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}