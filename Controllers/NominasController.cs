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
	[RoutePrefix("api/Nominas")]
	public class NominasController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Nomina Consultar(int id)
		{
			clsNomina nomina = new clsNomina();
			return nomina.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Nomina Nomina)
		{
			clsNomina nomina = new clsNomina();
			nomina.nomina = Nomina;
			return nomina.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Nomina Nomina)
		{
			clsNomina nomina = new clsNomina();
			nomina.nomina = Nomina;
			return nomina.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Nomina Nomina)
		{
			clsNomina nomina = new clsNomina();
			nomina.nomina = Nomina;
			return nomina.Eliminar();
		}
	}
}