using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create two customers with addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Address address2 = new Address("456 Elm St", "Another City", "NY", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Laptop", "P123", 1200.00, 1);
        Product product2 = new Product("Headphones", "H456", 150.00, 2);
        Product product3 = new Product("Mouse", "M789", 20.00, 3);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display packing labels, shipping labels, and total prices
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Order 1 Total Price: ${order1.GetTotalPrice()}");
        Console.WriteLine();

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Order 2 Total Price: ${order2.GetTotalPrice()}");
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;
    private double shippingCost;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
        // Determine shipping cost based on customer's location
        if (customer.IsInUSA())
        {
            shippingCost = 5.00;
        }
        else
        {
            shippingCost = 35.00;
        }
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.Name} - {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nCustomer Name: {customer.Name}\nAddress:\n{customer.Address.GetAddressInfo()}";
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0.0;
        foreach (var product in products)
        {
            totalPrice += product.GetTotalCost();
        }
        return totalPrice + shippingCost;
    }
}

class Product
{
    public string Name { get; private set; }
    public string ProductId { get; private set; }
    public double Price { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, string productId, double price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalCost()
    {
        return Price * Quantity;
    }
}

class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country == "USA";
    }

    public string GetAddressInfo()
    {
        return $"{streetAddress}\n{city}, {state}\n{country}";
    }
}
