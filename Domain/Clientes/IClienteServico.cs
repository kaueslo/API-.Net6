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
    public interface IClienteServico
    {
        Task<Cliente> ObterPorId(int idCliente);
        Task<Cliente> InserirAtualizar(Cliente objeto, Conta conta, Endereco endereco, Telefone telefone);
        Task<bool> Deletar(int idCliente);
        Task<List<Cliente>> Listar();
    }
}
