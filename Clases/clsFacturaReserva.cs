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

        public IQueryable ListarServicios(int NumeroFactura)
        {
            return from DR in db.Set<DetalleFacturaReserva>()
                   join S in db.Set<Servicio>()
                   on DR.IdServicio equals S.Id
                   join TS in db.Set<TipoServicio>()
                   on S.IdTipoServicio equals TS.Id
                   where DR.Numero == NumeroFactura
                   select new
                   {
                       Eliminar = "<img src=\"../Imagenes/Eliminar.png\" onclick=\"Eliminar(" + DR.Codigo + ", " + DR.Cantidad + ", " + DR.ValorUnitario + ")\"/>",
                       Tipo_Servicio = TS.Nombre,
                       Codigo_Servicio = S.Id,
                       Servicio = S.Nombre,
                       Cantidad = DR.Cantidad,
                       Valor_Unitario = DR.ValorUnitario,
                       Subtotal = DR.Cantidad * DR.ValorUnitario
                   };

        }

        public string EliminarDetalle(int Codigo)
        {
            try
            {
                detalleFacturaReserva = db.DetalleFacturaReservas.FirstOrDefault(d => d.Codigo == Codigo);
                db.DetalleFacturaReservas.Remove(detalleFacturaReserva);
                db.SaveChanges();
                return "Se eliminó el detalle";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}