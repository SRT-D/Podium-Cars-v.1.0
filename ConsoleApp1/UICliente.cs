using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp1.Registro;

namespace ConsoleApp1;

public static class UICliente
{
    public static void MenuPrincipal()
    {
        bool volverAlInicio = false;
        do
        {
            Console.Clear();
            Console.WriteLine("--- MoDULO CLIENTE ---");
            Console.WriteLine("1. Vender un vehiculo (Proceso Venta)");
            Console.WriteLine("2. Comprar vehiculo de segunda");
            Console.WriteLine("3. Comprar vehiculo de importacion");
            Console.WriteLine("4. Volver al menu de inicio");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":

                    ProcesoVenta();
                    break;

                case "2":

                    ComprarSegunda();
                    break;

                case "3":

                    ComprarImportado();
                    break;

                case "4":
                    volverAlInicio = true;
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

            if (!volverAlInicio)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar en el menu de cliente...");
                Console.ReadKey();
            }

        } while (!volverAlInicio);
    }

    private static void ProcesoVenta()
    {
        VehiculoSegunda nuevoAuto = new VehiculoSegunda();

        Console.Write("Marca: "); nuevoAuto.Marca = Console.ReadLine();
        Console.Write("Modelo: "); nuevoAuto.Modelo = Console.ReadLine();
        Console.Write("Año: "); nuevoAuto.Año = int.Parse(Console.ReadLine());
        Console.Write("Kilometraje: "); nuevoAuto.Kilometraje = double.Parse(Console.ReadLine());
        Console.Write("Precio de venta: "); nuevoAuto.Precio = decimal.Parse(Console.ReadLine());


        if (!Registro.ValidarKilometraje(nuevoAuto.Año, nuevoAuto.Kilometraje))
        {
            Console.WriteLine("\nERROR Venta rechazada: El vehiculo supera los 10,000 km por año.");
            return;
        }


        Console.Write("Describa las modificaciones INTERNAS: ");
        nuevoAuto.Extras.Internas = Console.ReadLine();

        Console.Write("Describa las modificaciones EXTERNAS: ");
        nuevoAuto.Extras.Externas = Console.ReadLine();

        Registro.InventarioSegunda.Add(nuevoAuto);
        Console.WriteLine("\nEXITO Vehiculo registrado. Esperando aprobacion del vendedor.");
    }

    private static void ComprarSegunda()
    {
        var disponibles = Registro.InventarioSegunda.Where(vehiculoSegunda => vehiculoSegunda.EstaAprobado).ToList();
        if (!disponibles.Any()) { Console.WriteLine("No hay autos aprobados."); return; }

        for (int i = 0; i < disponibles.Count; i++)
        { Console.Write($"{i + 1}. "); disponibles[i].MostrarDetalles(); }

        Console.WriteLine("Seleccione el numero del vehiculo para comprar ( 0 para salir):");
        int seleccionUsuario = int.Parse(Console.ReadLine()) - 1;
        if (seleccionUsuario >= 0) ProcesarPago(disponibles[seleccionUsuario]);
    }

    private static void ProcesarPago(Vehiculo vehiculoSeleccionado)
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("       PROCESO DE PAGO - PODIUM CARS    ");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Efectivo (Contado)");
        Console.WriteLine("2. Credito");
        Console.Write("\nSeleccione el metodo de pago: ");
        string metodoPago = Console.ReadLine();

        if (metodoPago == "1")
        {

            Console.Clear();
            string facturaDetalle =
                "========================================\n" +
                "          FACTURA DE VENTA             \n" +
                "========================================\n" +
                $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}\n" +
                $"Vehículo: {vehiculoSeleccionado.Marca} {vehiculoSeleccionado.Modelo}\n" +
                $"Año: {vehiculoSeleccionado.Año}\n" +
                "----------------------------------------\n" +
                "Tipo de Pago: EFECTIVO (CONTADO)\n" +
                $"TOTAL PAGADO: {vehiculoSeleccionado.Precio:C}\n" +
                "========================================\n" +
                "¡Gracias por su compra en Podium Cars!\n" +
                "========================================";

            Console.WriteLine(facturaDetalle);


            Registro.Facturas.Add(facturaDetalle);
            EliminarVehiculo(vehiculoSeleccionado);
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        else if (metodoPago == "2")
        {

            Console.Clear();
            Console.WriteLine("--- SIMULADOR DE CREDITO ---");
            Console.WriteLine($"Precio del vehiculo: {vehiculoSeleccionado.Precio:C}");

            Console.Write("\nIngrese el monto de la cuota inicial: ");
            decimal cuotaInicial = decimal.Parse(Console.ReadLine());


            decimal saldoRestante = vehiculoSeleccionado.Precio - cuotaInicial;

            if (saldoRestante <= 0)
            {
                Console.WriteLine("El abono cubre el total. Por favor procese como Efectivo.");
                return;
            }

            Console.Write("¿A cuantas cuotas desea financiar el saldo? (ej: 12, 24, 36): ");
            int numeroCuotas = int.Parse(Console.ReadLine());


            decimal valorCuota = saldoRestante / numeroCuotas;

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("      RESUMEN DE FINANCIACION           ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Saldo a financiar: {saldoRestante:C}");
            Console.WriteLine($"Numero de cuotas: {numeroCuotas}");
            Console.WriteLine($"Valor de cada cuota mensual: {valorCuota:C}");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("\n¿Desea confirmar el credito? (S/N)");
            if (Console.ReadLine().ToUpper() == "S")
            {
                string facturaCredito = $"Venta Credito: {vehiculoSeleccionado.Marca} - Inicial: {cuotaInicial:C} - {numeroCuotas} cuotas de {valorCuota:C}";
                Registro.Facturas.Add(facturaCredito);
                EliminarVehiculo(vehiculoSeleccionado);
                Console.WriteLine("\n¡Credito aprobado y compra exitosa!");
            }
        }
    }

    private static void EliminarVehiculo(Vehiculo vehiculo)
    {
        if (vehiculo is VehiculoSegunda segunda) Registro.InventarioSegunda.Remove(segunda);
        else if (vehiculo is VehiculoImportacion importacion) Registro.InventarioImportados.Remove(importacion);
    }

    private static void ComprarImportado()
    {
        Console.Clear();
        Console.WriteLine("--- COMPRA DE IMPORTADOS ---");
        Console.WriteLine("1. Vehiculos disponibles en Colombia");
        Console.WriteLine("2. Vehiculos en tránsito (Llegada en 90 dias)");
        Console.WriteLine("3. Solicitar importación personalizada");
        string opcion = Console.ReadLine();

        if (opcion == "1" || opcion == "2")
        {
            bool buscarDisponibles = (opcion == "1");

            var lista = Registro.InventarioImportados.Where(vehiculoImportacion => vehiculoImportacion.DisponibleEnColombia == buscarDisponibles).ToList();

            if (!lista.Any())
            {
                Console.WriteLine("\nNo hay vehiculos en esta categoria actualmente.");
                return;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                lista[i].MostrarDetalles();
                if (!buscarDisponibles)
                    Console.WriteLine($"   ENTREGA ESTIMADA: {DateTime.Now.AddDays(90).ToShortDateString()}");
            }

            Console.WriteLine("\nSeleccione el numero para comprar (o 0 para salir):");
            if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= lista.Count)
            {
                ProcesarPago(lista[seleccion - 1]);
            }
        }
        else if (opcion == "3")
        {
            SolicitudPersonalizada solicitud = new SolicitudPersonalizada();
            Console.WriteLine("\n-- FORMULARIO DE IMPORTACION PERSONALIZADA --");
            Console.Write("Nombre completo: "); solicitud.Nombre = Console.ReadLine();
            Console.Write("Cedula: "); solicitud.Cedula = Console.ReadLine();
            Console.Write("Telefono: "); solicitud.Telefono = Console.ReadLine();
            Console.Write("Marca del vehiculo: "); solicitud.Marca = Console.ReadLine();
            Console.Write("Modelo: "); solicitud.Modelo = Console.ReadLine();
            Console.Write("Año: "); solicitud.Año = int.Parse(Console.ReadLine());

            Registro.DatosSolicitudes.Add(solicitud);
            Console.WriteLine("\nEXITO La solicitud fue recibida correctamente.");
            Console.WriteLine("El cliente sera contactado posteriormente para obtener mas informacion.");
        }
    }
}
