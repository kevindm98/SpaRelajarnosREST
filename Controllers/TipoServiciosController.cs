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
	[RoutePrefix("api/TipoServicios")]
	public class TipoServiciosController : ApiController
	{

		[HttpGet]
		[Route("LlenarCombo")]
		public List<TipoServicio> LlenarCombo()
		{
			clsTipoServicio tipoServicio = new clsTipoServicio();
			return tipoServicio.LlenarCombo();
		}
	}
}