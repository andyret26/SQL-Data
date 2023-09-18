using Microsoft.Data.SqlClient;
using SqlClientReading.Models;

namespace SqlClientReading.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool AddCustomer(Customer customer)
        {
            bool success = false;
            string sql = "Insert into Customer(FirstName, LastName, Country, PostalCode, Phone, Email)" +
                "Values(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        success = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }

            return success;

        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email" +
                " FROM Customer";

           try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer tempCustomer = new Customer();
                                tempCustomer.Id = reader.GetInt32(0);
                                tempCustomer.FirstName = reader.GetString(1);
                                tempCustomer.LastName = reader.GetString(2);
                                tempCustomer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                tempCustomer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                tempCustomer.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                tempCustomer.Email = reader.GetString(6);

                                customerList.Add(tempCustomer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerList;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email" +
                " FROM Customer" +
                " WHERE CustomerId = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.Email = reader.GetString(6);

                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public List<Customer> GetCustomersByPartialName(string partialName)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email" +
                " FROM Customer" +
                " WHERE CONCAT(FirstName, ' ', LastName) LIKE @name ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("name", $"%{partialName}%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer tempCustomer = new Customer();
                                tempCustomer.Id = reader.GetInt32(0);
                                tempCustomer.FirstName = reader.GetString(1);
                                tempCustomer.LastName = reader.GetString(2);
                                tempCustomer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                tempCustomer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                tempCustomer.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                tempCustomer.Email = reader.GetString(6);

                                customerList.Add(tempCustomer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerList;
        }

        public List<CustomerCountry> GetCustomerCountryCount()
        {
            List<CustomerCountry> customerCountryList = new List<CustomerCountry>();
            string sql = "SELECT Country, Count(CustomerId) AS CustomerCount FROM Customer GROUP BY Country ORDER BY CustomerCount DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tempCustomerCountry = new CustomerCountry();
                                tempCustomerCountry.Country = reader.GetString(0);
                                tempCustomerCountry.CustomerCount = reader.GetInt32(1);

                                customerCountryList.Add(tempCustomerCountry);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerCountryList;
        }

        public string GetCustomerMostPopularGenre(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetHighestSpenders()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetSomeCustomers(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}