// Mala implementación del Principio de Inversión de Dependencias (Dependency Inversion Principle)
// Las clases de alto nivel dependen de clases de bajo nivel

using System;

namespace TallerSolid.D.MI
{
    // Clase de bajo nivel
    public class BaseDatosMySQL
    {
        public void Guardar(string datos)
        {
            Console.WriteLine($"Guardando en MySQL: {datos}");
        }
    }

    // Problema: Clase de alto nivel depende directamente de una implementación concreta
    public class UsuarioService
    {
        private readonly BaseDatosMySQL _baseDatos;

        public UsuarioService()
        {
            _baseDatos = new BaseDatosMySQL(); // Acoplamiento fuerte
        }

        public void CrearUsuario(string nombre)
        {
            _baseDatos.Guardar(nombre);
        }
    }

    // Si queremos cambiar a PostgreSQL, tenemos que modificar UsuarioService
}
