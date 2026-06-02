using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_1
{
    public class Semaforo
    {
        public string ColorActual { get;set; }
        public int TiempoEnColor { get;set; }
        public bool EsIntermitente { get;set; }

        private string estadoIntermitente;

        public Semaforo(string colorInicial)
        {
            this.ColorActual = colorInicial;
            this.TiempoEnColor = 0; 
            this.EsIntermitente = false;
        }
        public void pasoDelTiempo(int segundos)
        {
            for (int i = 0; i < segundos; i++)
            {
                if (this.EsIntermitente)
                {
                    if (this.estadoIntermitente == "Amarillo")
                    {
                     this.estadoIntermitente = "Apagado";
                    }
                    else
                    {
                      this.estadoIntermitente = "Amarillo";
                    }
                }
                else
                {
                    this.TiempoEnColor++;
                    if (this.ColorActual == "Rojo" && this.TiempoEnColor >= 30)
                    {
                        this.ColorActual = "Rojo + Amarillo";
                        this.TiempoEnColor = 0;
                    }
                    else if (this.ColorActual == "Rojo + Amarillo" && this.TiempoEnColor >= 2)
                    {
                        this.ColorActual = "Verde";
                        this.TiempoEnColor = 0;
                    }
                    else if (this.ColorActual == "Verde" && this.TiempoEnColor >= 20)
                    {
                        this.ColorActual = "Amarillo";
                        this.TiempoEnColor = 0;
                    }
                    else if (this.ColorActual == "Amarillo" && this.TiempoEnColor >= 2)
                    {
                        this.ColorActual = "Rojo";
                        this.TiempoEnColor = 0;
                    }
                }
            }
        }
        public void mostrarColor()
        {
            if (this.EsIntermitente)
            {
                Console.WriteLine($"Semáforo intermitente: {this.estadoIntermitente}");
            }
            else
            {
                Console.WriteLine($"Semáforo en: {this.ColorActual} (Tiempo transcurrido: {this.TiempoEnColor}s)");
            }
        }
        public void ponerEnIntermitente()
        {
            this.EsIntermitente = true;
            this.estadoIntermitente = "Amarillo";
        }
        public void sacarDeIntermitente()
        {
            this.EsIntermitente = false;
        }
    }
}
