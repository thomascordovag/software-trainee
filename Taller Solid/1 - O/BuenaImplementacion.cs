// Buena implementación del Principio Abierto/Cerrado (Open/Closed Principle)
// El sistema está abierto a extensión pero cerrado a modificación

namespace TallerSolid.O.Good
{
    // Abstracción
    public interface IEmpleado
    {
        decimal CalcularBono(decimal salario);
    }

    public class EmpleadoPermanente : IEmpleado
    {
        public decimal CalcularBono(decimal salario)
        {
            return salario * 0.20m;
        }
    }

    public class EmpleadoTemporal : IEmpleado
    {
        public decimal CalcularBono(decimal salario)
        {
            return salario * 0.10m;
        }
    }

    public class EmpleadoContratista : IEmpleado
    {
        public decimal CalcularBono(decimal salario)
        {
            return salario * 0.05m;
        }
    }

    // Nuevo tipo sin modificar código existente
    public class EmpleadoPasante : IEmpleado
    {
        public decimal CalcularBono(decimal salario)
        {
            return salario * 0.03m;
        }
    }

    public class CalculadoraBono
    {
        public decimal Calcular(decimal salario, IEmpleado empleado)
        {
            return empleado.CalcularBono(salario);
        }
    }
}
