using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enderecos
{
    public interface IEnderecoRepositorio
    {
        #region Métodos
        Task<Endereco> ObterPorId(int idCliente);
        Task<Endereco> Inserir(Endereco objeto);
        Task<Endereco> Atualizar(Endereco objeto);
        Task<bool> Deletar(Endereco objeto);
        Task<List<Endereco>> Listar();
        Task<Endereco> ObterPorIdCliente(int idCliente);
        #endregion Métodos
    }
}
