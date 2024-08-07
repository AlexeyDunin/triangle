namespace TriangleRecognizer;

public static class TriangleRecognizer
{ 
    public static TriangleType Recognize(double a, double b, double c)
    {
        if (AreLessOrEqualZero())
        {
            throw new ArgumentException("A side of the triangle is equal to or less than zero");
        }

        if (IsNotTriangle())
        {
            throw new ArgumentException("The sum of two sides must be larger than the third");
        }

        double[] unifiedTriangle = [a * a, b * b , c * c];
        Array.Sort(unifiedTriangle);

        var a2 = unifiedTriangle[0];
        var b2 = unifiedTriangle[1];
        var c2 = unifiedTriangle[2];

        if (Math.Abs(a2 + b2 - c2) < 1e-10)
        {
            return TriangleType.Right;
        }

        return a2 + b2 > c2 ? TriangleType.Acute : TriangleType.Obtuse;

        bool AreLessOrEqualZero()
        {
            return a <= 0.0 || b <= 0.0 || c <= 0.0;
        }

        bool IsNotTriangle()
        {
           return a + b <= c || a + c <= b || b + c <= a;
        }
    }
}
