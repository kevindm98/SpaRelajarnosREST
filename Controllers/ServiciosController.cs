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
	[RoutePrefix("api/Servicios")]
	public class ServiciosController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Servicio Consultar(int id)
		{
			clsServicio servicio = new clsServicio();
			return servicio.Consultar(id);
		}

		[HttpGet]
		[Route("LlenarTabla")]
		public IQueryable LlenarTabla()
		{
			clsServicio servicio = new clsServicio();
			return servicio.LlenarTabla();
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Servicio Servicio)
		{
			clsServicio servicio = new clsServicio();
			servicio.servicio = Servicio;
			return servicio.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Servicio Servicio)
		{
			clsServicio servicio = new clsServicio();
			servicio.servicio = Servicio;
			return servicio.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Servicio Servicio)
		{
			clsServicio servicio = new clsServicio();
			servicio.servicio = Servicio;
			return servicio.Eliminar();
		}
	}
}