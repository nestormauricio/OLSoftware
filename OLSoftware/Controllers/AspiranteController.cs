using OLSoftware.Data;
using OLSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLSoftware.Controllers
{
    public class AspiranteController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        public List<Aspirante> Get()
        {
            return AspiranteData.listarAspirante();
            //return new string[] { "value1", "value2" };
        }
        // GET api/<controller>/5
        public Aspirante Get(int id)
        {
            return AspiranteData.obtenerAspirante(id);
            //return "value";
        }
        // POST api/<controller>
        public bool Post([FromBody] Aspirante oAspirante)
        {
            return AspiranteData.registrarAspirante(oAspirante);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody]Aspirante oAspirante)
        {
            return AspiranteData.modificarAspirante(oAspirante);
        }
        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return AspiranteData.eliminarAspirante(id);
        }
    }
}