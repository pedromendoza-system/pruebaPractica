using ejercicio2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ejercicio2.Permisos;


namespace ejercicio2.Controllers
{
    [ValidarSesion]
    public class ProductoController : Controller
    {
        private readonly ProductoModel producto;
    

        public ProductoController()
        {
            producto = new ProductoModel();
      
        }


        [HttpGet]
        public ActionResult Agregar()
        {
            var categorias = producto.ObtenerCategorias();
            var proveedores = producto.ObtenerProveedores();

            ViewBag.Categorias = new SelectList(categorias, "CategoriaID", "Nombre");
            ViewBag.Proveedores = new SelectList(proveedores, "ProveedorID", "Nombre");

            return View();
        }

        // Acción para procesar el formulario de agregar producto
        [HttpPost]
        public ActionResult Agregar(Producto nuevoProducto)
        {
            if (ModelState.IsValid)
            {
                producto.AgregarProducto(nuevoProducto);
                return RedirectToAction("Inicio");
            }

            // Si el modelo no es válido, volver a mostrar el formulario con los datos ingresados
            var categorias = producto.ObtenerCategorias();
            var proveedores = producto.ObtenerProveedores();

            ViewBag.Categorias = new SelectList(categorias, "CategoriaID", "Nombre");
            ViewBag.Proveedores = new SelectList(proveedores, "ProveedorID", "Nombre");

            return View(nuevoProducto);
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            var productoExistente = producto.ObtenerProductoPorId(id);
            if (productoExistente == null)
            {
                return HttpNotFound();
            }

            var categorias = producto.ObtenerCategorias();
            var proveedores = producto.ObtenerProveedores();

            ViewBag.Categorias = new SelectList(categorias, "CategoriaID", "Nombre", productoExistente.CategoriaID);
            ViewBag.Proveedores = new SelectList(proveedores, "ProveedorID", "Nombre", productoExistente.ProveedorID);

            return View(productoExistente);
        }

        [HttpPost]
        public ActionResult Editar(Producto productoEditado)
        {
            if (ModelState.IsValid)
            {
                producto.ActualizarProducto(productoEditado);
                return RedirectToAction("Inicio");
            }

            var categorias = producto.ObtenerCategorias();
            var proveedores = producto.ObtenerProveedores();

            ViewBag.Categorias = new SelectList(categorias, "CategoriaID", "Nombre", productoEditado.CategoriaID);
            ViewBag.Proveedores = new SelectList(proveedores, "ProveedorID", "Nombre", productoEditado.ProveedorID);

            return View(productoEditado);
        }








        public ActionResult Inicio()
        {
            var productos = producto.ObtenerProductosActivos();
            return View(productos);
        }

        [HttpPost]
        public ActionResult Eliminar(int productoID)
        {
            producto.CambiarEstadoProducto(productoID, false);
            return RedirectToAction("Inicio");
        }

    }
}