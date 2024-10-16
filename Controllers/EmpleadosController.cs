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
		public string Insertar([FromBody] Empleado Empleado, int idEspecialidad)
		{
			clsEmpleado empleado = new clsEmpleado();
			empleado.empleado = Empleado;
			return empleado.Insertar(idEspecialidad);
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

        [HttpGet]
        [Route("ListarEmpleados")]
        public IQueryable ListarEmpleados()
        {
            clsEmpleado _empleado = new clsEmpleado();
            return _empleado.ListarEmpleados();
        }
		[HttpGet]
		[Route("LlenarCombo")]
		public List<Especialidad> LlenarCombo()
		{
			clsEmpleado especialidad = new clsEmpleado();
			return especialidad.LlenarCombo();
		}
	}
}