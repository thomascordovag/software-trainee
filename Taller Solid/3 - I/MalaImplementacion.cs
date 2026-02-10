// Mala implementación del Principio de Segregación de Interfaces (Interface Segregation Principle)
// Interfaz grande que fuerza a implementar métodos innecesarios

namespace TallerSolid.I.Bad
{
    public interface ITrabajador
    {
        void Trabajar();
        void Comer();
        void Dormir();
        void TomarVacaciones();
    }

    // Un trabajador humano puede hacer todo
    public class TrabajadorHumano : ITrabajador
    {
        public void Trabajar() => Console.WriteLine("Trabajando...");
        public void Comer() => Console.WriteLine("Comiendo...");
        public void Dormir() => Console.WriteLine("Durmiendo...");
        public void TomarVacaciones() => Console.WriteLine("De vacaciones...");
    }

    // Problema: Un robot no come, no duerme, ni toma vacaciones
    public class Robot : ITrabajador
    {
        public void Trabajar() => Console.WriteLine("Robot trabajando...");
        
        // Obligado a implementar métodos que no tiene sentido
        public void Comer() => throw new NotImplementedException();
        public void Dormir() => throw new NotImplementedException();
        public void TomarVacaciones() => throw new NotImplementedException();
    }
}
