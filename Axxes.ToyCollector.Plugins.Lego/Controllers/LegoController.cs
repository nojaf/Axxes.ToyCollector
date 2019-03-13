using Axxes.ToyCollector.Plugins.Lego.Models;
using Microsoft.AspNetCore.Mvc;

namespace Axxes.ToyCollector.Plugins.Lego.Controllers
{
    public class LegoController : Controller
    {
        public IActionResult Index()
        {
            var t = typeof(LegoSet).AssemblyQualifiedName;
            return View();
        }
    }
}
