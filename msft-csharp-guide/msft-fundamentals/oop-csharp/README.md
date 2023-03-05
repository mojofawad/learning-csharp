# Introduction to OOP principles
Source: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop

Note: Files from the classes intro were copied over to to preserve the need for referencing in the future

---
## Concepts
### Four Basic Principles

- Abstraction
    - Modeling relevant atributes and interactions of entities as classes
    - Define an abstract representation of a system
- Encapsulation
    - Hiding internal state and functionality of an object
    - Only allows access through a public set of functions
- Inheritance
    - Creating new abstractions based on existing abstractions
- Polymorphism
    - Implementing inherited properties/methods across multiple abstractions

### Misc
- The `virtual` keyword in a method declaration in a base class is used when a derived class may provide a different implementation for
    - A `virtual` method is a method where any derived class may choose to reimplement
        >   ```csharp
        >   // BankAccount.cs (base)
        >   public virtual void PerformMonthEndTransactions() 
        >   {
        >       ...
        >   }
        >   ```
    - Derived classes use `override` to define the new implmentation
        >   ```c#
        >   // InterestEarningAccount.cs
        >   public override void PerformMonthEndTransactions()
        >   {
        >       ...
        >   }
        >   ```


---