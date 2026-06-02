using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_2
{
    public class Cronometro
    {
        public int Minutos { get; set; }
        public int Segundos { get; set; }

        public Cronometro()
        {
            this.Minutos = 0;
            this.Segundos = 0;
        }
        public void reiniciar()
        {
            this.Minutos = 0;
            this.Segundos = 0;
        }
        public void incrementarTiempo()
        {
            this.Segundos++;
            if (this.Segundos > 59)
            {
                this.Minutos++;
                this.Segundos = 0;
            }
        }
        public string mostrarTiempo()
        {
            return $"{this.Minutos} minutos, {this.Segundos} segundos";
        }
    }
}
