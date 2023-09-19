namespace SqlClientReading.Models
{
    /// <summary>
    /// Represents a customer count per country.
    /// </summary>
    public class CustomerCountry
    {
        public string Country { get; set; } = null!;
        public int CustomerCount { get; set; }
    }
}
