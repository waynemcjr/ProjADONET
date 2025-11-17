using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjADONET
{
    public class Telefone
    {
        public int Id { get; private set; }
        public String DDD { get; private set; }
        public String Numero { get; private set; }
        public string Tipo { get; private set; }
        public int PessoaId { get; private set; }

        public Telefone(string dDD, string numero, string tipo, int pessoaId)
        {
            DDD = dDD;
            Numero = numero;
            Tipo = tipo;
            PessoaId = pessoaId;
        }

        public override string? ToString()
        {
            return $"DDD: {DDD}\nNumero: {Numero}\nTipo: {Tipo}";
        }
    }
}
