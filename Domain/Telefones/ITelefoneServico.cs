using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Telefones
{
    public interface ITelefoneServico
    {
        #region Metodos
        Task<Telefone> ObterPorId(int idTelefone);
        Task<List<Telefone>> Listar();
        Task<Telefone> ObterPorIdCliente(int idCliente);
        #endregion
    }
}
