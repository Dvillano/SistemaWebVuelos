using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Repository
{
    public static class AdmVuelo
    {
        static DbVueloContext context = new DbVueloContext();

        public static List<Vuelo> Listar()
        {
            var vuelos = context.Vuelos.ToList();
            return vuelos;
        }


        public static Vuelo Buscar(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            context.Entry(vuelo).State = EntityState.Detached;
            return vuelo;
        }

        public static int Insertar(Vuelo vuelo)
        {
            context.Vuelos.Add(vuelo);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }

        public static int Editar(Vuelo vuelo)
        {
            context.Vuelos.Attach(vuelo);
            context.Entry(vuelo).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public static void Eliminar(Vuelo vuelo)
        {
            context.Vuelos.Remove(vuelo);
            context.SaveChanges();
        }


    }
}