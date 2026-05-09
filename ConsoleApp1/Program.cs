using Castle.DynamicProxy;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeneradorServicios.ConfigurarContenedor();


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
