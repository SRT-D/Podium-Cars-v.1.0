using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;

public static class ConsultaVehiculos
{

    public static List<VehiculoSegunda> FiltrarSegunda(
        List<VehiculoSegunda> inventario,
        Func<VehiculoSegunda, bool> criterio)
    {
        return inventario.Where(criterio).ToList();
    }


    public static List<string> ObtenerResumenes(
        List<VehiculoSegunda> vehiculos,
        Func<VehiculoSegunda, string> selector)
    {
        return vehiculos.Select(selector).ToList();
    }



    public static decimal CalcularValorTotal(List<VehiculoSegunda> vehiculos)
    {
        if (!vehiculos.Any()) return 0m;

        return vehiculos.Aggregate(
            0m,
            (acumulado, vehiculo) => acumulado + vehiculo.Precio
        );
    }


    public static void EjecutarSobreCada<T>(
        List<T> lista,
        Action<T> accion)
    {
        foreach (var item in lista)
            accion(item);
    }
}
