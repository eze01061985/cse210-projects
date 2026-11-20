class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street", "Rexburg", "Idaho", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop Stand", "LS-100", 24.99, 2));
        order1.AddProduct(new Product("Wireless Mouse", "WM-205", 15.50, 1));
        order1.AddProduct(new Product("USB-C Cable", "UC-310", 8.75, 3));

        Address address2 = new Address("45 King Road", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Maria Garcia", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Notebook", "NB-410", 4.25, 4));
        order2.AddProduct(new Product("Backpack", "BP-520", 35.99, 1));
        order2.AddProduct(new Product("Water Bottle", "WB-630", 12.50, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        int orderNumber = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine($"ORDER {orderNumber}");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}");
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            orderNumber++;
        }
    }
}
