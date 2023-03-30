using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Contas
    {

        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }    
        public double saldo { get; set; }
        public string localidade { get; set; }
        public double cpf { get; set; }

        public void payment(double price)
        {
            saldo = saldo - price;
        }
        public void acres (double price)
        {
            saldo = saldo + price;
        }





    }
}
