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
	[RoutePrefix("api/Proveedores")]
	public class ProveedoresController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Proveedor Consultar(int id)
		{
			clsProveedor proveedor = new clsProveedor();
			return proveedor.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Proveedor Proveedor)
		{
			clsProveedor proveedor = new clsProveedor();
			proveedor.proveedor = Proveedor;
			return proveedor.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Proveedor Proveedor)
		{
			clsProveedor proveedor = new clsProveedor();
			proveedor.proveedor = Proveedor;
			return proveedor.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Proveedor Proveedor)
		{
			clsProveedor proveedor = new clsProveedor();
			proveedor.proveedor = Proveedor;
			return proveedor.Eliminar();
		}
	}
}