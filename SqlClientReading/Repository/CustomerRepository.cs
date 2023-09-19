using Microsoft.Data.SqlClient;
using SqlClientReading.Models;

namespace SqlClientReading.Repository
{
    /// <summary>
    /// A repository class for performing CRUD and other operations on customer data in a SQL database.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Adds a new customer to the database.
        /// </summary>
        /// <param name="customer">The customer object to be added.</param>
        /// <returns>True if the customer was added successfully, false otherwise.</returns>
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

        /// <summary>
        /// Retrieves a list of all customers from the database.
        /// </summary>
        /// <returns>A list of Customer objects representing all customers.</returns>
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

        /// <summary>
        /// Retrieves a customer by their unique identifier (ID) from the database.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The Customer object if found, or an empty Customer object if not found.</returns>
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

        /// <summary>
        /// Retrieves a list of customers whose names contain a partial name match.
        /// </summary>
        /// <param name="partialName">The partial name to search for.</param>
        /// <returns>A list of Customer objects matching the partial name criteria.</returns>
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

        /// <summary>
        /// Retrieves a list of customer countries and the count of customers in each country.
        /// </summary>
        /// <returns>A list of CustomerCountry objects representing customer country counts.</returns>
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

        /// <summary>
        /// Retrieves a list of music genres and the count of tracks purchased by a specific customer.
        /// </summary>
        /// <param name="id">The ID of the customer to analyze.</param>
        /// <returns>A list of CustomerGenre objects representing music genre counts for the customer.</returns>
        public List<CustomerGenre> CustomerMostPopularGenre(int id)
        {
            List<CustomerGenre> genreList = new List<CustomerGenre>();
            string sql = "SELECT " +
                "Genre.Name AS GenreName, " +
                "COUNT(InvoiceLine.TrackId) AS TrackCount " +
                "FROM " +
                "Invoice " +
                "INNER JOIN " +
                "InvoiceLine ON Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                "INNER JOIN " +
                "Track ON InvoiceLine.TrackId = Track.TrackId " +
                "INNER JOIN " +
                "Genre ON Genre.GenreId = Track.GenreId " +
                "WHERE " +
                "Invoice.CustomerId = @CustomerId " +
                "GROUP BY " +
                "Genre.Name " +
                "ORDER BY " +
                "TrackCount DESC;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tempCustomerGenre = new CustomerGenre();
                                tempCustomerGenre.Genre = reader.GetString(0);
                                tempCustomerGenre.GenreCount = reader.GetInt32(1);

                                genreList.Add(tempCustomerGenre);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return genreList;
        }

        /// <summary>
        /// Retrieves a list of the highest spending customers in descending order.
        /// </summary>
        /// <returns>A list of CustomerSpender objects representing the highest spenders.</returns>
        public List<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> spenderList = new List<CustomerSpender>();
            string sql = "SELECT CONCAT(Customer.FirstName, ' ', Customer.LastName) AS FullName, SUM(Invoice.Total) AS TotalAmount " +
                "FROM Customer " +
                "INNER JOIN Invoice ON Invoice.CustomerId = Customer.CustomerId " +
                "GROUP BY CONCAT(Customer.FirstName, ' ', Customer.LastName) " +
                "ORDER BY TotalAmount DESC;";

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
                                var tempsSpender = new CustomerSpender();
                                tempsSpender.FullName = reader.GetString(0);
                                tempsSpender.TotalSpending = reader.GetDecimal(1);

                                spenderList.Add(tempsSpender);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return spenderList;

            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a specified number of customers starting from a specific row in the database.
        /// </summary>
        /// <param name="numberOfRows">The number of rows to retrieve.</param>
        /// <param name="startRow">The starting row index for retrieval.</param>
        /// <returns>A list of Customer objects retrieved based on the specified criteria.</returns>
        public List<Customer> GetSomeCustomers(int numberOfRows, int startRow)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer " +
                "ORDER BY CustomerId " + // Replace with the appropriate column for sorting.
                "OFFSET @StartRow ROWS " +
                "FETCH NEXT @NumberOfRows ROWS ONLY;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartRow", startRow);
                        cmd.Parameters.AddWithValue("@NumberOfRows", numberOfRows);
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
            return customerList; ;
        }

        /// <summary>
        /// Updates an existing customer's information in the database.
        /// </summary>
        /// <param name="customer">The Customer object containing updated information.</param>
        /// <returns>True if the customer was updated successfully, false otherwise.</returns>
        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer " +
                "SET FirstName = @Firstname, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email " +
                "WHERE CustomerId = @CustomerId;";

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
                        cmd.Parameters.AddWithValue("@CustomerId", customer.Id);

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
    }
}