using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_5
{
    public class Banco
    {
        private List<CuentaBancaria> cuentasRegistradas;

        public Banco()
        {
            this.cuentasRegistradas = new List<CuentaBancaria>();
        }
        public void agregarCuenta(CuentaBancaria cuenta)
        {
            this.cuentasRegistradas.Add(cuenta);
        }
        public void transferir(CuentaBancaria origen, CuentaBancaria destino, float monto)
        {
            Console.WriteLine($"\nIniciando transferencia de ${monto}");

            if (!this.cuentasRegistradas.Contains(origen) || !this.cuentasRegistradas.Contains(destino))
            {
                Console.WriteLine("Transferencia fallida: Una o ambas cuentas no están registradas en este banco.");
                return;
            }

            if (monto <= 0)
            {
                Console.WriteLine("Transferencia fallida: El monto debe ser mayor a cero.");
                return;
            }
            bool pudoExtraer = origen.extraer(monto);

            if (pudoExtraer)
            {
                destino.depositar(monto);
                Console.WriteLine("Transferencia completada satisfactoriamente.");
            }
            else
            {
                Console.WriteLine("Transferencia cancelada por falta de fondos o límites de extracción en la cuenta de origen.");
            }
        }
    }
}
