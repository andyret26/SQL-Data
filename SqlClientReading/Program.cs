using SqlClientReading.Models;
using SqlClientReading.Repository;

namespace SqlClientReading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cr = new CustomerRepository();


            Console.WriteLine("\n------- ALL CUSTOMERS -------");
            cr.GetAllCustomers().ForEach(customer => Console.WriteLine($"Id: {customer.Id}, First name: {customer.FirstName}, ...."));


            Console.WriteLine("\n------- CUSTOMER BY ID -------");
            var customerFromDb = cr.GetCustomerById(5);
            Console.WriteLine($"Id: {customerFromDb.Id}, First name: {customerFromDb.FirstName}, ....");


            Console.WriteLine("\n------- CUSTOMER BY PRTIAL NAME -------");
            var customersFromDb = cr.GetCustomerById(5);
            cr.GetCustomersByPartialName("ers").ForEach(customer => Console.WriteLine($"Id: {customer.Id}, Full name: {customer.FirstName} {customer.LastName}, ...."));


            Console.WriteLine("\n------- SOME CUSTOMERS -------");
            cr.GetSomeCustomers(10, 5).ForEach(customer => Console.WriteLine($"Id: {customer.Id}, First name: {customer.FirstName}, ...."));


            Console.WriteLine("\n------- ADD CUSTOMER -------");
            var customer = new Customer();
            customer.FirstName = "First1";
            customer.LastName = "Last1";
            customer.Country = "Country1";
            customer.PostalCode = "1234";
            customer.Phone = "12345678";
            customer.Email = "mail@mail.com";

            var addedCustomer = cr.AddCustomer(customer);
            if (addedCustomer)
            {
                Console.WriteLine("Added cutomer sucessfully");
            }
            else
            {
                Console.WriteLine("Error, Customer not added");
            }


            Console.WriteLine("\n------- UPDATE CUSTOMER -------");
            Customer cToUpdate = cr.GetCustomerById(3);
            cToUpdate.FirstName = "UpdatedFirstName";
            bool updatedCustomer = cr.UpdateCustomer(cToUpdate);
            if (updatedCustomer)
            {
                Console.WriteLine("Updated customer sucessfully");
            }
            else
            {
                Console.WriteLine("Error, Customer not updated");
            }


            Console.WriteLine("\n------- CUSTOMER COUNTRY COUNT -------");
            var customerCountryCount = cr.GetCustomerCountryCount();
            customerCountryCount.ForEach(item => Console.WriteLine($"Country: {item.Country}, Number of customers: {item.CustomerCount}"));


            Console.WriteLine("\n------- CUSTOMER 5 HIGHEST SPENDERS -------");
            var spenderList = cr.GetHighestSpenders();
            int i = 0;
            foreach (var item in spenderList)
            {
                Console.WriteLine($"Full Name: {item.FullName}, Total Spending: {item.TotalSpending}");
                i++;
                if (i == 5)
                {
                    break;
                }
            }


            Console.WriteLine("\n------- CUSTOMER POPULAR GENRE -------");
            var customerGenre = cr.CustomerMostPopularGenre(5);

            // If top two genres has same count display both Else display the top one
            if (customerGenre[0].GenreCount == customerGenre[1].GenreCount)
            {
                Console.WriteLine($"Genre Name: {customerGenre[0].Genre}, Count: {customerGenre[0].GenreCount}");
                Console.WriteLine($"Genre Name: {customerGenre[1].Genre}, Count: {customerGenre[1].GenreCount}");
            } else
            {
                Console.WriteLine($"Genre Name: {customerGenre[0].Genre}, Count: {customerGenre[0].GenreCount}");
            }
        }
    }
}