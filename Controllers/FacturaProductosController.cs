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
	[RoutePrefix("api/FacturaProductos")]
	public class FacturaProductosController : ApiController
	{
		[HttpGet]
		[Route("Consultar")]
		public FacturaProducto Consultar(int id)
		{
			clsFacturaProducto facturaProducto = new clsFacturaProducto();
			return facturaProducto.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] FacturaProducto FacturaProducto)
		{
			clsFacturaProducto facturaProducto = new clsFacturaProducto();
			facturaProducto.facturaProducto = FacturaProducto;
			return facturaProducto.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] FacturaProducto FacturaProducto)
		{
			clsFacturaProducto facturaProducto = new clsFacturaProducto();
			facturaProducto.facturaProducto = FacturaProducto;
			return facturaProducto.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] FacturaProducto FacturaProducto)
		{
			clsFacturaProducto facturaProducto = new clsFacturaProducto();
			facturaProducto.facturaProducto = FacturaProducto;
			return facturaProducto.Eliminar();
		}
	}
}