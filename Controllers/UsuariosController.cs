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
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Usuario usuario, int Perfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.Insertar(Perfil);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Usuario usuario, int Perfil, int idUsuarioPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.Actualizar(usuario.Id, idUsuarioPerfil, Perfil);
        }

        [HttpPut]
        [Route("Activar")]
        public string Activar(int idUsuarioPerfil, bool Activo)
        {
            clsUsuario _usuario = new clsUsuario();
            return _usuario.Activar(idUsuarioPerfil, Activo);
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        public IQueryable ListarUsuarios()
        {
            clsUsuario _usuario = new clsUsuario();
            return _usuario.ListarUsuarios();
        }
    }
}