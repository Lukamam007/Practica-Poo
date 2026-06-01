using System;
using System.Collections.Generic;

namespace ejercicio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IJugador> deportistas = new List<IJugador>();
            deportistas.Add(new Amateur());
            deportistas.Add(new Profesional());

            Console.WriteLine("--- Simulacro de Entrenamiento ---");

            foreach (IJugador jugador in deportistas)
            {
                Console.WriteLine($"\nEvaluando comportamiento de: {jugador.GetType().Name}");

                bool exitoAlCorrer = jugador.correr(25);
                
                Console.WriteLine($"¿Completó los 25 minutos?: {exitoAlCorrer}");
                Console.WriteLine($"¿El jugador terminó cansado?: {jugador.cansado()}");

                Console.WriteLine("Aplicando descanso de 10 minutos...");
                jugador.descansar(10);
                Console.WriteLine($"¿Sigue cansado post-descanso?: {jugador.cansado()}");
            }
        }
    }
}

