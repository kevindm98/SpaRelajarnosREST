using SpaRelajarnosREST.Clases;
using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpaRelajarnosREST.Controllers
{
	[RoutePrefix("api/Facturaciones")]
	public class FacturacionesController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Facturacion Consultar(int id)
		{
			clsFacturacion facturacion = new clsFacturacion();
			return facturacion.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Facturacion Facturacion)
		{
			clsFacturacion facturacion = new clsFacturacion();
			facturacion.facturacion = Facturacion;
			return facturacion.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Facturacion Facturacion)
		{
			clsFacturacion facturacion = new clsFacturacion();
			facturacion.facturacion = Facturacion;
			return facturacion.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Facturacion Facturacion)
		{
			clsFacturacion facturacion = new clsFacturacion();
			facturacion.facturacion = Facturacion;
			return facturacion.Eliminar();
		}
	}
}