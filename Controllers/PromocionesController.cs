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
	[RoutePrefix("api/Promociones")]
	public class PromocionesController : ApiController
	{

		[HttpGet]
		[Route("Consultar")]
		public Promocion Consultar(int id)
		{
			clsPromocion promocion = new clsPromocion();
			return promocion.Consultar(id);
		}

		[HttpPost]
		[Route("Insertar")]
		public string Insertar([FromBody] Promocion Promocion)
		{
			clsPromocion promocion = new clsPromocion();
			promocion.promocion = Promocion;
			return promocion.Insertar();
		}

		[HttpPut]
		[Route("Actualizar")]
		public string Actualizar([FromBody] Promocion Promocion)
		{
			clsPromocion promocion = new clsPromocion();
			promocion.promocion = Promocion;
			return promocion.Actualizar();
		}

		[HttpDelete]
		[Route("Eliminar")]
		public string Eliminar([FromBody] Promocion Promocion)
		{
			clsPromocion promocion = new clsPromocion();
			promocion.promocion = Promocion;
			return promocion.Eliminar();
		}
	}
}