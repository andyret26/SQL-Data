using SqlClientReading.Models;
using SqlClientReading.Repository;

namespace SqlClientReading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cr = new CustomerRepository();
            var customer = new Customer();
            customer.FirstName = "First1";
            customer.LastName = "Last1";
            customer.Country = "Country1";
            customer.PostalCode = "1234";
            customer.Phone = "12345678";
            customer.Email = "mail@mail.com";

            //var addedCustomer = cr.AddCustomer(customer);
            //Console.WriteLine("\n------- ADD CUSTOMER -------");
            //if(addedCustomer)
            //{
            //    Console.WriteLine("Added cutomer sucessfully");
            //} else
            //{
            //    Console.WriteLine("Error, Customer not added");
            //}

            Console.WriteLine("\n------- UPDATE CUSTOMER -------");


            Console.WriteLine("\n------- ALL CUSTOMERS -------");
            cr.GetAllCustomers().ForEach(customer => Console.WriteLine($"Id: {customer.Id}, First name: {customer.FirstName}, ...."));

            Console.WriteLine("\n------- CUSTOMER BY ID -------");
            var customerFromDb = cr.GetCustomerById(5);
            Console.WriteLine($"Id: {customerFromDb.Id}, First name: {customerFromDb.FirstName}, ....");

            Console.WriteLine("\n------- CUSTOMER BY PRTIAL NAME -------");
            var customersFromDb = cr.GetCustomerById(5);
            cr.GetCustomersByPartialName("ers").ForEach(customer => Console.WriteLine($"Id: {customer.Id}, Full name: {customer.FirstName} {customer.LastName}, ...."));






            Console.WriteLine("\n------- CUSTOMER COUNTRY COUNT -------");
            var customerCountryCount = cr.GetCustomerCountryCount();

            customerCountryCount.ForEach(item => Console.WriteLine($"Country: {item.Country}, Number of customers: {item.CustomerCount}"));
        }
    }
}