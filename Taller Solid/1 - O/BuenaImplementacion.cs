// Buena implementación del Principio Abierto/Cerrado (Open/Closed Principle)
// El sistema está abierto a extensión pero cerrado a modificación
// Se puede agregar un nuevo tipo sin modificar el código existente, solo creando una nueva clase que implemente la interfaz IEmpleado

namespace TallerSolid.O.BI
{
    // Abstracción
    public interface IEmpleado
    {
        decimal CalcularBono(decimal salario);
    }

    public class EmpleadoPermanente : IEmpleado // Primera clase concreta
    {
        public decimal CalcularBono(decimal salario)
        {
            return salario * 0.20m;
        }
    }

    public class EmpleadoTemporal : IEmpleado // Segunda clase concreta, sin modificar código existente 
    {
        public decimal CalcularBono(decimal salario)
        {
            return salario * 0.10m;
        }
    }

    public class EmpleadoContratista : IEmpleado // Tercera clase concreta
    {
        public decimal CalcularBono(decimal salario)
        {
            return salario * 0.05m;
        }
    }

    // Nuevo tipo sin modificar código existente
    public class EmpleadoPasante : IEmpleado // Cuarta clase concreta, agregada sin modificar nada de las anteriores siguiendo el principio abierto/cerrado
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
