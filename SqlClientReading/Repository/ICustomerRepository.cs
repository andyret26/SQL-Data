using SqlClientReading.Models;

namespace SqlClientReading.Repository
{
	public interface ICustomerRepository
	{
		public  List<Customer> GetAllCustomers();
		public Customer GetCustomerById(int id);
		public List<Customer> GetCustomersByPartialName(string partialName);
		public List<Customer> GetSomeCustomers(int limit, int offset);

		public bool AddCustomer(Customer customer);
		public bool UpdateCustomer(Customer customer);
		public bool DeleteCustomer(int id);

		public List<CustomerCountry> GetCustomerCountryCount();
		public List<Customer> GetHighestSpenders();
		public string GetCustomerMostPopularGenre(Customer customer);
	}
}