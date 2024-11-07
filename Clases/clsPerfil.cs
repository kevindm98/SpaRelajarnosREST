using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
    public class clsPerfil
    {
        private SpaRelajarnosEntities db = new SpaRelajarnosEntities();

        public Perfil perfil { get; set; }

        public IQueryable LlenarCombo()
        {
            return from P in db.Set<Perfil>()
                   select new
                   {
                       Codigo = P.Id,
                       Nombre = P.Nombre
                   };
        }
    }
}