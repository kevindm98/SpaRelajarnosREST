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
	[RoutePrefix("api/Cargos")]
	public class CargosController : ApiController
	{
        [HttpGet]
        [Route("Consultar")]
        public Cargo Consultar(int id)
        {
            clsCargo Cargo = new clsCargo();
            return Cargo.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsCargo Cargo = new clsCargo();
            return Cargo.LlenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cargo cargo)
        {
            clsCargo Cargo = new clsCargo();
            Cargo.cargo = cargo;
            return Cargo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cargo cargo)
        {
            clsCargo Cargo = new clsCargo();
            Cargo.cargo = cargo;
            return Cargo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Cargo cargo)
        {
            clsCargo Cargo = new clsCargo();
            Cargo.cargo = cargo;
            return Cargo.Eliminar();
        }

        [HttpGet]
		[Route("LlenarCombo")] 
		public List<Cargo> LlenarCombo()
		{
			clsCargo cargo = new clsCargo();
			return cargo.LlenarCombo();
		}
	}
}