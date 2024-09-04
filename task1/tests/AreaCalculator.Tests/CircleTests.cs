using AreaCalculator.Figures;

namespace AreaCalculator.Tests;

public class CircleTests
{
    [Fact]
    public void CreateInstance_IfRadiusIsNotValid_CtorShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
    }

    [Fact]
    public void Calculate_IfRadiusIsValid_ShouldReturnCorrectArea()
    {
        // Arrange
        var circle = new Circle(5);
        var expectedArea = Math.PI * Math.Pow(5, 2);

        // Act
        var actualArea = circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea);
    }
}