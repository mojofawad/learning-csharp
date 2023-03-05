// C# if statements and loops
// Conditional logic tutorial

// ExploreIf();
// ExploreLoops();

/*
        Challenge: Combine Branches and Loops
    
    Find the sum of all integers 1 through 
    20 that are divisible by 3
*/

CombineChallenge();

void ExploreIf()
{

    // Make decisions using the if statement
    // == tests for equality
    // = is an assignment operator

    int a = 5;
    int b = 3;
    int c = 4;

    // && represents AND
    if ((a + b + c > 10) && (a == b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("And the first number is equal to the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("Or the first number is not equal to the second");
    }

    // || represents OR
    if ((a + b + c > 10) || (a == b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("Or the first number is equal to the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("And the first number is not equal to the second");
    }

    /*
            Originally written without brackets

    if (a + b > 10)
        Console.WriteLine("The answer is greater than 10");
    else
        Console.WriteLine("The answer is not greater than 10");

    */
}

void ExploreLoops()
{
    int counter = 0;
    while (counter < 10)
    {
        Console.WriteLine($"Hello World! The counter is {counter}");
        counter++; // The ++ operator is also known as the increment operator
    }

    // the same function, but using a do ... while loop
    counter = 0;
    do
    {
        Console.WriteLine($"Hello World! The counter is {counter}");
        counter++; // The ++ operator is also known as the increment operator
    }
    while (counter < 10);

    // Working with the for loop
    for (int index = 0; index < 10; index++)
    {
        Console.WriteLine($"Hello World! The index is {index}");
    }

    // Create nested loops
    
    // generate rows
    for (int row = 1; row < 11; row++)
    {
        for (char column = 'a'; column < 'k'; column++)
        {
            Console.WriteLine($"The cell is ({row}, {column})");
        }
    }
}

void CombineChallenge()
{
    int sum = 0;
    for (int num = 0; num <= 20; num++)
    {
        if ((num % 3) == 0)
        {
            sum += num;
        }
    }
    Console.WriteLine($"The sum of all numbers between 1 through 20 that are divisble by 3 is: {sum}");
}