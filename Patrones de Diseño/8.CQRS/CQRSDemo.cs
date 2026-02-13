using System;
using System.Collections.Generic;
using System.Linq;

namespace PatronesDeDiseno.CQRS
{
    // CQRS - Separa operaciones de lectura (Query) y escritura (Command)
    // Commands: Operaciones que modifican el estado (crear, actualizar, eliminar) 
    // Queries: Operaciones que leen el estado sin modificarlo (obtener datos)

    public class Usuario // Modelo de dominio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }

    public class CrearUsuarioCommand // Command para crear un usuario 
    {
        public string Nombre { get; set; }
    }

    //Proposito: Procesa comandos de escritura - Responsabilidad: Crear, actualizar, eliminar datos - Retorna: void o un resultado de confirmacion
    public class CommandHandler // Maneja comandos de escritura
                                // En un escenario real, este handler podría interactuar con una base de datos o servicios externos
    {
        private List<Usuario> _bd = new List<Usuario>(); // Simula una base de datos en memoria
        private int _id = 1;

        public void Crear(CrearUsuarioCommand cmd) // Maneja el comando de creación de usuario
        {
            var usuario = new Usuario { Id = _id++, Nombre = cmd.Nombre, Activo = true }; // Crea un nuevo usuario
            _bd.Add(usuario); // Agrega el usuario a la "base de datos" simulada
            Console.WriteLine($"Usuario '{usuario.Nombre}' creado con ID {usuario.Id}");
        }

        public List<Usuario> GetBD() => _bd; // Permite acceder a la "base de datos" para las consultas
    }

    public class ObtenerUsuariosQuery { } // Query para obtener usuarios activos

    // Proposito: Procesa consultas de lectura - Responsabilidad: Obtener datos sin modificar el estado - Retorna: Datos solicitados como listas u objetos
    public class QueryHandler // Maneja consultas de lectura
                              // En un escenario real, este handler podría interactuar con una base de datos o servicios externos para obtener datos
    {
        private List<Usuario> _bd; // Recibe la "base de datos" simulada desde el CommandHandler para realizar consultas

        public QueryHandler(List<Usuario> bd) => _bd = bd; // Constructor que recibe la "base de datos" para realizar consultas

        public List<Usuario> Obtener(ObtenerUsuariosQuery query) // Maneja la consulta para obtener usuarios activos
        {
            return _bd.Where(u => u.Activo).ToList(); // Retorna solo los usuarios activos de la "base de datos" simulada
        }
    }

    public class CQRSDemo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("========== CQRS ==========\n");

            var commandHandler = new CommandHandler(); // Instancia del CommandHandler para manejar comandos de escritura
            var queryHandler = new QueryHandler(commandHandler.GetBD()); // Instancia del QueryHandler que recibe la "base de datos" del CommandHandler
                                                                         // para manejar consultas de lectura

            Console.WriteLine("COMMANDS:");
            commandHandler.Crear(new CrearUsuarioCommand { Nombre = "Juan" }); // Crea un usuario llamado "Juan"
            commandHandler.Crear(new CrearUsuarioCommand { Nombre = "María" });

            // QUERIES (lectura)
            Console.WriteLine("\nQUERIES:");
            var usuarios = queryHandler.Obtener(new ObtenerUsuariosQuery()); // Obtiene la lista de usuarios activos
            foreach (var u in usuarios) // Imprime los usuarios activos obtenidos de la consulta
                Console.WriteLine($"   [{u.Id}] {u.Nombre}");

        }
    }
}
