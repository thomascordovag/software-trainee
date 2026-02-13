using System;

namespace PatronesDeDiseno.DependencyInjection
{
    // DEPENDENCY INJECTION - Inyectar dependencias en lugar de crearlas dentro

    // Una interfaz es un contrato que define que debe hacer una clase, pero no como hacerlo. Es una forma de lograr abstracción y desacoplamiento en el código
    // Una interfaz define que se debe hacer (el contrato) y las clases definen como hacerlo (la implementacion)
    public interface INotificador // Abstracción que define comportamiento común para notificaciones
    {
        void Enviar(string mensaje);
    }

    public class Email : INotificador // Implementación concreta de INotificador para enviar emails
    {
        public void Enviar(string mensaje) => Console.WriteLine($"Email: {mensaje}");
    }

    public class SMS : INotificador // Implementación concreta de INotificador para enviar SMS
    {
        public void Enviar(string mensaje) => Console.WriteLine($"SMS: {mensaje}");
    }

    public class Pedido // Clase que depende de INotificador para enviar notificaciones, pero no sabe ni le importa como se implementa esa notificación
    {
        private readonly INotificador _notificador; // La dependencia se declara como una interfaz, no como una implementación concreta

        public Pedido(INotificador notificador) // La dependencia se inyecta a través del constructor, lo que permite cambiar la implementación sin modificar esta clase
        {
            _notificador = notificador;
        }

        public void Procesar() // Método que procesa el pedido y luego envía una notificación
        {
            Console.WriteLine("Pedido procesado");
            _notificador.Enviar("Tu pedido está listo");
        }
    }

    public class DependencyInjectionDemo 
    {
        public static void Ejecutar() 
        {
            Console.WriteLine("========== DEPENDENCY INJECTION ==========\n");
            
            new Pedido(new Email()).Procesar(); // Se crea un pedido que utiliza Email para notificar, pero no se sabe ni importa como se implementa esa notificación
            Console.WriteLine();
            new Pedido(new SMS()).Procesar(); // Se crea un pedido que utiliza SMS para notificar, pero no se sabe ni importa como se implementa esa notificación

        }
    }
}
