namespace SqlClientReading.Models
{
    /// <summary>
    /// Represents a customer's spending information, including their full name and total spending amount.
    /// </summary>
    public class CustomerSpender
    {
        public string FullName { get; set; } = null!;
        public decimal TotalSpending { get; set; }
    }

}
