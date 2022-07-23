using Computer_World.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_World.WebAdmin.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        ClientesBL _clientesBL;
        
        public ClientesController()
        {
            _clientesBL = new ClientesBL(); //instanciando ClientesBL
        }


        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _clientesBL.ObtenerClientes();
     
            return View(listadeClientes);
        }



        public ActionResult Crear()
        {
            var nuevoCliente = new Cliente();
            return View(nuevoCliente);

        }

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if ( cliente.Nombre!= cliente.Nombre.Trim())
                {
                    ModelState.AddModelError("El nombre", "El nombre no debe tener espacios al principio ni al final");
                    return View(cliente);
                }
                _clientesBL.GuardarCliente(cliente);
                return RedirectToAction("Index"); //regrasar a index
            }
            return View(cliente);
        }

        public ActionResult Editar(int Id)
        {
            var cliente = _clientesBL.ObtenerCliente(Id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Nombre != cliente.Nombre.Trim())
                {
                    ModelState.AddModelError("El nombre", "El nombre no debe tener espacios al principio ni al final");
                    return View(cliente);
                }
                _clientesBL.GuardarCliente(cliente);
                return RedirectToAction("Index"); //regrasar a index
            }
            return View(cliente);

        }

        public ActionResult Detalle(int Id)
        {
            var cliente = _clientesBL.ObtenerCliente(Id);
            return View(cliente);
        }

        public ActionResult Eliminar(int Id)
        {
            var cliente = _clientesBL.ObtenerCliente(Id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Eliminar (Cliente cliente)
        {
            _clientesBL.EliminarCliente(cliente.Id);
            return RedirectToAction("Index");

        }
    }
}