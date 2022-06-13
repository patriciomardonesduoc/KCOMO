using System;

namespace KcomoAPI.Models
{
    public class Usuarios
    {
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Ruta_FotoPerfil { get; set; }
        public bool Habilitado { get; set; }

        public void SetPutDTO (UsuarioPutDTO usuarioPut){

            this.IdUsuario = Guid.NewGuid();
            this.Nombre = usuarioPut.Nombre;
            this.Ruta_FotoPerfil = usuarioPut.Ruta_FotoPerfil;
            this.Habilitado = true;
        }
    }

    public class UsuarioPutDTO
    {
        public string Nombre { get; set; }
        public string Ruta_FotoPerfil { get; set; }


    }

        public class UsuarioGetDTO
    {
        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Ruta_FotoPerfil { get; set; }
    }
}