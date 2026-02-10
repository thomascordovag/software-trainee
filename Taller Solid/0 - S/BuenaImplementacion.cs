// Buena implementación del Principio de Responsabilidad Única (Single Responsibility Principle)
// Cada clase tiene una única responsabilidad, la clase Empleado solo representa un empleado, la clase CalculadoraSalario solo se encarga de calcular salarios, la clase EmpleadoRepository solo se encarga de la persistencia y la clase ReporteEmpleado solo se encarga de generar reportes.
// Esto cumple con el principio de responsabilidad única, ya que cada clase tiene una única razón para cambiar.
using System;

namespace TallerSolid.S.BI
{
    // Solo una responsabilidad: Representar un empleado
    public class Empleado
    {
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
    }

    // Solo una responsabilidad: Cálculo de salario neto
    public class CalculadoraSalario
    {
        public decimal CalcularSalarioNeto(Empleado empleado) 
        {
            return empleado.Salario * 0.85m;
        }
    }

    // Solo una responsabilidad: Persistencia de empleados
    public class EmpleadoRepository
    {
        public void Guardar(Empleado empleado)
        {
            Console.WriteLine($"Guardando empleado {empleado.Nombre} en la base de datos");
        }
    }

    // Solo una responsabilidad: Generar reportes de empleados
    public class ReporteEmpleado
    {
        private readonly CalculadoraSalario _calculadora;

        public ReporteEmpleado()
        {
            _calculadora = new CalculadoraSalario();
        }

        public void Generar(Empleado empleado)
        {
            Console.WriteLine($"=== REPORTE ===");
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Salario Neto: {_calculadora.CalcularSalarioNeto(empleado)}");
        }
    }
}
