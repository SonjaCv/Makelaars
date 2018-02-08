using FundaAssignment.Services;
using System.Threading.Tasks;
using System.Web.Mvc;
using FundaAssignment.Models;

namespace FundaAssignment.Controllers
{
    public class MakelaarController : Controller
    {

        IPropertiesService _propertiesService;
        public MakelaarController(IPropertiesService propertiesService)
        {
            _propertiesService = propertiesService;
        }

        // GET: Makelaar
        public async Task<ActionResult> Index()
        {
            //Get makelaars with houses for sale in Amsterdam
            var makelaarsAmsterdam = await _propertiesService.GetTopMakelaarsByCity("amsterdam", false);

            //Get makelaars with houses for sale in Amsterdam with garden
            var makelaarsAmsterdamWithTuin = await _propertiesService.GetTopMakelaarsByCity("amsterdam", true);

            var model = new MakelaarView
            {
                TopMakelaarsForAmsterdam = makelaarsAmsterdam,
                TopMakelaarsForAmsterdamWithTuin = makelaarsAmsterdamWithTuin
            };
            return View(model);
        }
    }
}