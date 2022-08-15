using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enderecos
{
    public interface IEnderecoServico
    {
        #region Métodos
        Task<Endereco> ObterPorId(int idCliente);
        Task<List<Endereco>> Listar();
        Task<Endereco> ObterPorIdCliente(int idCliente);
        #endregion Métodos
    }
}
