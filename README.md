# GoF_Csharp_Factory_Method_Pattern

## What is Factory Method Pattern?
In Factory pattern, we create the object without exposing the creation logic. In this pattern, an interface is used for creating an object, but let subclass decide which class to instantiate. The creation of object is done when it is required. The Factory method allows a class later instantiation to subclasses.

In short, factory method design pattern abstract the process of object creation and allows the object to be created at run-time when it is required.

##  Method Pattern - UML Diagram & Implementation
The UML class diagram for the implementation of the factory method design pattern is given below:

![image](https://github.com/luiscoco/GoF_Csharp-2.Factory_Method_Pattern/assets/32194879/7b773fd0-10e9-41b6-8fde-29b1bcfd0fa0)

The classes, interfaces and objects in the above UML class diagram are as follows:

Product - This is an interface for creating the objects.

ConcreteProduct - This is a class which implements the Product interface.

Creator - This is an abstract class and declares the factory method, which returns an object of type Product.

ConcreteCreator - This is a class which implements the Creator class and overrides the factory method to return an instance of a ConcreteProduct.

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

