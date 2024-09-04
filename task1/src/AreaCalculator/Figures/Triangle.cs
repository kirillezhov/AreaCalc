namespace AreaCalculator.Figures;

public class Triangle : IFigure
{
    public double Side1 { get; }
    public double Side2 { get; }
    public double Side3 { get; }

    public bool IsRightAngled => DetectRightAngle();

    public Triangle(double side1, double side2, double side3)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(side1, "Sides must be positive.");
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(side2, "Sides must be positive.");
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(side3, "Sides must be positive.");
        
        if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
        {
            throw new ArgumentException("Provided sides cannot form a valid triangle.");
        }

        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public double CalculateArea()
    {
        var semiPerimeter = (Side1 + Side2 + Side3) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - Side1) * (semiPerimeter - Side2) * (semiPerimeter - Side3));
    }

    private bool DetectRightAngle()
    {
        var sides = new[] { Side1, Side2, Side3 };

        Array.Sort(sides);

        var maxSide = sides.Last();

        return maxSide == Math.Sqrt(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2));
    }
}