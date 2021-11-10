using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Data
{
    public class DbVueloContext : DbContext
    {
        public DbVueloContext() : base("KeyDB") { }
        public DbSet<Vuelo> Vuelos { get; set; }
    }
}