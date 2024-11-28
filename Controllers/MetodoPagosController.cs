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
    [Authorize]
    [RoutePrefix("api/MetodoPagos")]
	public class MetodoPagosController : ApiController
	{
		[HttpGet]
		[Route("LlenarCombo")]
		public List<MetodoPago> LlenarCombo()
		{
			clsMetodoPago metodoPago = new clsMetodoPago();
			return metodoPago.LlenarCombo();
		}
	}
}