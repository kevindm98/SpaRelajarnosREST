using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsFacturaProducto
	{
        private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

        public FacturaProducto facturaProducto { get; set; }
        public DetalleFacturaProducto detalleFacturaProducto { get; set; }

        public string GrabarFactura()
        {
            if (facturaProducto.Numero == 0)
            {
                return GrabarEncabezado();
            }
            return GrabarDetalle();
        }

        private string GrabarEncabezado()
        {
            facturaProducto.Numero = ObtenerNumeroFactura();
            facturaProducto.Fecha = DateTime.Now;
            db.FacturaProductoes.Add(facturaProducto);
            db.SaveChanges();
            return facturaProducto.Numero.ToString();
        }

        private string GrabarDetalle()
        {
            detalleFacturaProducto = facturaProducto.DetalleFacturaProductoes.FirstOrDefault();
            detalleFacturaProducto.Numero = facturaProducto.Numero;
            db.DetalleFacturaProductoes.Add(detalleFacturaProducto);
            db.SaveChanges();
            return facturaProducto.Numero.ToString();
        }
        private int ObtenerNumeroFactura()
        {
            return db.FacturaProductoes.Select(f => f.Numero).DefaultIfEmpty(0).Max() + 1;

        }

        public IQueryable ListarProductos(int NumeroFactura)
        {
            return from DP in db.Set<DetalleFacturaProducto>()
                   join P in db.Set<Producto>()
                   on DP.IdProducto equals P.Id
                   join TP in db.Set<TipoProducto>()
                   on P.IdTipoProducto equals TP.Id
                   where DP.Numero == NumeroFactura
                   select new
                   {
                       Eliminar = "<img src=\"../Imagenes/Eliminar.png\" onclick=\"Eliminar(" + DP.Codigo + ", " + DP.Cantidad + ", " + DP.ValorUnitario + ")\"/>",
                       Tipo_Producto = TP.Nombre,
                       Codigo_Producto = P.Id,
                       Producto = P.Nombre,
                       Cantidad = DP.Cantidad,
                       Valor_Unitario = DP.ValorUnitario,
                       Subtotal = DP.Cantidad * DP.ValorUnitario
                   };

        }

        public string EliminarDetalle(int Codigo)
        {
            try
            {
                detalleFacturaProducto = db.DetalleFacturaProductoes.FirstOrDefault(d => d.Codigo == Codigo);
                db.DetalleFacturaProductoes.Remove(detalleFacturaProducto);
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