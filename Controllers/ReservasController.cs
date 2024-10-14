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
	[RoutePrefix("api/Reservas")]
	public class ReservasController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Reserva Consultar(int id)
		{
			clsReserva reserva = new clsReserva();
			return reserva.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Reserva Reserva)
		{
			clsReserva reserva = new clsReserva();
			reserva.reserva = Reserva;
			return reserva.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Reserva Reserva)
		{
			clsReserva reserva = new clsReserva();
			reserva.reserva = Reserva;
			return reserva.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Reserva Reserva)
		{
			clsReserva reserva = new clsReserva();
			reserva.reserva = Reserva;
			return reserva.Eliminar();
		}
	}
}