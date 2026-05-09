using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;

public static class UIVehiculoImportacion
{
    public static List<VehiculoImportacion> listaImportados = new List<VehiculoImportacion>();

    public static void GestionarVehiculosImportacion()
    {
        bool continuar = true;
        do
        {
            Console.WriteLine("\n---VEHICULOS DE IMPORTACION---" + "\n" + "1. Ingrese Vehiculo a Importar" + "\n" + "2. Listar Importaciones" +
                "\n" + "3. Salir" + "\n");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                var vehImportacion = new VehiculoImportacion();
                Console.Write("Marca: ");
                vehImportacion.Marca = Console.ReadLine();

                Console.Write("Modelo: ");
                vehImportacion.Modelo = Console.ReadLine();

                vehImportacion.FechaActual = DateTime.Now.AddDays(20);

                listaImportados.Add(vehImportacion);


                Console.WriteLine("\nImportacion programada:");
                vehImportacion.MostrarDetalles();


            }
            else if (opcion == "2")
            {
                if (listaImportados.Count == 0)
                {
                    Console.WriteLine("No hay importaciones registradas.");
                }
                else
                {
                    for (int i = 0; i < listaImportados.Count; i++)
                    {
                        listaImportados[i].MostrarDetalles();
                    }
                }

            }
            else if (opcion == "3")
            {
                continuar = false;
            }
            else
            {
                Console.WriteLine("Opcion no valida.");

            }

        } while (continuar);
    }
}
