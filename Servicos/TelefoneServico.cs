using Domain.Telefones;
using Microsoft.Extensions.Logging;
using Repositorio;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class TelefoneServico : BaseRepositorio, ITelefoneServico
    {
        #region Propriedades

        private readonly ITelefoneRepositorio? _telefoneRepositorio;

        #endregion

        #region Construtores

        public TelefoneServico(ProjetoOmnionDBContext projetoOmnionDBContext, ITelefoneRepositorio telefoneRepositorio) : base(projetoOmnionDBContext)
        {
            _telefoneRepositorio = telefoneRepositorio ?? throw new ArgumentNullException(nameof(telefoneRepositorio));
        }

        #endregion

        #region Metodos

        public async Task<Telefone> ObterPorId(int id)
        {
            try
            {
                Telefone retorno = await _telefoneRepositorio.ObterPorId(id);

                return retorno;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Telefone> ObterPorIdCliente(int idCliente)
        {
            try
            {
                return await _telefoneRepositorio.ObterPorIdCliente(idCliente);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Telefone>> Listar()
        {
            try
            {
                return await _telefoneRepositorio.Listar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
