using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1;

public interface IServicioAutenticacion
{
    bool Login(string usuario, string contrasena);
    void Registrar(string usuario, string contrasena);
}


public class ServicioAutenticacion : IServicioAutenticacion
{
    public bool Login(string usuario, string contrasena)
    {

        if (Registro.Vendedores.Any(vendedor => vendedor.Usuario == usuario && vendedor.Contrasena == contrasena))
        {
            return true;
        }
        return false;
    }

    public void Registrar(string usuario, string contrasena)
    {
        if (Registro.Vendedores.Any(vendedor => vendedor.Usuario == usuario))
        {
            throw new Exception("El usuario ya existe en el sistema.");
        }
        Registro.Vendedores.Add(new Vendedor { Usuario = usuario, Contrasena = contrasena });
    }
}
