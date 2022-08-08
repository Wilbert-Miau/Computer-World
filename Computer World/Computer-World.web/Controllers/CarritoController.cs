using Computer_World.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_World.web.Controllers
{

    public class CarritoController : Controller
    {
        // GET: Carrito
        OrdenesBL _ordenesBL;
        ClientesBL _clientesBL;

        ProductosBL _productosBL;

        public CarritoController()
        {
            _ordenesBL = new OrdenesBL();
        }

        public ActionResult Index(int id)
        {

            var carrito = _ordenesBL.ObtenerOrden(id);
            carrito.ListadeOrdenDetalle = _ordenesBL.ObtenerOrdenDetalle(id);

            return View(carrito);

            //un carrito es una orden.
            //Mostrar orden anterior.

            //Se muestra una lista de productos añadidos al carrito, a la orden.

        }




        
        public ActionResult Agregar(int id)
        {
            var producto = new Producto();
            _productosBL = new ProductosBL();
            producto = _productosBL.ObtenerProducto(id);
            if (Session["carrito"] == null)
            {
                List<Producto> lista = new List<Producto>();
                lista.Add(producto);
                Session["carrito"] = lista;
                ViewBag.carrito = lista.Count();
                Session["contador"] = 1;
            }
            else
            {
                List<Producto> lista = (List<Producto>)Session["carrito"];
                lista.Add(producto);
                Session["carrito"] = lista;
                ViewBag.carrito = lista.Count();
                Session["contador"] = Convert.ToInt32(Session["contador"]) + 1;

            }

            return RedirectToAction("Index","Home");



         /*   var nuevoCarrito = new Orden();
            nuevoCarrito.Cliente.Nombre = "deafult";
            nuevoCarrito.ClienteId = 2;

           var elProducto= _productosBL.ObtenerProducto(id);
            var carritodetalle = new OrdenDetalle();
            carritodetalle.OrdenId = nuevoCarrito.Id;
            carritodetalle.Cantidad = 5;
            carritodetalle.ProductoId = id;
            carritodetalle.Precio = elProducto.Precio;
            carritodetalle.Producto = elProducto;
            carritodetalle.Total = carritodetalle.Cantidad * carritodetalle.Precio;
            _ordenesBL.GuardarOrden(nuevoCarrito);
            _ordenesBL.GuardarOrdenDetalle(carritodetalle);
            return Content("hola");*/
        }
        public ActionResult EliminarProducto(int id)
        {
            var ordenDetalle = _ordenesBL.ObtenerOrdenDetallePorId(id);
            return View(ordenDetalle);
        }

        [HttpPost]
        public ActionResult EliminarProducto(OrdenDetalle carritodetalle)
        {
            _ordenesBL.EliminarOrdenDetalle(carritodetalle.Id);
            return RedirectToAction("Index", new { id = carritodetalle.OrdenId });

        }

        public ActionResult Miorden()
        {
            ViewBag.adminWebsiteUrl = ConfigurationManager.AppSettings["adminWebsiteUrl"];
            return View((List<Producto>)Session["carrito"]);
        }

        public ActionResult Remover(int id)
        {
            _productosBL = new ProductosBL();
            Producto producto = _productosBL.ObtenerProducto(id);
            List<Producto> lista = (List<Producto>)Session["carrito"];
            lista.RemoveAll(x=>x.Id==producto.Id);
            Session["carrito"] = lista;
            Session["contador"] = Convert.ToInt32(Session["contador"]) - 1;
            return RedirectToAction("Miorden","Carrito");

        }
     


        

      
  
    }
}