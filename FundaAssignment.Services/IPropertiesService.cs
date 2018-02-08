using System.Collections.Generic;
using System.Threading.Tasks;
using FundaAssignment.Entities.Models;

namespace FundaAssignment.Services
{
    public interface IPropertiesService
    {
        Task<List<Makelaar>> GetTopMakelaarsByCity(string city, bool hasGarden);       
    }
}
