using Domain.Enderecos;
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
    public class EnderecoServico : BaseRepositorio, IEnderecoServico
    {
        #region Propriedades

        private readonly IEnderecoRepositorio? _enderecoRepositorio;

        #endregion

        #region Construtores

        public EnderecoServico(ProjetoOmnionDBContext projetoOmnionDBContext, IEnderecoRepositorio enderecoRepositorio) : base(projetoOmnionDBContext)
        {
            _enderecoRepositorio = enderecoRepositorio ?? throw new ArgumentNullException(nameof(enderecoRepositorio));
        }

        #endregion

        #region Metodos

        public async Task<Endereco> ObterPorId(int id)
        {
            try
            {
                Endereco retorno = await _enderecoRepositorio.ObterPorId(id);

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Endereco> ObterPorIdCliente(int idCliente)
        {
            try
            {
                return await _enderecoRepositorio.ObterPorIdCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Endereco>> Listar()
        {
            try
            {
                return await _enderecoRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
