using Castle.DynamicProxy;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeneradorServicios.ConfigurarContenedor();

            //Suscriptor
            GestorNegocio.Instancia.VehiculoAprobado += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[EVENTO] Vehículo aprobado para venta: {e.Marca} {e.Modelo} ({e.Año}) - {e.Precio:C}");
                Console.WriteLine($"[EVENTO] Aprobado el: {e.FechaAprobacion:dd/MM/yyyy HH:mm}");
                Console.ResetColor();
            };
            //Suscriptor
            GestorNegocio.Instancia.VentaRealizada += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n[EVENTO] Venta completada: {e.Marca} {e.Modelo}");
                Console.WriteLine($"[EVENTO] Método: {e.MetodoPago} | Total: {e.PrecioFinal:C} | Fecha: {e.FechaVenta:dd/MM/yyyy HH:mm}");
                Console.ResetColor();
            };

            IServicioAutenticacion authService = GeneradorServicios.ObtenerServicioAutenticacion();
            bool ejecutar = true;
            while (ejecutar)
            {
                Console.Clear();
                Console.WriteLine("||------ PODIUM CARS 2026 ------||");
                Console.WriteLine("Ingrese como:\n1. Cliente\n2. Vendedor\n3. Salir");
                string perfil = Console.ReadLine();

                switch (perfil)
                {
                    case "1": UICliente.MenuPrincipal(); break;
                    case "2": UIVendedor.MenuPrincipal(); break;
                    case "3": ejecutar = false; break;
                    default: Console.WriteLine("Opcion invalida."); break;
                }

                if (ejecutar)
                {
                    Console.WriteLine("\nPresione una tecla para continuar..."); Console.ReadKey();
                }
            }
        }
    }
        
}


