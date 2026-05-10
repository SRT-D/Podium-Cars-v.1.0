using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp1.Program;

namespace ConsoleApp1;

public static class UIVendedor
{
    private static bool SesionIniciada = false;

    public static void MenuPrincipal()
    {
        bool volverAlInicio = false;

        while (!volverAlInicio)
        {
            Console.Clear();
            Console.WriteLine("||--- MODULO ADMINISTRATIVO VENDEDOR ---||");

            if (!SesionIniciada)
            {
                Console.WriteLine("1. Iniciar Sesion");
                Console.WriteLine("2. Registrar nuevo vendedor");
                Console.WriteLine("3. Volver al menú principal");

                string op = Console.ReadLine();

                switch (op)
                {
                    case "1": Login(); break;
                    case "2": Registrar(); break;
                    case "3": volverAlInicio = true; break;
                    default: Console.WriteLine("Opcion inválida."); break;
                }
            }
            else
            {

                volverAlInicio = PanelControl();
            }

            if (!volverAlInicio)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
    //Programacion orientada a aspectos
    private static IServicioAutenticacion _authService = GeneradorServicios.ObtenerServicioAutenticacion();

    private static void Login()
    {
        Console.Write("Usuario: "); string usuario = Console.ReadLine();
        Console.Write("Contraseña: "); string contrasena = Console.ReadLine();


        if (_authService.Login(usuario, contrasena))
        {
            SesionIniciada = true;
            Console.WriteLine("Acceso concedido.");
        }
        else
        {
            Console.WriteLine("Credenciales incorrectas.");
        }
    }



    private static void Registrar()
    {
        Console.Write("Nuevo Usuario: "); string usuario = Console.ReadLine();
        Console.Write("Nueva Contraseña: "); string contrasena = Console.ReadLine();


        _authService.Registrar(usuario, contrasena);
    }

    private static bool PanelControl()
    {
        Console.Clear();
        Console.WriteLine("--- PANEL DE CONTROL ---");
        Console.WriteLine("1. Gestionar Vehiculos de Segunda (Pendientes)");
        Console.WriteLine("2. Historial de Ventas y Facturas");
        Console.WriteLine("3. Administrar Vehiculos Importados");
        Console.WriteLine("4. Cerrar Sesion");


        string op = Console.ReadLine();

        switch (op)
        {
            case "1":
                GestionarPendientes();
                return false;
            case "2":
                VerHistorialVentas();
                return false;
            case "3":
                AdministrarImportados();
                return false;
            
            case "4":
                SesionIniciada = false;
                return false;
            
            default:
                return false;
        }
    }

    private static void GestionarPendientes()
    {

        var pendientes = Registro.InventarioSegunda.Where(vehiculoPendiente => !vehiculoPendiente.EstaAprobado).ToList();

        if (pendientes.Count == 0)
        {
            Console.WriteLine("\nNo hay vehiculos pendientes de aprobacion.");
            return;
        }


        for (int i = 0; i < pendientes.Count; i++)
        {
            Console.Clear();
            Console.WriteLine($"Gestionando vehiculo {i + 1} de {pendientes.Count}:");
            pendientes[i].MostrarDetalles();

            Console.WriteLine("\n¿Desea aprobar este vehiculo para la venta? (s/n)");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta == "s")
            {
                pendientes[i].EstaAprobado = true;
                Console.WriteLine("Vehiculo aprobado y movido al catalogo de clientes.");

                //Utilizacion evento #1
                GestorNegocio.Instancia.NotificarVehiculoAprobado(
                    pendientes[i].Marca,
                    pendientes[i].Modelo,
                    pendientes[i].Año,
                    pendientes[i].Precio
                );
            }
            else
            {
                Registro.InventarioSegunda.Remove(pendientes[i]);
                Console.WriteLine("Vehiculo desaprobado y eliminado del sistema.");
            }

            Console.WriteLine("\nPresione una tecla para ver el siguiente...");
            Console.ReadKey();
        }
    }

    private static void VerHistorialVentas()
    {
        Console.Clear();
        Console.WriteLine("--- HISTORIAL DE VENTAS ---");
        Console.WriteLine("1. Ver facturas registradas");
        Console.WriteLine("2. Reporte del inventario de segunda");
        string opcion = Console.ReadLine();

        if (opcion == "1")
        {

            if (Registro.Facturas.Count == 0)
            {
                Console.WriteLine("No se han generado ventas todavía.");
                return;
            }

            Action<string> mostrarFactura = factura =>
            {
                Console.WriteLine(factura);
                Console.WriteLine("---------------------------------------");
            };

            ConsultaVehiculos.EjecutarSobreCada(Registro.Facturas, mostrarFactura);
        }
        else if (opcion == "2")
        {

            var aprobados = ConsultaVehiculos.FiltrarSegunda(
                Registro.InventarioSegunda,
                vehiculo => vehiculo.EstaAprobado
            );


            var resumenes = ConsultaVehiculos.ObtenerResumenes(
                aprobados,
                vehiculo => $"{vehiculo.Marca} {vehiculo.Modelo} ({vehiculo.Año}) - {vehiculo.Precio:C} - KM: {vehiculo.Kilometraje}"
            );


            decimal totalInventario = ConsultaVehiculos.CalcularValorTotal(aprobados);

            Console.WriteLine($"\n--- VEHICULOS APROBADOS EN CATALOGO: {aprobados.Count} ---");


            ConsultaVehiculos.EjecutarSobreCada(resumenes, resumen => Console.WriteLine("  • " + resumen));

            Console.WriteLine($"\n  VALOR TOTAL DEL INVENTARIO: {totalInventario:C}");
        }
    }

    private static void AdministrarImportados()
    {
        Console.Clear();
        Console.WriteLine("--- GESTION DE IMPORTADOS ---");
        Console.WriteLine("1. Crear vehiculo importado YA DISPONIBLE");
        Console.WriteLine("2. Crear vehiculo importado EN TRÁNSITO");
        string opcion = Console.ReadLine();

        if (opcion == "1" || opcion == "2")
        {
            VehiculoImportacion nuevo = new VehiculoImportacion();
            Console.Write("Marca: "); nuevo.Marca = Console.ReadLine();
            Console.Write("Modelo: "); nuevo.Modelo = Console.ReadLine();
            Console.Write("Año: "); nuevo.Año = int.Parse(Console.ReadLine());
            Console.Write("Precio: "); nuevo.Precio = decimal.Parse(Console.ReadLine());

            if (opcion == "1")
            {
                nuevo.DisponibleEnColombia = true;
                nuevo.FechaActual = DateTime.Now;
            }
            else
            {
                nuevo.DisponibleEnColombia = false;
                nuevo.FechaActual = DateTime.Now.AddDays(90);
            }

            Registro.InventarioImportados.Add(nuevo);
            Console.WriteLine("\nEXITO Vehiculo importado registrado en el catalogo.");
        }
    }
}
