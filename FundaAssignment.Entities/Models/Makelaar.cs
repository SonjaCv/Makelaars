using System.Collections.Generic;

namespace FundaAssignment.Entities.Models
{
    public class Makelaar
    {
        public int MakelaarId { get; set; }

        public string MakelaarName { get; set; }

        public int PropertiesCount { get; set; }

        public List<PropertyDetails> PropertyDetails { get; set; }
    }
}
