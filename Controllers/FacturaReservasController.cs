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
    [RoutePrefix("api/FacturaReservas")]
	public class FacturaReservasController : ApiController
	{
        [HttpPost]
        [Route("GrabarFactura")]
        public string GrabarFactura([FromBody] FacturaReserva facturaReserva)
        {
            clsFacturaReserva Factura = new clsFacturaReserva();
            Factura.facturaReserva = facturaReserva;
            return Factura.GrabarFactura();
        }

        [HttpGet]
        [Route("ListarServicios")]
        public IQueryable ListarServicios(int NumeroFactura)
        {
            clsFacturaReserva Factura = new clsFacturaReserva();
            return Factura.ListarServicios(NumeroFactura);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int Codigo)
        {
            clsFacturaReserva Factura = new clsFacturaReserva();
            return Factura.EliminarDetalle(Codigo);
        }
    }
}