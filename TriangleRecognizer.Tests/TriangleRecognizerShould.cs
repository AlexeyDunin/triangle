namespace TriangleRecognizer.Tests;

public class TriangleRecognizerShould
{
    [Theory]
    [InlineData(7, 24, 25, TriangleType.Right)]
    [InlineData(25, 7, 24, TriangleType.Right)]
    [InlineData(2.5, 6.0, 6.5, TriangleType.Right)]

    [InlineData(3, 3, 3, TriangleType.Acute)]
    [InlineData(3.5, 4.5, 5.5, TriangleType.Acute)]
    [InlineData(5.5, 3.5, 4.5, TriangleType.Acute)]

    [InlineData(7, 10, 5, TriangleType.Obtuse)]
    [InlineData(3.0, 4.0, 5.1, TriangleType.Obtuse)]
    [InlineData(5.1, 4.0, 3.0, TriangleType.Obtuse)]

    [InlineData(1e100, 1e100, 1e100, TriangleType.Acute)]
    public void Recognize_ShouldReturnCorrectType(double a, double b, double c, TriangleType expected)
    {
        var result = TriangleRecognizer.Recognize(a, b, c);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(7, 24, 0)]
    [InlineData(25, 0, 24) ]
    [InlineData(-0.3, 6.0, 6.5)]
    [InlineData(5, -1, 6.5)]
    [InlineData(6, 4, -1e100)]
    public void Recognize_ShouldThrowException_WhenSideLessThanOrEqualZero(double a, double b, double c)
    {
       var exception = Assert.Throws<ArgumentException>(() => TriangleRecognizer.Recognize(a, b, c));
       Assert.Equal("A side of the triangle is equal to or less than zero", exception.Message);
    }

    [Theory]
    [InlineData(7, 2, 10)]
    [InlineData(70, 2, 10)]
    [InlineData(70, 200, 10)]
    public void Recognize_ShouldThrowException_WhenItIsNotTriangle(double a, double b, double c)
    {
        var exception = Assert.Throws<ArgumentException>(() => TriangleRecognizer.Recognize(a, b, c));
        Assert.Equal("The sum of two sides must be larger than the third", exception.Message);
    }
}