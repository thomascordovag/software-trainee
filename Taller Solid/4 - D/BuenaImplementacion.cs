// Buena implementación del Principio de Inversión de Dependencias (Dependency Inversion Principle)
// Ambos niveles dependen de abstracciones
// Se crea una clase general para guardar en base de datos, y las implementaciones concretas dependen de esa abstracción

using System;

namespace TallerSolid.D.BI
{
    // Abstracción
    public interface IBaseDatos
    {
        void Guardar(string datos); // Este método define la operación común que es guardar, pero no especifica cómo se realiza esa operación.
    }

    // Implementaciones de bajo nivel dependen de la abstracción
    public class BaseDatosMySQL : IBaseDatos // Este metodo implementa la operación de guardar en una base de datos MySQL tomando IBaseDatos como base.
    {
        public void Guardar(string datos)
        {
            Console.WriteLine($"Guardando en MySQL: {datos}");
        }
    }

    public class BaseDatosPostgreSQL : IBaseDatos // Este metodo implementa la operación de guardar en una base de datos PostgreSQL tomando IBaseDatos como base.
    {
        public void Guardar(string datos)
        {
            Console.WriteLine($"Guardando en PostgreSQL: {datos}");
        }
    }

    // Clase de alto nivel depende de la abstracción, no de la implementación
    public class UsuarioService
    {
        private readonly IBaseDatos _baseDatos;

        // Inyección de dependencias
        public UsuarioService(IBaseDatos baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public void CrearUsuario(string nombre)
        {
            _baseDatos.Guardar(nombre);
        }
    }

    // Ejemplo de uso
    public class Program
    {
        public static void Main()
        {
            // Podemos cambiar la implementación fácilmente
            IBaseDatos db1 = new BaseDatosMySQL();
            var service1 = new UsuarioService(db1);
            service1.CrearUsuario("Juan");

            IBaseDatos db2 = new BaseDatosPostgreSQL();
            var service2 = new UsuarioService(db2);
            service2.CrearUsuario("María");
        }
    }
}
