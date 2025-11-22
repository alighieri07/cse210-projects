using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var prod1 = new Product("Laptop", "A100", 900, 1);
        var prod2 = new Product("Mouse", "B200", 25, 2);
        var prod3 = new Product("Keyboard", "C300", 45, 1);
        var prod4 = new Product("Monitor", "D400", 200, 1);
        var prod5 = new Product("USB Cable", "E500", 10, 3);

        var addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
        var addr2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        var cust1 = new Customer("John Doe", addr1);
        var cust2 = new Customer("Jane Smith", addr2);

        var order1 = new Order(new List<Product> { prod1, prod2, prod3 }, cust1);
        var order2 = new Order(new List<Product> { prod4, prod5 }, cust2);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}