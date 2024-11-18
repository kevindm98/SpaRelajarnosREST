using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsFacturaReserva
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public FacturaReserva facturaReserva { get; set; }
		public DetalleFacturaReserva detalleFacturaReserva { get; set; }

        public string GrabarFactura()
        {
            if (facturaReserva.Numero == 0)
            {
                return GrabarEncabezado();
            }
            return GrabarDetalle();
        }

        private string GrabarEncabezado()
        {
            facturaReserva.Numero = ObtenerNumeroFactura();
            facturaReserva.Fecha = DateTime.Now;
            db.FacturaReservas.Add(facturaReserva);
            db.SaveChanges();
            return facturaReserva.Numero.ToString();
        }

        private string GrabarDetalle()
        {
            detalleFacturaReserva = facturaReserva.DetalleFacturaReservas.FirstOrDefault();
            detalleFacturaReserva.Numero = facturaReserva.Numero;
            db.DetalleFacturaReservas.Add(detalleFacturaReserva);
            db.SaveChanges();
            return facturaReserva.Numero.ToString();
        }
        private int ObtenerNumeroFactura()
        {
            return db.FacturaReservas.Select(f => f.Numero).DefaultIfEmpty(0).Max() + 1;

        }
    }
}