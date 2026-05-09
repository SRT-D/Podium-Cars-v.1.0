using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;

public static class UIVehiculoSegunda
{

    public static List<VehiculoSegunda> inventarioSegunda = new List<VehiculoSegunda>();

    public static void GestionarVehiculosSegunda()
    {
        bool continuar = true;

        do
        {

            Console.WriteLine("\n---VEHICULOS DE SEGUNDA---" + "\n" + "1. Registrar Vehiculo" + "\n" + "2. Listar Vehiculos" + "\n" +
                "3. Eliminar vehiculo" + "\n" + "4. Salir" + "\n");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarVehiculoSegunda();
                    break;
                case "2":
                    ListarVehiculoSegunda();
                    break;
                case "3":
                    Eliminar();
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

        } while (continuar);
    }

    private static void RegistrarVehiculoSegunda()
    {
        VehiculoSegunda vehSegunda = new VehiculoSegunda();
        Console.Write("Marca: ");
        vehSegunda.Marca = Console.ReadLine();

        Console.Write("Modelo: ");
        vehSegunda.Modelo = Console.ReadLine();

        Console.Write("Año: ");
        vehSegunda.Año = int.Parse(Console.ReadLine());

        Console.Write("Kilometraje: ");
        vehSegunda.Kilometraje = double.Parse(Console.ReadLine());

        Console.Write("¿Tiene modificaciones internas? (s/n): ");
        string respuestaInt = Console.ReadLine().ToLower();

        if (respuestaInt == "s")
        {
            Console.Write("Describa las modificaciones internas: ");

            vehSegunda.Extras.Internas = Console.ReadLine();
        }
        else
        {
            vehSegunda.Extras.Internas = "Ninguna";
        }


        Console.Write("¿Tiene modificaciones externas? (s/n): ");
        string respuestaExt = Console.ReadLine().ToLower();

        if (respuestaExt == "s")
        {
            Console.Write("Describa las modificaciones externas: ");

            vehSegunda.Extras.Externas = Console.ReadLine();
        }
        else
        {
            vehSegunda.Extras.Externas = "Ninguna";
        }
    }

    private static void ListarVehiculoSegunda()
    {

        if (inventarioSegunda.Count == 0)
        {
            Console.WriteLine("\n El inventario de vehiculos de segunda esta vacio.");
        }
        else
        {
            Console.WriteLine("\n---INVENTARIO---");

            int numero = 1;
            for (int i = 0; i < inventarioSegunda.Count; i++)
            {

                Console.WriteLine("Vehiculo #" + numero + ": ");

                inventarioSegunda[i].MostrarDetalles();

                numero++;
            }
        }
    }

    private static void Eliminar()
    {
        Console.Write("Ingrese Modelo a eliminar: ");
        string modeloEliminar = Console.ReadLine();

        for (int i = 0; i < inventarioSegunda.Count; i++)
        {

            if (inventarioSegunda[i].Modelo.ToLower() == modeloEliminar.ToLower())
            {
                inventarioSegunda.RemoveAt(i);
                Console.WriteLine("Vehiculo eliminado correctamente.\n");
                return;
            }
        }


        Console.WriteLine("Vehiculo no encontrado.");
    }
}
