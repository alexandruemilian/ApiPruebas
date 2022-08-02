using ApiPruebas.Data;
using ApiPruebas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPruebas.Repositories
{
    public class RepositoryPrueba
    {
        private ApiContext context;
        public RepositoryPrueba(ApiContext context)
        {
            this.context = context;
        }

        public List<Articulo> GetAllArticulos()
        {
            List<Articulo> articulos = this.context.Articulo.ToList();
            return articulos;
        }

        public bool UpdateArticulo(int id, string nombre, string contenido)
        {
            Articulo articulo = new Articulo()
            {
                Id = id,
                Nombre = nombre,
                Contenido = contenido
            };
            this.context.Update(articulo);
            this.context.SaveChanges();
            return true;
        }

        public bool RegistraArticulo(int id, string nombre, string contenido)
        {
            Articulo articulo = new Articulo()
            {
                Id = id,
                Nombre = nombre,
                Contenido = contenido
            };
            this.context.Add(articulo);
            this.context.SaveChanges();
            return true;
        }

        public Articulo GetArticuloId(int id)
        {
            return this.context.Articulo.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
