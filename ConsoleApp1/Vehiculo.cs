using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;

public abstract class Vehiculo : IVehiculo
{
    public string Marca { get; set; } = "";
    public string Modelo { get; set; } = "";
    public int Año { get; set; }
    public decimal Precio { get; set; }

    public abstract void MostrarDetalles();
}
