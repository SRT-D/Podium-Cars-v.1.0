using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;



public class VehiculoSegunda : Vehiculo
{
    public double Kilometraje { get; set; }

    public Modificacion Extras { get; set; } = new Modificacion();

    public bool EstaAprobado { get; set; } = false;

    public override void MostrarDetalles()
    {
        Console.WriteLine($"--- {Marca} {Modelo} ({Año}) ---");
        Console.WriteLine($"Precio: {Precio:C} | KM: {Kilometraje}");
        Console.WriteLine($"Mods Internas: {Extras.Internas}");
        Console.WriteLine($"Mods Externas: {Extras.Externas}");
        Console.WriteLine("---------------------------");
    }
}
