using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Obtener fecha actual
        DateTime fechaActual = DateTime.Now;

        // Obtener el primer día del mes actual
        DateTime primerDiaMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);

        // Obtener el número total de días del mes actual
        int diasEnMes = DateTime.DaysInMonth(fechaActual.Year, fechaActual.Month);

        // Obtener el nombre del mes y el año
        string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fechaActual.Month);
        Console.WriteLine($"\n    {nombreMes.ToUpper()} {fechaActual.Year}\n");

        // Encabezado de días de la semana
        Console.WriteLine("lu ma mi ju vi sá do");

        // Día de la semana del primer día del mes (lunes=1, domingo=0 en C#)
        int primerDiaSemana = (int)primerDiaMes.DayOfWeek;
        if (primerDiaSemana == 0) primerDiaSemana = 7; // Ajustar domingo a 7

        // Imprimir espacios en blanco hasta el primer día del mes
        for (int i = 1; i < primerDiaSemana; i++)
        {
            Console.Write("   ");
        }

        // Imprimir los días del mes
        for (int dia = 1; dia <= diasEnMes; dia++)
        {
            Console.Write($"{dia,2} ");

            // Verificar si se debe hacer un salto de línea (cada domingo)
            int diaActualSemana = (primerDiaSemana + dia - 1) % 7;
            if (diaActualSemana == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine(); // Salto final
    }
}
