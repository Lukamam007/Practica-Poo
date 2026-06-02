using System;

namespace ejercicio_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto fiat = new Auto(45);
            Bicicleta bici = new Bicicleta();
            Camion camion = new Camion();

            Console.WriteLine("--- Prueba Normal ---");
            
            bici.mover(20);
            Console.WriteLine($"Posición bici tras 20s: {bici.posicion()}m"); 
            
            bici.mover(10);
            Console.WriteLine($"Posición bici tras 10s extra: {bici.posicion()}m");


            Console.WriteLine("\n\n--- Carrera ---");
            
            Carrera granPremio = new Carrera();

            granPremio.competir(fiat, camion, 10);

            Console.WriteLine("\n");
            Auto autoEstandar = new Auto(); 
            granPremio.competir(bici, autoEstandar, 5);
        }
    }
}
