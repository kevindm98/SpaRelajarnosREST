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
	[RoutePrefix("api/Especilidades")]
	public class EspecilidadesController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Especialidad Consultar(int id)
		{
			clsEspecialidad especialidad = new clsEspecialidad();
			return especialidad.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Especialidad Especialidad)
		{
			clsEspecialidad especialidad = new clsEspecialidad();
			especialidad.especialidad = Especialidad;
			return especialidad.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Especialidad Especialidad)
		{
			clsEspecialidad especialidad = new clsEspecialidad();
			especialidad.especialidad = Especialidad;
			return especialidad.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Especialidad Especialidad)
		{
			clsEspecialidad especialidad = new clsEspecialidad();
			especialidad.especialidad = Especialidad;
			return especialidad.Eliminar();
		}
        [HttpGet]
        [Route("ListarEspecialidad")]
        public IQueryable ListarEspecialidad()
        {
            clsEspecialidad _especialidad = new clsEspecialidad();
            return _especialidad.ListarEspecialidad();
        }
    }
}