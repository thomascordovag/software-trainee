// Mala implementación del Principio Abierto/Cerrado (Open/Closed Principle)
// Hay que modificar la clase cada vez que se agrega un nuevo tipo, esta todo en una sola clase, no se pueden agregar nuevos tipos sin modificar el codigo que ya existe.


namespace TallerSolid.O.MI
{
    public enum TipoEmpleado
    {
        Permanente,
        Temporal,
        Contratista
    }

    public class CalculadoraBono
    {
        public decimal CalcularBono(decimal salario, TipoEmpleado tipo)
        {
            // Problema: Si agregamos un nuevo tipo, tenemos que modificar esta clase
            switch (tipo)
            {
                case TipoEmpleado.Permanente: //
                    return salario * 0.20m;
                case TipoEmpleado.Temporal:
                    return salario * 0.10m;
                case TipoEmpleado.Contratista:
                    return salario * 0.05m;
                default:
                    return 0;
            }
        }
    }
}
