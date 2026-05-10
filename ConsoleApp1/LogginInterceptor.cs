using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;
//programacion orientada a aspectos
public class LoggingInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.WriteLine($"\n[LOG] Intentando ejecutar: {invocation.Method.Name}");
        invocation.Proceed();
        Console.WriteLine($"[LOG] Finalizado: {invocation.Method.Name} con éxito.");
    }
}

//programacion orientada a aspectos
public class ErrorInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        try
        {

            foreach (var arg in invocation.Arguments)
            {
                if (arg is string s && string.IsNullOrWhiteSpace(s))
                {
                    Console.WriteLine("[ERROR] Los campos no pueden estar vacios.");
                    return;
                }
            }

            invocation.Proceed();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[MANEJO DE ERRORES] Se detecto un problema: {ex.Message}");
        }
    }
}
