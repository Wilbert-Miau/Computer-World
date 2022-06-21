
using Computer_World.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_World.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriasBL _categoriasBL;
        public CategoriasController() //constructor
        {
            _categoriasBL = new CategoriasBL();

        }
        // GET: Categorias
        public ActionResult Index()
        {
            var listadeCategorias = _categoriasBL.ObtenerCategorias();
            return View(listadeCategorias);
        }

        public ActionResult Crear()
        {
            
            var nuevaCategoria = new Categoria();
            return View(nuevaCategoria);
        }
        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            //validar si el modelo está  bien
            if (ModelState.IsValid) // si descripcion viene bien es verdadero sino  es falso
            {

                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion","La descripcion no debe tener espacios al principio o al final");
                    return View(categoria);
                }


                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index"); //regrasar a index
            }
            return View(categoria); //regresa a la misma categoria
            
        }

        public ActionResult Editar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }
        [HttpPost]
        public ActionResult Editar (Categoria categoria)
        {

            //validar si el modelo está  bien
            if (ModelState.IsValid) // si descripcion viene bien es verdadero sino  es falso
            {

                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe tener espacios al principio o al final");
                    return View(categoria);
                }


                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index"); //regrasar a index
            }
            return View(categoria); //regresa a la misma categoria

        }

        public ActionResult Detalle(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);

        }

        public ActionResult Eliminar (int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Eliminar (Categoria categoria)
        {
            _categoriasBL.EliminarCategoria(categoria.Id);
            return RedirectToAction("Index");
        }

    }
}