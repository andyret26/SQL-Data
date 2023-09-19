using SqlClientReading.Models;

namespace SqlClientReading.Repository
{
	/// <summary>
	/// Interface for the CustomerRepository
	/// </summary>
	public interface ICustomerRepository
	{
		public  List<Customer> GetAllCustomers();
		public Customer GetCustomerById(int id);
		public List<Customer> GetCustomersByPartialName(string partialName);
		public List<Customer> GetSomeCustomers(int limit, int offset);

		public bool AddCustomer(Customer customer);
		public bool UpdateCustomer(Customer customer);
		public List<CustomerCountry> GetCustomerCountryCount();
		public List<CustomerSpender> GetHighestSpenders();
		public List<CustomerGenre> CustomerMostPopularGenre(int CustomerId);
	}
}