using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;

public static class ConsultaVehiculos
{
    //Programacion funcional
    public static List<VehiculoSegunda> FiltrarSegunda(
        List<VehiculoSegunda> inventario,
        Func<VehiculoSegunda, bool> criterio) //Func<>
    {
        return inventario.Where(criterio).ToList();
    }

    //Programacion funcional select
    public static List<string> ObtenerResumenes(
        List<VehiculoSegunda> vehiculos,
        Func<VehiculoSegunda, string> selector)
    {
        return vehiculos.Select(selector).ToList();
    }


    //Programacion funcional aggregate
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
        Action<T> accion) //acction<>
    {
        foreach (var item in lista)
            accion(item);
    }
}
