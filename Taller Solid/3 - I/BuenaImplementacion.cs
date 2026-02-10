// Buena implementación del Principio de Segregación de Interfaces (Interface Segregation Principle)
// Interfaces pequeñas y específicas

namespace TallerSolid.I.Good
{
    // Interfaces segregadas
    public interface ITrabajable
    {
        void Trabajar();
    }

    public interface IComible
    {
        void Comer();
    }

    public interface IDormible
    {
        void Dormir();
    }

    public interface IVacacionable
    {
        void TomarVacaciones();
    }

    // El trabajador humano implementa todas las interfaces que necesita
    public class TrabajadorHumano : ITrabajable, IComible, IDormible, IVacacionable
    {
        public void Trabajar() => Console.WriteLine("Trabajando...");
        public void Comer() => Console.WriteLine("Comiendo...");
        public void Dormir() => Console.WriteLine("Durmiendo...");
        public void TomarVacaciones() => Console.WriteLine("De vacaciones...");
    }

    // El robot solo implementa lo que necesita
    public class Robot : ITrabajable
    {
        public void Trabajar() => Console.WriteLine("Robot trabajando...");
    }

    // Ejemplo de uso
    public class Empresa
    {
        public void AsignarTrabajo(ITrabajable trabajador)
        {
            trabajador.Trabajar();
        }
    }
}
