using ApiPruebas.Models;
using ApiPruebas.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private RepositoryPrueba repo;

        public ApiController(RepositoryPrueba repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Articulo>> GetArticulos()
        {
            List<Articulo> items = this.repo.GetAllArticulos();
            return items;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<Articulo> ArticuloId(int id)
        {
            Articulo articulo = this.repo.GetArticuloId(id);
            return articulo;
        }

        [HttpPost]
        [Route("[action]")]
        public Boolean RegistraArticulo(Articulo articulo)
        {
            if (this.repo.RegistraArticulo(articulo.Id, articulo.Nombre, articulo.Contenido))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPut]
        public Boolean UpdateItem(Articulo articulo)
        {
            if (this.repo.UpdateArticulo(articulo.Id, articulo.Nombre, articulo.Contenido))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
