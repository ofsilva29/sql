using System.Collections.Generic;
using System.Linq;

namespace UsandoInterface
{
    public interface IConsultaCliente {
        List<string> GetResultado(string nomeCliente);
    }
    public class ConsultaCliente : IConsultaCliente
    {
        public List<string> GetResultado(string nomeCliente)
        {
           var itens = new List<string> { "Maria","João","Amanda","Diogo","Carla","Paulo","Fernanda"
                                };

                   var resultado = itens.Where(e => e.Contains(nomeCliente)).ToList();
                   return resultado;
        }
    }
    public class Cliente
    {
        private string nome = null;
        private IConsultaCliente consultaCliente = null;
        public List<string> Procurar(string nome)
        {
            return consultaCliente.GetResultado(nome);
       }
       public Cliente(string _nome, IConsultaCliente _consultaCliente)
       {
            nome = _nome;
            consultaCliente = _consultaCliente;
       }
    }

    class Programa
    {
        static void Main()
        {
            IConsultaCliente consulta = new ConsultaCliente();
            var cliente = new Cliente("Maria", consulta);
            var resultado = cliente.Procurar();

            foreach (var item in resultado)
                Console.WriteLine(item);
        }
    }
}