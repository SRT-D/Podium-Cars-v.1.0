using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;

public interface IVehiculo
{
    string Marca { get; set; }
    string Modelo { get; set; }
    decimal Precio { get; set; }
    void MostrarDetalles();
}
