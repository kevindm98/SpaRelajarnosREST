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
	[RoutePrefix("api/FacturaReservas")]
	public class FacturaReservasController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public FacturaReserva Consultar(int id)
		{
			clsFacturaReserva facturaReserva = new clsFacturaReserva();
			return facturaReserva.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] FacturaReserva FacturaReserva)
		{
			clsFacturaReserva facturaReserva = new clsFacturaReserva();
			facturaReserva.facturaReserva = FacturaReserva;
			return facturaReserva.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] FacturaReserva FacturaReserva)
		{
			clsFacturaReserva facturaReserva = new clsFacturaReserva();
			facturaReserva.facturaReserva = FacturaReserva;
			return facturaReserva.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] FacturaReserva FacturaReserva)
		{
			clsFacturaReserva facturaReserva = new clsFacturaReserva();
			facturaReserva.facturaReserva = FacturaReserva;
			return facturaReserva.Eliminar();
		}
	}
}