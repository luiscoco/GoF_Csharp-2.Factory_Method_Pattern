# GoF_Csharp_Factory_Method_Pattern

## Factory Method pattern (Creational Patterns):
Defines an interface for creating objects, but it allows subclasses to decide which class to instantiate. 
It promotes loose coupling by separating the client code from the object creation process.

```csharp
using System;

public class Program
{
    public static void Main()
    {
        // Create ConcreteCreatorA and ConcreteCreatorB instances
        Creator creatorA = new ConcreteCreatorA();
        Creator creatorB = new ConcreteCreatorB();

        // Use the FactoryMethod to create products
        IProduct productA = creatorA.FactoryMethod();
        IProduct productB = creatorB.FactoryMethod();

        // Display the products
        productA.Display();
        productB.Display();
    }
}

public interface IProduct
{
    void Display();
}

public class ConcreteProductA : IProduct
{
    public void Display()
    {
        Console.WriteLine("Concrete Product A");
    }
}

public class ConcreteProductB : IProduct
{
    public void Display()
    {
        Console.WriteLine("Concrete Product B");
    }
}

public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}
```

## How to setup Github actions

![Csharp Github actions](https://github.com/luiscoco/GoF_Csharp-2.Factory_Method_Pattern/assets/32194879/90ca90d4-16b7-4979-8c29-f1df6de646d5)

