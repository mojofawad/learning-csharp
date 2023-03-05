// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Declare and use variables
// Variables are symbols that allow us to run the same code with different values

string aFriend = "Bill";
Console.WriteLine(aFriend);

// we can change the variable and re-run the command
aFriend = "Maira";
Console.WriteLine(aFriend);

// Mixing strings and variables
Console.WriteLine("Hello " + aFriend);

// An easier way to mix the two by adding a $ in front of the quotations
Console.WriteLine($"Hello {aFriend}");

// Adding multiple variables to a string
string firstFriend = "Maria";
string secondFriend = "Sage";
Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");

// Here we add the length property to the friend variables.
Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters.");
Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");

// Using the Trim method
string greeting = "     Hello World!     ";
Console.WriteLine($"[{greeting}]");

string trimmedGreeting = greeting.TrimStart();
Console.WriteLine($"[{trimmedGreeting}]");

trimmedGreeting = greeting.TrimEnd();
Console.WriteLine($"[{trimmedGreeting}]");

trimmedGreeting = greeting.Trim();
Console.WriteLine($"[{trimmedGreeting}]");

// Using the Replace method
string sayHello = "Hello World!";
Console.WriteLine(sayHello);

sayHello = sayHello.Replace("Hello", "Greetings");
Console.WriteLine(sayHello);

// Changing font capitlization
Console.WriteLine(sayHello.ToUpper());
Console.WriteLine(sayHello.ToLower());

// Searching strings with the Contains method
string songLyrics = "You say goodbye, and I say hello";
Console.WriteLine(songLyrics.StartsWith("You")); // true
Console.WriteLine(songLyrics.StartsWith("goodbye")); //false

Console.WriteLine(songLyrics.Contains("goodbye")); // true
Console.WriteLine(songLyrics.Contains("greetings")); // true


