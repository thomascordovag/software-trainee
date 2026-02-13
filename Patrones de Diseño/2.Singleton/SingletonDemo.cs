using System;

namespace PatronesDeDiseno.Singleton
{
    // SINGLETON - Solo UNA instancia en toda la aplicación

    // Definicion de instancia: una instancia es un objeto creado a partir de una clase. 
    // En el patrón Singleton, se asegura que solo exista una instancia de la clase en toda la aplicación, y se proporciona un punto de acceso global a esa instancia

    public class Configuracion // Esta clase representa la configuración de la aplicación y se implementa como un Singleton
    {
        private static Configuracion _instancia; // Campo privado que almacena la única instancia de la clase Configuracion
                                                 // Siempre debe ser privado para evitar que se creen instancias desde fuera de la clase
        private static readonly object _lock = new object(); 

        public string Version { get; } = "1.0.0"; 

        private Configuracion() // Constructor privado para evitar que se creen instancias desde fuera de la clase
        {
            Console.WriteLine("Configuración inicializada");
        }

        public static Configuracion Instancia // Propiedad pública que proporciona acceso a la única instancia de la clase Configuracion
        {
            get
            {
                if (_instancia == null) // Se verifica si la instancia ya ha sido creada. Si no es así, se crea una nueva instancia
                {
                    lock (_lock)
                    {
                        if (_instancia == null)
                            _instancia = new Configuracion(); // Se crea la instancia de Configuracion solo si no ha sido creada previamente, lo que garantiza que solo exista una instancia en toda la aplicación
                    }
                }
                return _instancia;

                // Lo que se hizo fue implementar el patrón de doble verificación para asegurar que la instancia se cree de manera segura
            }
        }
    }

    public class SingletonDemo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("========== SINGLETON ==========\n");

            var config1 = Configuracion.Instancia; // Se accede a la instancia del Singleton a través de la propiedad Instancia.
            var config2 = Configuracion.Instancia; // Se accede nuevamente a la instancia del Singleton, pero no se crea una nueva instancia, sino que se devuelve la misma instancia creada anteriormente.
            var config3 = Configuracion.Instancia; 

            Console.WriteLine($"\nSon la misma instancia? {config1 == config2 && config2 == config3}"); // Se verifica que config1, config2 y config3 son la misma instancia, lo que confirma que el patrón Singleton se ha implementado correctamente.
            Console.WriteLine("\nSolo se creó una vez, todas apuntan a la misma instancia");
        }
    }
}
