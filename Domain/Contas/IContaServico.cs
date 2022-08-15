using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contas
{
    public interface IContaServico
    {
        #region Metodos
        Task<Conta> ObterPorId(int idCliente);
        Task<Conta> Inserir(Conta objeto);
        Task<Conta> Atualizar(Conta objeto);
        Task<bool> Deletar(Conta objeto);
        Task<List<Conta>> Listar();
        Task<Conta> ObterPorIdCliente(int idCliente);
        Task<Conta> AcrescentarPontosUsuario(Conta objeto, int pontos);
        Task<Conta> RemoverPontosUsuario(Conta objeto, int pontos);
        #endregion
    }
}
