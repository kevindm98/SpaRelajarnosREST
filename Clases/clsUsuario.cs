using Microsoft.Ajax.Utilities;
using SpaRelajarnosREST.Clases;
using SpaRelajarnosREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaRelajarnosREST.Clases
{
    public class clsUsuario
    {
        private SpaRelajarnosEntities db = new SpaRelajarnosEntities();
        public Usuario usuario { get; set; }
        public string Insertar(int idPerfil)
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                cifrar.Password = usuario.Clave;
                if (cifrar.CifrarClave())
                {
                    //Graba el usuario
                    //Se lee la clave cifrada y el salt en el objeto usuario
                    usuario.Clave = cifrar.PasswordCifrado;
                    usuario.Salt = cifrar.Salt;
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();

                    //Grabar en la tabla Usuario_Perfil
                    Usuario_Perfil UsuarioPerfil = new Usuario_Perfil();
                    UsuarioPerfil.IdPerfil = idPerfil;
                    UsuarioPerfil.IdUsuario = usuario.Id;
                    UsuarioPerfil.Activo = true;
                    db.Usuario_Perfil.Add(UsuarioPerfil);
                    db.SaveChanges();

                    //Retorna la respuesta
                    return "Se creó el usuario: " + usuario.UserName;
                }
                else
                {
                    return "No pudo generar la clave cifrada, no se creó el usuario";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar(int idUsuario, int idUsuarioPerfil, int idPerfil)
        {
            try
            {
                Usuario _usuario = db.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
                _usuario.UserName = usuario.UserName;
                db.SaveChanges();

                Usuario_Perfil usuario_Perfil = db.Usuario_Perfil.FirstOrDefault(up => up.Id == idUsuarioPerfil);
                usuario_Perfil.Perfil.Id = idPerfil;
                db.SaveChanges();
                return "Se actualizaron los datos del usuario: " + usuario.UserName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Activar(int idUsuarioPerfil, bool Activo)
        {
            try
            {
                Usuario_Perfil usuario_Perfil = db.Usuario_Perfil.FirstOrDefault(u => u.Id == idUsuarioPerfil);
                if (usuario_Perfil == null)
                {
                    return "El usuario no existe en la base de datos";
                }
                usuario_Perfil.Activo = Activo;
                db.SaveChanges();
                return "Se activó el usuario";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable ListarUsuarios()
        {
            return from P in db.Set<Perfil>()
                   join UP in db.Set<Usuario_Perfil>()
                   on P.Id equals UP.IdPerfil
                   join U in db.Set<Usuario>()
                   on UP.IdUsuario equals U.Id
                   join E in db.Set<Empleado>()
                   on U.Empleado.Id equals E.Id
                   join C in db.Set<Cargo>()
                   on E.Cargo.Id equals C.Id
                   orderby U.UserName
                   select new
                   {
                       Editar = "<img src=\"../Imagenes/Editar.png\"  style=\"cursor:grab;\" onclick=\"Editar('" + U.Id + "', '" + E.Id + "', '" +
                                 E.Documento + "', '" + E.Nombre + " " + E.Apellido + "', '" + C.Nombre + 
                                 "', '" + U.UserName + "', '" + P.Id + "', '" + UP.Id + "')\" />"
                                 + "&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"../Imagenes/Activar.png\" onclick=\"Activar('" + UP.Id + "', " +
                                 ((bool)UP.Activo ? "false" : "true") + ", '" + U.UserName + "')\"/>",
                       IdEmpleado = E.Id,
                       Documento = E.Documento,
                       Empleado = E.Nombre + " " + E.Apellido,
                       Cargo = C.Nombre,
                       Usuario = U.UserName,
                       Perfil = P.Nombre,
                       Activo = (bool)UP.Activo ? "SI" : "NO"
                   };
        }
    }
}