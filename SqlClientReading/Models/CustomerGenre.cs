namespace SqlClientReading.Models
{
    /// <summary>
    /// Represents a count of music tracks within a specific genre for a customer.
    /// </summary>
    public class CustomerGenre
    {
        public string Genre { get; set; } = null!;
        public int GenreCount { get; set; }
    }
}

