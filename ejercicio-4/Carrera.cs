using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_4
{
    public class Carrera
    {
        public void competir(IVehiculo vehiculo1, IVehiculo vehiculo2, int segundos)
        {
            vehiculo1.reiniciarPosicion();
            vehiculo2.reiniciarPosicion();

            vehiculo1.mover(segundos);
            vehiculo2.mover(segundos);

            int pos1 = vehiculo1.posicion();
            int pos2 = vehiculo2.posicion();

            string nombreV1 = vehiculo1.GetType().Name;
            string nombreV2 = vehiculo2.GetType().Name;

            Console.WriteLine($"--- RESULTADOS DE LA CARRERA ({segundos} segundos) ---");
            Console.WriteLine($"- {nombreV1} llegó a los {pos1} metros.");
            Console.WriteLine($"- {nombreV2} llegó a los {pos2} metros.");

            if (pos1 > pos2)
            {
                Console.WriteLine($"=> El ganador es el {nombreV1}");
            }
            else if (pos2 > pos1)
            {
                Console.WriteLine($"=> El ganador es el {nombreV2}");
            }
            else
            {
                Console.WriteLine("=> Es un empate técnico");
            }
        }
    }
}
