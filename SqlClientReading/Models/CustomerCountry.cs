using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlClientReading.Models
{
    public class CustomerCountry
    {
        public string Country { get; set; } = null!;
        public int CustomerCount { get; set; }
    }
}
