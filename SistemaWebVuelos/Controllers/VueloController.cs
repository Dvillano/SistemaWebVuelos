using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWebVuelos.Data;
using SistemaWebVuelos.Filters;
using SistemaWebVuelos.Models;
using SistemaWebVuelos.Repository;

namespace SistemaWebVuelos.Controllers
{
    [MyFilterAction]
    public class VueloController : Controller
    {
        private DbVueloContext context = new DbVueloContext();

        // GET: Vuelo
        public ActionResult Index()
        {
            return View("Index", AdmVuelo.Listar());
        }

        [HttpGet] 
        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);
        }

        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                int filasAfectadas = AdmVuelo.Insertar(vuelo);
                if (filasAfectadas > 0)
                {
                    return View("Index", AdmVuelo.Listar());
                }
            }

            return View("Create", vuelo);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = AdmVuelo.Buscar(id);

            if (vuelo != null)
            {
                return View("Edit", vuelo);
            }
            else
                return HttpNotFound();

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                AdmVuelo.Editar(vuelo);
                return RedirectToAction("Index");
            }

            return View("Edit", vuelo);
        }

        public ActionResult Detail(int id)
        {
            Vuelo vuelo = AdmVuelo.Buscar(id);

            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            else
                return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Vuelo vuelo = AdmVuelo.Buscar(id);

            if (vuelo != null)
            { 
                return View("Delete", vuelo);
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo vuelo = AdmVuelo.Buscar(id);

            AdmVuelo.Eliminar(vuelo);
            return RedirectToAction("Index");
        }

        public ActionResult BuscarPorDestino(string destino)
        {
            if (destino != null)
            {
                var vuelos = (from v in context.Vuelos
                              where v.Destino == destino
                              select v).ToList();

                return View("Index", vuelos);
            }
            else
                return RedirectToAction("Index");
        }
    }
}