// Mala implementación del Principio de Responsabilidad Única (Single Responsibility Principle)
// La clase Empleado tiene muchas responsabilidades como calcular salario, guardar en base de datos y generar reportes, esto no cumple con el principio de responsabilidad unica.

using System;

namespace TallerSolid.S.MI
{
    public class Empleado // Clase principal con múltiples responsabilidades
    {
        public string Nombre { get; set; } 
        public decimal Salario { get; set; }

        // Primera responsabilidad: Cálculo de salario neto 
        public decimal CalcularSalarioNeto()
        {
            return Salario * 0.85m; // Descuento de impuestos
        }

        // Ahora hay una segunda responsabilidad: Guardar en base de datos, lo cual no tiene nada que ver con el cálculo de salario 
        public void GuardarEnBaseDatos()
        {
            Console.WriteLine($"Guardando empleado {Nombre} en la base de datos");
        }

        // También hay una tercera responsabilidad: Generar reportes, lo cual tampoco tiene relación con las otras dos responsabilidades anteriores
        public void GenerarReporte()
        {
            Console.WriteLine($"=== REPORTE ===");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Salario Neto: {CalcularSalarioNeto()}");
        }
    }
}
