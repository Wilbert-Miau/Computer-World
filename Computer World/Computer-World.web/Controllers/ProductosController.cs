using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Computer_World.web.Models;

namespace Computer_World.web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            var producto = new ProductoModel();
            producto.Id = 1;
            producto.Descripcion = "computadora";

            var producto2 = new ProductoModel();
            producto2.Id = 2;
            producto2.Descripcion = "computadora2";
            var producto3 = new ProductoModel();
            producto3.Id = 3;
            producto3.Descripcion = "computadora3";

            var listadeProductos = new List<ProductoModel>();
            listadeProductos.Add(producto);
            listadeProductos.Add(producto2);
            listadeProductos.Add(producto3);
            return View(listadeProductos);
        }
    }
}