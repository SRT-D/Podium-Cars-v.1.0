using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Core;
using System;

namespace ConsoleApp1;
//Paradigma Orientado a Aspectos
public static class GeneradorServicios
{

    private static IWindsorContainer _contenedor;

    public static void ConfigurarContenedor()
    {
        _contenedor = new WindsorContainer();


        _contenedor.Register(Component.For<LoggingInterceptor>().Named("logInterceptor"),
            Component.For<ErrorInterceptor>().Named("errorInterceptor")
        );


        _contenedor.Register(
            Component.For<IServicioAutenticacion>().ImplementedBy<ServicioAutenticacion>()
            .Interceptors(InterceptorReference.ForKey("errorInterceptor"), InterceptorReference.ForKey("logInterceptor")).Anywhere
        );
    }

    public static IServicioAutenticacion ObtenerServicioAutenticacion()
    {
        if (_contenedor == null)
            throw new Exception("El contenedor no se ha sido inicializado. Llama a ConfigurarContenedor() primero.");

        return _contenedor.Resolve<IServicioAutenticacion>();
    }
}
