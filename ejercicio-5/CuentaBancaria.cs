using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_5
{
    public abstract class CuentaBancaria
    {
        protected float Saldo { get; set; }
        public CuentaBancaria()
        {
            this.Saldo = 0;
        }
        public void depositar(float monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("Error: El monto a depositar debe ser mayor a cero.");
                return;
            }

            this.Saldo += monto;
            Console.WriteLine($"Se depositaron ${monto}.");
        }
        public abstract bool extraer(float monto);

        public void mostrarSaldo()
        {
            Console.WriteLine($"[Consulta] El saldo actual es: ${this.Saldo}");
        }
    }
}
