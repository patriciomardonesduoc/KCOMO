using System;

namespace KcomoAPI.Models
{
    public class Publicaciones
    {
        public Guid IdPublicacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta_Imagen { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public bool Mostrar { get; set; }
        public Guid IdVendedor { get; set; }
        public bool Habilitado { get; set; }

        public void SetPublicacionByDTO(PublicacionesDTO pdto){
            IdPublicacion = Guid.NewGuid();
            Nombre = pdto.Nombre;
            Descripcion = pdto.Descripcion;
            Ruta_Imagen = pdto.Ruta_Imagen;
            Precio = pdto.Precio;
            Stock = pdto.Stock;
            Mostrar = pdto.Mostrar;
            IdVendedor = pdto.IdVendedor;
            Habilitado = true;
        }



    }

        public class PublicacionesDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta_Imagen { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public bool Mostrar { get; set; }
        public Guid IdVendedor { get; set; }
    }
}