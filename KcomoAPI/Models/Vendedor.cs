using System;

namespace KcomoAPI.Models
{
    public class Vendedores
    {
        public Guid IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Ruta_FotoPortada { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public bool Habilitado { get; set; }


        public void SetVendedoresByDTO (VendedoresDTO v){
            IdVendedor = Guid.NewGuid();
            Nombre = v.Nombre;
            Descripcion = v.Descripcion;
            Direccion = v.Direccion;
            Latitud = v.Latitud;
            Longitud = v.Longitud;
            Ruta_FotoPortada = v.Ruta_FotoPortada;
            Mail = v.Mail;
            Telefono = v.Telefono;
            Habilitado = true;

        }
    }


        public class VendedoresDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Ruta_FotoPortada { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }


    }
}