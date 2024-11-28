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
    [RoutePrefix("api/FacturaProductos")]
	public class FacturaProductosController : ApiController
	{
        [HttpPost]
        [Route("GrabarFactura")]
        public string GrabarFactura([FromBody] FacturaProducto facturaProducto)
        {
            clsFacturaProducto Factura = new clsFacturaProducto();
            Factura.facturaProducto = facturaProducto;
            return Factura.GrabarFactura();
        }

        [HttpGet]
        [Route("ListarProductos")]
        public IQueryable ListarServicios(int NumeroFactura)
        {
            clsFacturaProducto Factura = new clsFacturaProducto();
            return Factura.ListarProductos(NumeroFactura);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int Codigo)
        {
            clsFacturaProducto Factura = new clsFacturaProducto();
            return Factura.EliminarDetalle(Codigo);
        }
    }
}