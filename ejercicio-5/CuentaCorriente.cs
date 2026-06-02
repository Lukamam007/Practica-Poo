using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_5
{
    public class CuentaCorriente : CuentaBancaria
    {
        private float limiteDescubierto;
        public CuentaCorriente(float limiteDescubierto)
        {
            this.limiteDescubierto = limiteDescubierto;
        }
        public override bool extraer(float monto)
        {
            if (monto <= 0) return false;
            if ((this.Saldo - monto) < -this.limiteDescubierto)
            {
                Console.WriteLine($"Operación rechazada (Cuenta Corriente): La extracción de ${monto} supera el límite de descubierto (${this.limiteDescubierto}).");
                return false;
            }

            this.Saldo -= monto;
            Console.WriteLine($"Extracción exitosa de ${monto}.");
            return true;
        }
    }
}
