using FundaAssignment.Entities.Models;
using System.Collections.Generic;

namespace FundaAssignment.Models
{
    public class MakelaarView
    {
        public List<Makelaar> TopMakelaarsForAmsterdam { get; set; }

        public List<Makelaar> TopMakelaarsForAmsterdamWithTuin { get; set; }
        
    }
}