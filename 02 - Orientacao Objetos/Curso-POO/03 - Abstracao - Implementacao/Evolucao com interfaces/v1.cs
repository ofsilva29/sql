
using System.Collections.Generic;
using System.Linq;

namespace UsandoInterface
{
    public class ConsultaCliente
    {
        public List<string> GetResultado(string nomeCliente)
        {
           var itens = new List<string> { "Maria","João","Amanda","Digo","Carla","Paulo","Fernanda"};

                   var resultado = itens.Where(e => e.Contains(nomeCliente)).ToList();
                   return resultado;
        }
    }

    public class Cliente
    {
        private string nome= null;
        public List<string> Procurar()
        {
            ConsultaCliente procura = new ConsultaCliente();
            return procura.GetResultado(nome);
       }
       public Cliente(string _nome)
       {
            nome = _nome;
       }
    }

    class Programa
    {
        static void Main()
        {
            var cliente = new Cliente("Maria");
            var resultado = cliente.Procurar();

            foreach (var item in resultado)
                Console.WriteLine(item);
        }
    }
}