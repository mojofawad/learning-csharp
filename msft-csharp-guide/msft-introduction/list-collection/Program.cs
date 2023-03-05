// Learn to manage data collections using List<T>

// WorkWithStrings();
FibonacciNumbers();

void WorkWithStrings()
{
    // Basic list example
    var names = new List<string> {"Joey", "Ana", "Felipe"};
    foreach (var name in names)
    {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }

    // Modifying list contents
    Console.WriteLine();
    names.Add("Maria");
    names.Add("Bill");
    names.Remove("Ana");
    foreach (var name in names)
    {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }

    // List<T> allows us to reference by index
    Console.WriteLine($"My name is {names[0]}");
    Console.WriteLine($"I've added {names[2]} and {names[3]} to the list");

    // Using the Count property
    Console.WriteLine($"The list has {names.Count} people in it");

    // Search and sort lists
    var index = names.IndexOf("Felipe");
    if (index == -1)
    {
        Console.WriteLine($"When an item is not found, IndexOf returns {index}");
    }
    else
    {
        Console.WriteLine($"The name {names[index]} is at index {index}");
    }

    index = names.IndexOf("Not Found");
    if (index == -1)
    {
        Console.WriteLine($"When an item is not found, IndexOf returns {index}");
    }
    else
    {
        Console.WriteLine($"The name {names[index]} is at index {index}");
    }

    names.Sort(); // The sort method changes the order permanently??
    foreach (var name in names)
    {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }
}

void FibonacciNumbers()
{
    var fibonacciNumbers = new List<int> {1, 1};

    do
    {
        var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
        var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
        fibonacciNumbers.Add(previous + previous2);
    } while (fibonacciNumbers.Count < 20);

    foreach (var item in fibonacciNumbers)
    {
        Console.WriteLine(item);
    }
}