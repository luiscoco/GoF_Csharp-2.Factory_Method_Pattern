# GoF_Csharp_Factory_Method_Pattern (Creational Patterns)

https://refactoring.guru/design-patterns/factory-method

https://refactoring.guru/design-patterns/examples

https://www.dotnettricks.com/learn/designpatterns/factory-method-design-pattern-dotnet


## What is Factory Method Pattern?
Factory method is a creational design pattern which solves the problem of creating product objects without specifying their concrete classes.

The Factory Method defines a method, which should be used for creating objects instead of using a direct constructor call (new operator). Subclasses can override this method to change the class of objects that will be created.

```csharp
static void Main(string[] args)
 {
 VehicleFactory factory = new ConcreteVehicleFactory();

 IFactory scooter = factory.GetVehicle("Scooter");
 scooter.Drive(10);

 IFactory bike = factory.GetVehicle("Bike");
 bike.Drive(20);

 Console.ReadKey();

 }
```

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

## Factory Method Pattern - Example

![image](https://github.com/luiscoco/GoF_Csharp-2.Factory_Method_Pattern/assets/32194879/f704e919-6f95-426f-81af-3be6ac59ff79)

## Who is what?
The classes, interfaces, and objects in the above class diagram can be identified as follows:

IFactory - Interface

Scooter & Bike - Concreate Product classes

VehicleFactory - Creator

ConcreteVehicleFactory - Concreate Creator

```csharp
using System;
namespace Factory
{
 /// <summary>
 /// The 'Product' interface
 /// </summary>
 public interface IFactory
 {
 void Drive(int miles);
 }

 /// <summary>
 /// A 'ConcreteProduct' class
 /// </summary>
 public class Scooter : IFactory
 {
 public void Drive(int miles)
 {
 Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
 }
 }

 /// <summary>
 /// A 'ConcreteProduct' class
 /// </summary>
 public class Bike : IFactory
 {
 public void Drive(int miles)
 {
 Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
 }
 }

 /// <summary>
 /// The Creator Abstract Class
 /// </summary>
 public abstract class VehicleFactory
 {
 public abstract IFactory GetVehicle(string Vehicle);

 }

 /// <summary>
 /// A 'ConcreteCreator' class
 /// </summary>
 public class ConcreteVehicleFactory : VehicleFactory
 {
 public override IFactory GetVehicle(string Vehicle)
 {
 switch (Vehicle)
 {
 case "Scooter":
 return new Scooter();
 case "Bike":
 return new Bike();
 default:
 throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
 }
 }

 }
 
 /// <summary>
 /// Factory Pattern Demo
 /// </summary>
 class Program
 {
 static void Main(string[] args)
 {
 VehicleFactory factory = new ConcreteVehicleFactory();

 IFactory scooter = factory.GetVehicle("Scooter");
 scooter.Drive(10);

 IFactory bike = factory.GetVehicle("Bike");
 bike.Drive(20);

 Console.ReadKey();

 }
 }
}
```
## When to use it?

Subclasses figure out what objects should be created.

Parent class allows later instantiation to subclasses means the creation of an object is done when it is required.

The process of objects created is required to centralize within the application.

A class (creator) will not know what classes it will be required to create.


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

