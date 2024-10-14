using SpaRelajarnosREST.Models;
using SpaRelajarnosREST.Clases;
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
	[RoutePrefix("api/Clientes")]
	public class ClientesController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Cliente Consultar(int documento)
		{
			clsCliente cliente = new clsCliente();
			return cliente.Consultar(documento);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Cliente Cliente)
		{
			clsCliente cliente = new clsCliente();
			cliente.cliente = Cliente;
			return cliente.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Cliente Cliente)
		{
			clsCliente cliente = new clsCliente();
			cliente.cliente = Cliente;
			return cliente.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Cliente Cliente)
		{
			clsCliente cliente = new clsCliente();
			cliente.cliente = Cliente;
			return cliente.Eliminar();
		}
	}
}