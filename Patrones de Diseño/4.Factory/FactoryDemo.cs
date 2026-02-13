using System;

namespace PatronesDeDiseno.Factory
{
    // FACTORY - Centraliza la creación de objetos
    // Permite crear objetos sin exponer la lógica de creación al cliente y tener todos los objetos creados a través de una interfaz común
    // Para este ejemplo se crean diferentes tipos de transporte (camión, barco) sin acoplar el código a clases concretas

    public interface ITransporte // Interfaz común para todos los transportes
    {
        void Entregar();
    }

    public class Camion : ITransporte // Metodo especifico para entregar por tierra
    {
        public void Entregar() => Console.WriteLine("Entregando por tierra");
    }

    public class Barco : ITransporte // Metodo especifico para entregar por mar
    {
        public void Entregar() => Console.WriteLine("Entregando por mar");
    }

    public class TransporteFactory // Clase Factory que crea objetos de transporte segun el tipo solicitado
    {
        public static ITransporte Crear(string tipo) // Metodo para crear transporte segun el tipo solicitado
                                                     // Se centraliza la logica de creacion y evitando acoplar el codigo a clases concretas
        {
            return tipo.ToLower() switch // Se utiliza un switch para determinar que tipo de transporte crear segun el parametro "tipo"
            {
                "tierra" => new Camion(), // Si el tipo es "tierra", se crea un nuevo objeto Camion
                "mar" => new Barco(), // Si el tipo es "mar", se crea un nuevo objeto Barco
                _ => throw new ArgumentException("Tipo inválido")
            };
        }
    }

    public class FactoryDemo 
    {
        public static void Ejecutar()
        {
            Console.WriteLine("========== FACTORY ==========\n");

            var transporte1 = TransporteFactory.Crear("tierra"); // Se solicita un transporte por tierra a la fabrica, que devuelve un objeto Camion
            transporte1.Entregar(); // Se llama al metodo Entregar del objeto Camion, que imprime "Entregando por tierra"

            var transporte2 = TransporteFactory.Crear("mar"); // Se solicita un transporte por mar a la fabrica, que devuelve un objeto Barco
            transporte2.Entregar(); // Se llama al metodo Entregar del objeto Barco, que imprime "Entregando por mar"

        }
    }
}
