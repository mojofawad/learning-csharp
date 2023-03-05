# General Notes

A place to reference terminology and other valuable information

---

### General Structure
```csharp
// A skeleton of a C# program
using System;

// Your program starts here:
Console.WriteLine("Hello world!");

namespace YourNamespace
{
    class YourClass
    {
    }

    struct YourStruct
    {
    }

    interface IYourInterface
    {
    }

    delegate int YourDelegate();

    enum YourEnum
    {
    }

    namespace YourNestedNamespace
    {
        struct YourStruct
        {
        }
    }
}
```

#### Main Method
- `Main` is the entry point of a C# application. 
    - There can only be one entry point in a C# program
- `Main` is the first method invoked when an app is started
    - If more than one class has a `Main` method then the program must be compiled with **StartupObject** compiler to specify *which* `Main` gets used as the entry point
- `Main` can be omitted in C# 9 and up.
    - Top-level statements would be used in place of main
- `Main` is declared inside a class or struct
- `Main` must be static, but doesn't need to be public
- `Main` can have the following return types:
    - `void`
    - `int`
    - `Task`
    - `Task<int>`
        - If `Main` only returns a `Task` or `Task<int>`, then it can also include the `async` modifier, excluding an `async void Main` method.
- Valid `Main` signatures
    >   ```csharp
    >   public static void Main() { }
    >   public static int Main() { }
    >   public static void Main(string[] args) { }
    >   public static int Main(string[] args) { }
    >   public static async Task Main() { }
    >   public static async Task<int> Main() { }
    >   public static async Task Main(string[] args) { }
    >   public static async Task<int> Main(string[] args) { }
    >   '''

#### Top-level Statements
