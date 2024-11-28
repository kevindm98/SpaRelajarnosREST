using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
	public class clsReserva
	{
		private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

		public Reserva reserva { get; set; }

		public Reserva Consultar(int id)
		{
			return db.Reservas.FirstOrDefault(r => r.Id == id);
		}

		public string Insertar()
		{
			try
			{
				db.Reservas.Add(reserva);
				db.SaveChanges();
				return "Reserva insertada satisfactoriamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			Reserva _reserva = Consultar(reserva.Id);

			try
			{
				if (_reserva != null)
				{
					db.Reservas.AddOrUpdate(reserva);
					db.SaveChanges();
					return "Reserva actualizada satisfactoriamente";
				}
				else
				{
					return "Reserva no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Eliminar()
		{
			Reserva _reserva = Consultar(reserva.Id);

			try
			{
				if (_reserva != null)
				{
					db.Reservas.Remove(_reserva);
					db.SaveChanges();
					return "Reserva eliminada satisfactoriamente";
				}
				else
				{
					return "Reserva no encontrada";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

        public IQueryable LlenarTabla()
        {
            return from r in db.Set<Reserva>()
                   join f in db.Set<FacturaReserva>()
                   on r.IdFacturaReserva equals f.Numero
                   join e in db.Set<Estado>()
                   on r.IdEstado equals e.Id
				   join c in db.Set<Cliente>()
				   on f.IdCliente equals c.Id
                   join s in db.Set<Sede>()
                   on r.IdSede equals s.Id
                   orderby r.Fecha
                   select new
                   {
                       Id = r.Id,
					   Cliente = c.Nombre,
					   DocumentoCliente = c.Documento,
					   Fecha = r.Fecha,
					   Hora = r.Hora,
					   Sede = s.Nombre,
					   NumeroFactura = f.Numero,
					   Estado = e.Nombre,
					   
                   };
        }

    }
}