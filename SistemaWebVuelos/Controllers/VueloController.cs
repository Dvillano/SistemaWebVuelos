using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;

namespace SistemaWebVuelos.Controllers
{
    public class VueloController : Controller
    {
        private DbVueloContext context = new DbVueloContext();

        // GET: Vuelo
        public ActionResult Index()
        {
            var vuelos = context.Vuelos.ToList();
            return View("Index", vuelos);
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
                context.Vuelos.Add(vuelo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", vuelo);
        }

        public ActionResult Detail(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);

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
            Vuelo vuelo = context.Vuelos.Find(id);

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
            Vuelo vuelo = context.Vuelos.Find(id);

            context.Vuelos.Remove(vuelo);
            context.SaveChanges();

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