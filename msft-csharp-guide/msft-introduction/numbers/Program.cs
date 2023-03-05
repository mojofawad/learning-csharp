// How to use integer and floating point numbers in C#

// WorkWithIntegers();
// OrderPrecedence();
// TestLimits();
// WorkWithDoubles();
// WorkWithDecimals();

/* 
        Circle challenge
    Calculate the area of a circle whose radius
    is 2.50 centimeters. A = r^2 * pi
*/

CircleChallenge();

void WorkWithIntegers()
{
    int a = 18;
    int b = 6;
    int c = a + b;
    Console.WriteLine(c);

    // subtraction
    c = a - b;
    Console.WriteLine(c);

    // multiplication
    c = a * b;
    Console.WriteLine(c);

    // division
    c = a / b;
    Console.WriteLine(c);
}

void OrderPrecedence()
{
    // Exploring the order of operations
    int a = 5;
    int b = 4;
    int c = 2;
    int d = a + b * c; // Expecting 13
    Console.WriteLine(d);

    d = (a + b) - 6 * 2 + (12 * 4) / 3 + 12; // Expecting 25
    Console.WriteLine(d);

    // Exploring integer vs floats
    int e = 7;
    int f = 4;
    int g = 3;
    int h = (e + f) / g; // Expecting number between 3 and 4 (3.x)
    Console.WriteLine(h); // Still returns 3
}

void TestLimits() 
{
    // Explore integer precision and limits
    int a = 7;
    int b = 4;
    int c = 3;
    int d = (a + b) / c;
    int e = (a + b) % c;
    Console.WriteLine($"quotient: {d}"); // Expecting integer 3
    Console.WriteLine($"remainder: {e}"); // Expecting integer 2

    // C# int type has minimum and maximum limits
    int max = int.MaxValue;
    int min = int.MinValue;
    Console.WriteLine($"The range of integers is {min} to {max}");

    // When calculations exceed these limits, we get an overflow or underflow condition
    int what = max + 3; // returns min + 2
    Console.WriteLine($"An example of overflow: {what}"); 
}

void WorkWithDoubles()
{
    // Working with the double type
    double a = 5;
    double b = 4;
    double c = 2;
    double d = (a + b) / c;
    Console.WriteLine(d);

    double e = 19;
    double f = 23;
    double g = 8;
    double h = (e + f) / g;
    Console.WriteLine(h);

    double max = double.MaxValue;
    double min = double.MinValue;
    Console.WriteLine($"The range of double is {min} to {max}");

    double third = 1.0 / 3.0;
    Console.WriteLine(third);
}

void WorkWithDecimals()
{
    decimal min = decimal.MinValue;
    decimal max = decimal.MaxValue;
    Console.WriteLine($"The range of the decimal type is {min} to {max}");

    double a = 1.0;
    double b = 3.0;
    Console.WriteLine(a / b);
    
    decimal c = 1.0M;
    decimal d = 3.0M;
    Console.WriteLine(c / d);
}

void CircleChallenge()
{
    double r = 2.50;
    double area = (Math.Pow(r, 2))*Math.PI;
    Console.WriteLine(area);

    // trying a different way
    double pi = Math.PI;
    area = (r*r)*pi;
    Console.WriteLine(area);
}