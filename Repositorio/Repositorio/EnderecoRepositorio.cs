using Domain.Enderecos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio
{
    public class EnderecoRepositorio : BaseRepositorio, IEnderecoRepositorio
    {
        #region Construtores

        public EnderecoRepositorio(ProjetoOmnionDBContext contexto) : base(contexto)
        {

        }

        #endregion

        #region Metodos

        public async Task<Endereco> ObterPorId(int id)
        {
            try
            {
                return await _contexto.Endereco.FirstOrDefaultAsync(x => x.Id == id);
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
                return await _contexto.Endereco.FirstOrDefaultAsync(x => x.ClienteId == idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Endereco> Inserir(Endereco objeto)
        {
            try
            {
                await _contexto.Endereco.AddAsync(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Endereco> Atualizar(Endereco objeto)
        {
            try
            {
                _contexto.Endereco.Update(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Deletar(Endereco objeto)
        {
            try
            {
                _contexto.Remove(objeto);

                await _contexto.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Endereco>> Listar()
            => await _contexto.Endereco.OrderByDescending(x => x.Id).ToListAsync();

        #endregion

    }
}
