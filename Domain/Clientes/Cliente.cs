using Domain.Contas;
using Domain.Enderecos;
using Domain.Telefones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Conta Conta { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public Cliente Client { get; set; }
        public List<Telefone> Telefones { get; set; }

    }
}
