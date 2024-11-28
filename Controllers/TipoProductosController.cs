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

    [RoutePrefix("api/TipoProductos")]
	public class TipoProductosController : ApiController
	{
        [HttpGet]
        [Route("Consultar")]
        public TipoProducto Consultar(int id)
        {
            clsTipoProducto Tproducto = new clsTipoProducto();
            return Tproducto.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsTipoProducto Tproducto = new clsTipoProducto();
            return Tproducto.LlenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] TipoProducto TProducto)
        {
            clsTipoProducto Tproducto = new clsTipoProducto();
            Tproducto.tipoProducto = TProducto;
            return Tproducto.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] TipoProducto TProducto)
        {
            clsTipoProducto Tproducto = new clsTipoProducto();
            Tproducto.tipoProducto = TProducto;
            return Tproducto.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] TipoProducto TProducto)
        {
            clsTipoProducto Tproducto = new clsTipoProducto();
            Tproducto.tipoProducto = TProducto;
            return Tproducto.Eliminar();
        }

        [HttpGet]
		[Route("LlenarCombo")]
		public List<TipoProducto> LlenarCombo()
		{
			clsTipoProducto tipoProducto = new clsTipoProducto();
			return tipoProducto.LlenarCombo();
		}
	}
}