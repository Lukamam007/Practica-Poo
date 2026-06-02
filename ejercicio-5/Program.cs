using System;
using System.Collections.Generic;

namespace ejercicio_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prueba caja de ahorro");
            CajaDeAhorro ahorro1 = new CajaDeAhorro();
            ahorro1.depositar(1000);
            ahorro1.extraer(400);
            ahorro1.extraer(800); 
            ahorro1.mostrarSaldo();


            Console.WriteLine("\Prueba caja corriente");
            CuentaCorriente corriente1 = new CuentaCorriente(500);
            corriente1.depositar(200);
            corriente1.extraer(600);
            corriente1.extraer(200);
            corriente1.mostrarSaldo();


            Console.WriteLine("\nPruea del sistema (transferencia)");
            Banco banco = new Banco();
            
            CajaDeAhorro ahorro2 = new CajaDeAhorro();
            CuentaCorriente corriente2 = new CuentaCorriente(500);
            
            banco.agregarCuenta(ahorro2);
            banco.agregarCuenta(corriente2);
            
            ahorro2.depositar(1000);
            banco.transferir(ahorro2, corriente2, 300);
  
            banco.transferir(ahorro2, corriente2, 900);
            
            Console.WriteLine("\nSaldos finales post-transferencias:");
            ahorro2.mostrarSaldo();
            corriente2.mostrarSaldo();
        }
    }
}
