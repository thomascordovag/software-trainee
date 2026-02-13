using System;
using PatronesDeDiseno.DependencyInjection;
using PatronesDeDiseno.Singleton;
using PatronesDeDiseno.Builder;
using PatronesDeDiseno.Factory;
using PatronesDeDiseno.Repository;
using PatronesDeDiseno.Strategy;
using PatronesDeDiseno.Observer;
using PatronesDeDiseno.CQRS;

namespace PatronesDeDiseno
{
    class Program
    {
        static readonly (string nombre, Action demo)[] Patrones = new (string nombre, Action demo)[]
        {
            ("Dependency Injection", DependencyInjectionDemo.Ejecutar),
            ("Singleton", SingletonDemo.Ejecutar),
            ("Builder", BuilderDemo.Ejecutar),
            ("Factory", FactoryDemo.Ejecutar),
            ("Repository", RepositoryDemo.Ejecutar),
            ("Strategy", StrategyDemo.Ejecutar),
            ("Observer", ObserverDemo.Ejecutar),
            ("CQRS", CQRSDemo.Ejecutar)
        };

        static void Main(string[] args)
        {
            while (true)
            {
                MostrarMenuPrincipal();
                var opcion = Console.ReadLine();
                Console.Clear();

                if (opcion == "0")
                {
                    Console.WriteLine("\n¡Hasta luego!\n");
                    return;
                }

                if (int.TryParse(opcion, out int index) && index >= 1 && index <= 8)
                {
                    Patrones[index - 1].demo();
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                }

                Console.WriteLine("\n" + new string('-', 50));
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("PATRONES DE DISEÑO");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("\nPATRONES CREACIONALES:");
            Console.WriteLine("  1. Dependency Injection");
            Console.WriteLine("  2. Singleton");
            Console.WriteLine("  3. Builder");
            Console.WriteLine("  4. Factory");
            Console.WriteLine("\nPATRONES ESTRUCTURALES:");
            Console.WriteLine("  5. Repository");
            Console.WriteLine("\nPATRONES COMPORTAMENTALES:");
            Console.WriteLine("  6. Strategy");
            Console.WriteLine("  7. Observer");
            Console.WriteLine("\nPATRONES ARQUITECTÓNICOS:");
            Console.WriteLine("  8. CQRS");
            Console.WriteLine("\n" + new string('-', 50));
            Console.WriteLine("  0. Salir");
            Console.WriteLine(new string('-', 50));
            Console.Write("\nSeleccione una opción: ");
        }
    }
}
