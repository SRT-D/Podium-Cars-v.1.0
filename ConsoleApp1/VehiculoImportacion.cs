using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1;

public class VehiculoImportacion : Vehiculo
{

    public DateTime FechaActual { get; set; }
    public bool DisponibleEnColombia { get; set; }

    public override void MostrarDetalles()
    {
        string estado = DisponibleEnColombia ? "En Vitrina" : $"Llegada estimada: {FechaActual.ToShortDateString()}";
        Console.WriteLine($"IMPORTADO: {Marca} {Modelo} ({Año}) - {Precio:C} - [{estado}]");
    }
}
