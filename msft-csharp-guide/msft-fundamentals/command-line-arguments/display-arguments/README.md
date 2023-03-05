# Displaying Command-Line Arguments

Source: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/how-to-display-command-line-arguments
---

**Expected results**
```
// To get the below output, 
// run command `dotnet run a b c` 
// on the command-line

/* 
Output (assumes 3 cmd line args):
    parameter count = 3
    Arg[0] = [a]
    Arg[1] = [b]
    Arg[2] = [c]
*/
```
<br>

**Yielded results**
```
> dotnet run a b c
parameter count = 3
Arg[0] = [a]
Arg[1] = [b]
Arg[2] = [c]
```
