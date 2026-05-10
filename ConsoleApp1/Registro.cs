using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{ //Programacion funcional Record
    public static class Registro
    {

        public static List<SolicitudPersonalizada> DatosSolicitudes = new List<SolicitudPersonalizada>();


        public record SolicitudPersonalizada(
            string Nombre,
            string Cedula,
            string Telefono,
            string Marca,
            string Modelo,
            int Año
         );


        public static List<VehiculoSegunda> InventarioSegunda = new List<VehiculoSegunda>();
        public static List<VehiculoImportacion> InventarioImportados = new List<VehiculoImportacion>();
        public static List<Vendedor> Vendedores = new List<Vendedor>();
        public static List<string> Facturas = new List<string>();
        public static List<string> SolicitudesPersonalizadas = new List<string>();


        public static bool ValidarKilometraje(int año, double km)
        {
            int añoActual = 2026;
            int antiguedad = añoActual - año;
            if (antiguedad < 1) antiguedad = 1;

            double limite = antiguedad * 10000;
            return km <= limite;
        }
    }

    public class Vendedor
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
