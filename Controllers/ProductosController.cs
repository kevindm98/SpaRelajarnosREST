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
	[RoutePrefix("api/Productos")]
	public class ProductosController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Producto Consultar(int id)
		{
			clsProducto producto = new clsProducto();
			return producto.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Producto Producto)
		{
			clsProducto producto = new clsProducto();
			producto.producto = Producto;
			return producto.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Producto Producto)
		{
			clsProducto producto = new clsProducto();
			producto.producto = Producto;
			return producto.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Producto Producto)
		{
			clsProducto producto = new clsProducto();
			producto.producto = Producto;
			return producto.Eliminar();
		}
	}
}