using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_3
{
    public class Amateur : IJugador
    {
        private int minutosCorridos;
        private int limiteMinutos;
        private bool estaCansado;

        public Amateur()
        {
            this.minutosCorridos = 0;
            this.limiteMinutos = 20;
            this.estaCansado = false;
        }

        public bool correr(int minutos)
        {
            if (this.estaCansado)
            {
                return false; 
            }

            if (this.minutosCorridos + minutos > this.limiteMinutos)
            {
                this.estaCansado = true;
                this.minutosCorridos = this.limiteMinutos;
                return false;
            }

            this.minutosCorridos += minutos;
            return true;
        }

        public bool cansado()
        {
            return this.estaCansado;
        }

        public void descansar(int minutos)
        {
            this.minutosCorridos -= minutos;

            if (this.minutosCorridos < 0)
            {
                this.minutosCorridos = 0;
            }
            if (this.minutosCorridos < this.limiteMinutos)
            {
                this.estaCansado = false;
            }
        }
    }
}
