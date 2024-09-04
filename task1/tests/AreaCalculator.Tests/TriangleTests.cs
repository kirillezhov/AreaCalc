using AreaCalculator.Figures;

namespace AreaCalculator.Tests;

public class TriangleTests
{
    [Fact]
    public void CreateInstance_IfSidesAreNotValid_CtorShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, 1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, -1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 1, -1));       
    }
    
    [Fact]
    public void CreateInstance_IfSidesAreNotCorrect_ShouldTrow()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(4, 5, 9)); 
    }

    [Fact]
    public void Detect_IfTriangleIsRightAngled_ShouldReturnTrue()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);

        // Act
        var expectedResult = triangle.IsRightAngled;

        // Assert
        Assert.True(triangle.IsRightAngled);
    }
    
    [Fact]
    public void Detect_IfTriangleIsNotRightAngled_ShouldReturnFalse()
    {
        // Arrange
        var triangle = new Triangle(13, 12, 17);
        
        // Act
        var expectedResult = triangle.IsRightAngled;

        // Assert
        Assert.False(expectedResult);
    }

    [Fact]
    public void Calculate_IfTriangleIsNotRightAngled_ShouldReturnCorrectArea()
    {
        // Arrange
        var triangle = new Triangle(21, 20, 13);
        var expectedArea = 126;
        
        // Act
        var actualArea = triangle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea);
    }
}