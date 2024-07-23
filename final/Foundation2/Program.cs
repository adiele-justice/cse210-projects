using System;
using System.Collections.Generic;

// Address class
class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    // Method to check if address is in the USA
    public bool IsInUSA()
    {
        return country == "USA";
    }

    // Method to get full address string
    public string GetAddressInfo()
    {
        return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
    }
}

// Customer class
class Customer
{
    private string name;
    private Address address;

    // Constructor
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if customer is in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // Getter for customer name
    public string GetName()
    {
        return name;
    }

    // Getter for address information
    public string GetAddressInfo()
    {
        return address.GetAddressInfo();
    }
}

// Product class
class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Getter for product total cost
    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    // Getter for product name
    public string GetName()
    {
        return name;
    }

    // Getter for product ID
    public string GetProductId()
    {
        return productId;
    }
}

// Order class
class Order
{
    private List<Product> products;
    private Customer customer;

    // Constructor
    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate total cost of the order
    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }

        // Adding shipping cost based on customer location
        if (customer.IsInUSA())
        {
            totalCost += 5; // USA shipping cost
        }
        else
        {
            totalCost += 35; // International shipping cost
        }

        return totalCost;
    }

    // Method to get packing label
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.GetName()} - Product ID: {product.GetProductId()}\n";
        }
        return label;
    }

    // Method to get shipping label
    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"Customer Name: {customer.GetName()}\n";
        label += $"Customer Address:\n{customer.GetAddressInfo()}";
        return label;
    }
}

// Main program
class Program
{
    static void Main()
    {
        // Creating address and customer
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // Creating products for order 1
        Product product1 = new Product("Laptop", "LPT001", 1200.50m, 1);
        Product product2 = new Product("Mouse", "MS001", 25.75m, 2);

        // Creating order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Creating address and customer
        Address address2 = new Address("456 Oak Ave", "Other City", "NY", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Creating products for order 2
        Product product3 = new Product("Book", "BK001", 15.99m, 3);

        // Creating order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        // Displaying results for order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Console.WriteLine();

        // Displaying results for order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}
