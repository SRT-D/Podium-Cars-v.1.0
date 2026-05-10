using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;
//Programacion Orientada a evento, evento #1
public class VehiculoAprobadoEventArgs : EventArgs
{

    public string Marca { get; }
    public string Modelo { get; }
    public int Año { get; }
    public decimal Precio { get; }
    public DateTime FechaAprobacion { get; }

    public VehiculoAprobadoEventArgs(string marca, string modelo, int año, decimal precio)
    {
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
        FechaAprobacion = DateTime.Now;
    }
}

//Programacion Orientada a evento, evento #2
public class VentaRealizadaEventArgs : EventArgs
{
    public string Marca { get; }
    public string Modelo { get; }
    public decimal PrecioFinal { get; }
    public string MetodoPago { get; }
    public DateTime FechaVenta { get; }

    public VentaRealizadaEventArgs(string marca, string modelo, decimal precioFinal, string metodoPago)
    {
        Marca = marca;
        Modelo = modelo;
        PrecioFinal = precioFinal;
        MetodoPago = metodoPago;
        FechaVenta = DateTime.Now;
    }
}


