using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Registro
    {

        public static List<SolicitudPersonalizada> DatosSolicitudes = new List<SolicitudPersonalizada>();


        public class SolicitudPersonalizada
        {
            public string Nombre { get; set; }
            public string Cedula { get; set; }
            public string Telefono { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int Año { get; set; }
        }


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
