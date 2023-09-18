using SqlClientReading.Models;

namespace SqlClientReading.Repository
{
	public interface ICustomerRepository
	{
		public  List<Customer> GetAllCustomers();
		public Customer GetCustomerById(int id);
		public Customer GetCustomerByName(string name);
		public List<Customer> GetSomeCustomers(int limit, int offset);

		public bool AddCustomer(Customer customer);
		public bool UpdateCustomer(Customer customer);
		public bool DeleteCustomer(int id);

		public int GetCustomerCountryCount();
		public List<Customer> GetHighestSpenders();
		public string GetCustomerMostPopularGenre(Customer customer);
	}
}