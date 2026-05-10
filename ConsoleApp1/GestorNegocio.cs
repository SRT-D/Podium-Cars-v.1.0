using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;

//Publicador eventos
public class GestorNegocio
{

    public static readonly GestorNegocio Instancia = new GestorNegocio();


    public event EventHandler<VehiculoAprobadoEventArgs> VehiculoAprobado;
    public event EventHandler<VentaRealizadaEventArgs> VentaRealizada;


    public void NotificarVehiculoAprobado(string marca, string modelo, int año, decimal precio)
    {
        VehiculoAprobado?.Invoke(this, new VehiculoAprobadoEventArgs(marca, modelo, año, precio));
    }


    public void NotificarVentaRealizada(string marca, string modelo, decimal precio, string metodoPago)
    {
        VentaRealizada?.Invoke(this, new VentaRealizadaEventArgs(marca, modelo, precio, metodoPago));
    }
}
