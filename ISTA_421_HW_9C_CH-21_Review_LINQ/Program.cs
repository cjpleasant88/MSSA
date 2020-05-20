using System;
using System.Collections.Generic;
using System.Linq;

namespace ISTA_421_HW_9C_CH_21_Review_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tISTA_421_HW_9C_CH_21_Review_LINQ.Program.Main()");

            IQueryable<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Sam", Country = "United States", purchases = 2 },
                new Customer { Name = "John", Country = "Mexico", purchases = 6 },
                new Customer { Name = "Max", Country = "Italy", purchases = 10 },
                new Customer { Name = "Fred", Country = "United States", purchases = 51 },
                new Customer { Name = "Susan", Country = "United States", purchases = 45 }
            }.AsQueryable<Customer>();

            var querySyntax = (from customer in customers
                               where customer.Country == "United States"
                               orderby customer.purchases descending
                               orderby customer.Name
                               select customer.Name).Skip(1).Take(3);

            var methodSyntax = customers.Where(cust => cust.Country.Equals("United States"))
                .OrderByDescending(cust => cust.purchases)
                .OrderBy(cust => cust.Name)
                .Select(cust => cust.Name).Skip(1).Take(3);

            Console.WriteLine("\nCustomers:");
            foreach(var customer in customers)
            {
                Console.WriteLine($"{customer.Name}, Country: {customer.Country}, purchases: {customer.purchases}");
            }
            Console.WriteLine("\nFind Customers Name in \"United States\"\n\tordered by purchases descending \n\tordered by name ascending \n\ttaking customers 2-4 in that list");
            Console.WriteLine("\nRESULTS:");
            Console.WriteLine("\nQuery Syntax");
            foreach (var x in querySyntax)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nMethod Syntax");
            foreach (var x in methodSyntax)
            {
                Console.WriteLine(x);
            }
        }
    }
    struct Customer
    {
        public string Name;    // Full name of the customer
        public string Country; // Country of the customer
        public int purchases;  // Number of purchases the customer has made
    }
}
