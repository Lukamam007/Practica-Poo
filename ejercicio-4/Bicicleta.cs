using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_4
{
    public class Bicicleta : IVehiculo
    {
        private int posicionActual;
        public int Velocidad { get; set; }

        public Bicicleta()
        {
            this.posicionActual = 0;
            this.Velocidad = 10;
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
