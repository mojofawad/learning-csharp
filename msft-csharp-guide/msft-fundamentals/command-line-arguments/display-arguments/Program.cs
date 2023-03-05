// Example from "How to display command-line arguments"
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/how-to-display-command-line-arguments

// Arguments provided to an executable on the command line are accessible in top-level statements
// or through an optional parameter to Main
// Top-level statements are programs w/o 'Main' methods

//
// Example
//

// The Length property provides the number of array elements.
Console.WriteLine($"parameter count = {args.Length}");

for (int i = 0; i < args.Length; i++)
{
    Console.WriteLine($"Arg[{i}] = [{args[i]}]");
}


// To get the below output, run command `dotnet run a b c` on the command-line
/* Output (assumes 3 cmd line args):
    parameter count = 3
    Arg[0] = [a]
    Arg[1] = [b]
    Arg[2] = [c]
*/

