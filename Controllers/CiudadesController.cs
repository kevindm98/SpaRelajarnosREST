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
    [RoutePrefix("api/Ciudades")]
	public class CiudadesController : ApiController
	{
        [HttpGet]
        [Route("Consultar")]
        public Ciudad Consultar(int id)
        {
            clsCiudad ciudad = new clsCiudad();
            return ciudad.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsCiudad ciudad = new clsCiudad();
            return ciudad.LlenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Ciudad Ciudad)
        {
            clsCiudad ciudad = new clsCiudad();
            ciudad.ciudad = Ciudad;
            return ciudad.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Ciudad Ciudad)
        {
            clsCiudad ciudad = new clsCiudad();
            ciudad.ciudad = Ciudad;
            return ciudad.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Ciudad Ciudad)
        {
            clsCiudad ciudad = new clsCiudad();
            ciudad.ciudad = Ciudad;
            return ciudad.Eliminar();
        }

        [HttpGet]
		[Route("LlenarCombo")]
		public List<Ciudad> LlenarCombo()
		{
            clsCiudad ciudad = new clsCiudad();
			return ciudad.LlenarCombo();
		}
	}
}