using System;
using System.Collections.Generic;

namespace ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Semaforo> listaSemaforos = new List<Semaforo>();
            listaSemaforos.Add(new Semaforo("Verde"));

            Console.WriteLine("--- SIMULADOR DE SEMÁFOROS ---");

            foreach (Semaforo sem in listaSemaforos)
            {
                Console.WriteLine("\nEstado Inicial:");
                sem.mostrarColor();

                Console.WriteLine("\n-> Avanzando 20 segundos...");
                sem.pasoDelTiempo(20);
                sem.mostrarColor();

                Console.WriteLine("\n-> Activando modo intermitente...");
                sem.ponerEnIntermitente();

                sem.pasoDelTiempo(1);
                sem.mostrarColor();
                sem.pasoDelTiempo(1);
                sem.mostrarColor();
                sem.pasoDelTiempo(1);
                sem.mostrarColor();

                Console.WriteLine("\n-> Desactivando intermitencia y avanzando 2 segundos...");
                sem.sacarDeIntermitente();
                sem.pasoDelTiempo(2);
                sem.mostrarColor();
                Console.WriteLine($"\n[INFO DE SISTEMA]: El color actual registrado es {sem.ColorActual} con {sem.TiempoEnColor}s.");
 
            }
        }
    }
}
