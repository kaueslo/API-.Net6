using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Telefones
{
    public interface ITelefoneRepositorio
    {
        #region Metodos
        Task<Telefone> ObterPorId(int idTelefone);
        Task<Telefone> Inserir(Telefone objeto);
        Task<Telefone> Atualizar(Telefone objeto);
        Task<bool> Deletar(Telefone objeto);
        Task<List<Telefone>> Listar();
        Task<Telefone> ObterPorIdCliente(int idCliente);
        Task<List<Telefone>> ListaTelefone(int idCliente);
        #endregion
    }
}
