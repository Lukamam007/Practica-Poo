using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_5
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public override bool extraer(float monto)
        {
            if (monto <= 0) return false;

            if (monto > this.Saldo)
            {
                Console.WriteLine($"Operación rechazada (Caja de Ahorro): No hay saldo suficiente.");
                return false; 
            }

            this.Saldo -= monto;
            Console.WriteLine($"Extracción exitosa de ${monto}.");
            return true; 
        }
    }
}
