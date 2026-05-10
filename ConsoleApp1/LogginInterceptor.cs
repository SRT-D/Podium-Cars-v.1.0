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


