using Computer_World.BL;
using System.Web.Mvc;
using System.Configuration;

namespace Computer_World.web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productosBL = new ProductosBL();
            var listadeProductos = productosBL.ObtenerProductosActivos();
            ViewBag.adminWebsiteUrl= ConfigurationManager.AppSettings["adminWebsiteUrl"];
            return View(listadeProductos);
            
        }
    }
}