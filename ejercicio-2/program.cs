using System;
using System.Collections.Generic;

namespace ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cronometro> listaCronometros = new List<Cronometro>();
            
            Cronometro cronometroPrueba = new Cronometro();
            listaCronometros.Add(cronometroPrueba);

            Console.WriteLine("--- PRUEBA DE CRONÓMETRO ---");

            foreach (Cronometro cronometro in listaCronometros)
            {
                Console.WriteLine("Simulando el paso de 5000 segundos...");

                for (int i = 0; i < 5000; i++) 
                {
                    cronometro.incrementarTiempo();
                }
                cronometro.reiniciar();

                Console.WriteLine($"Confirmación mediante propiedades: {cronometro.Minutos}m {cronometro.Segundos}s");
            }
        }
    }
}
