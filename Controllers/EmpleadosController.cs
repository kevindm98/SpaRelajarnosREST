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
	[RoutePrefix("api/Empleados")]
	public class EmpleadosController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Empleado Consultar(int documento)
		{
			clsEmpleado empleado = new clsEmpleado();
			return empleado.Consultar(documento);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Empleado Empleado)
		{
			clsEmpleado empleado = new clsEmpleado();
			empleado.empleado = Empleado;
			return empleado.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Empleado Empleado)
		{
			clsEmpleado empleado = new clsEmpleado();
			empleado.empleado = Empleado;
			return empleado.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Empleado Empleado)
		{
			clsEmpleado empleado = new clsEmpleado();
			empleado.empleado = Empleado;
			return empleado.Eliminar();
		}
	}
}