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
