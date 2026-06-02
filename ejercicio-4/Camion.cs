using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_4
{
    public class Camion : IVehiculo
    {
        private int posicionActual;
        public int Velocidad { get; private set; }

        public Camion()
        {
            this.posicionActual = 0;
            this.Velocidad = 30; // Velocidad fija 
        }

        public void mover(int tiempo)
        {
            this.posicionActual += this.Velocidad * tiempo;
        }

        public int posicion()
        {
            return this.posicionActual;
        }

        public void reiniciarPosicion()
        {
            this.posicionActual = 0;
        }
    }
}
