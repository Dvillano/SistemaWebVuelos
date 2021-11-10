using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SistemaWebVuelos.Data
{
    public class VueloInitializer : DropCreateDatabaseAlways<DbVueloContext>
    {
        protected override void Seed(DbVueloContext context)
        {
            var vuelos = new List<Vuelo>();

            vuelos.ForEach(s => context.Vuelos.Add(s));
            context.SaveChanges();
        }
    }
}