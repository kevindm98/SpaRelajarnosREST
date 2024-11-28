using SpaRelajarnosREST.Clases;
using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SpaRelajarnosREST.Controllers
{
	[EnableCors(origins: "https://localhost:44306", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/Sedes")]
	public class SedesController : ApiController
	{

        [HttpGet]
        [Route("Consultar")]
        public Sede Consultar(int id)
        {
            clsSede Cargo = new clsSede();
            return Cargo.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsSede Cargo = new clsSede();
            return Cargo.LlenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Sede sede)
        {
            clsSede Cargo = new clsSede();
            Cargo.sede = sede;
            return Cargo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Sede sede)
        {
            clsSede Cargo = new clsSede();
            Cargo.sede = sede;
            return Cargo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Sede sede)
        {
            clsSede Cargo = new clsSede();
            Cargo.sede = sede;
            return Cargo.Eliminar();
        }

        [HttpGet]
		[Route("LlenarCombo")]
		public List<Sede> LlenarCombo()
		{
			clsSede sede = new clsSede();
			return sede.LlenarCombo();
		}
	}
}