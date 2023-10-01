# GoF_Csharp_Factory_Method_Pattern (Creational Patterns)

https://refactoring.guru/design-patterns/factory-method

https://refactoring.guru/design-patterns/examples

https://www.dotnettricks.com/learn/designpatterns/factory-method-design-pattern-dotnet

![image](https://github.com/luiscoco/GoF_Csharp-2.Factory_Method_Pattern/assets/32194879/badc6519-0e01-4e1d-a0f1-22723752c05a)

## Problem
Imagine that you’re creating a logistics management application. The first version of your app can only handle transportation by trucks, so the bulk of your code lives inside the Truck class.

After a while, your app becomes pretty popular. Each day you receive dozens of requests from sea transportation companies to incorporate sea logistics into the app.

![image](https://github.com/luiscoco/GoF_Csharp-2.Factory_Method_Pattern/assets/32194879/c8e9e378-4e6f-4a06-bd3c-7e2c577f42fd)

Adding a new class to the program isn’t that simple if the rest of the code is already coupled to existing classes.

Great news, right? But how about the code? At present, most of your code is coupled to the Truck class. Adding Ships into the app would require making changes to the entire codebase. Moreover, if later you decide to add another type of transportation to the app, you will probably need to make all of these changes again.

As a result, you will end up with pretty nasty code, riddled with conditionals that switch the app’s behavior depending on the class of transportation objects.

## Solution
The Factory Method pattern suggests that you replace direct object construction calls (using the new operator) with calls to a special factory method. Don’t worry: the objects are still created via the new operator, but it’s being called from within the factory method. Objects returned by a factory method are often referred to as products.

![image](https://github.com/luiscoco/GoF_Csharp-2.Factory_Method_Pattern/assets/32194879/b187b436-194e-4265-96c3-31ac9e788a75)

Subclasses can alter the class of objects being returned by the factory method.

At first glance, this change may look pointless: we just moved the constructor call from one part of the program to another. However, consider this: now you can override the factory method in a subclass and change the class of products being created by the method.

There’s a slight limitation though: subclasses may return different types of products only if these products have a common base class or interface. Also, the factory method in the base class should have its return type declared as this interface.

![image](https://github.com/luiscoco/GoF_Csharp-2.Factory_Method_Pattern/assets/32194879/0b5f8e1b-b092-44b8-b26d-16fc1db74524)

All products must follow the same interface.

For example, both Truck and Ship classes should implement the Transport interface, which declares a method called deliver. Each class implements this method differently: trucks deliver cargo by land, ships deliver cargo by sea. The factory method in the RoadLogistics class returns truck objects, whereas the factory method in the SeaLogistics class returns ships.

![image](https://github.com/luiscoco/GoF_Csharp-2.Factory_Method_Pattern/assets/32194879/469e0320-9cae-4aa2-8727-526bb100982d)

As long as all product classes implement a common interface, you can pass their objects to the client code without breaking it.

The code that uses the factory method (often called the client code) doesn’t see a difference between the actual products returned by various subclasses. The client treats all the products as abstract Transport. The client knows that all transport objects are supposed to have the deliver method, but exactly how it works isn’t important to the client.

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

