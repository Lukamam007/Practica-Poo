using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_3
{
    public class Profesional : IJugador
    {
        private int minutosCorridos;
        private int limiteMinutos;
        private bool estaCansado;

        public Profesional()
        {
            this.minutosCorridos = 0;
            this.limiteMinutos = 40; // Límite para jugador profesional 
            this.estaCansado = false;
        }
        public bool correr(int minutos)
        {
            if (this.estaCansado)
            {
                return false; // Si está cansado, no puede correr 
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
