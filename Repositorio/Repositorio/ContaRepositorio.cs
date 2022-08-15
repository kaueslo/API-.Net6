using Domain.Contas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio
{
    public class ContaRepositorio : BaseRepositorio, IContaRepositorio
    {
        #region Construtores
        public ContaRepositorio(ProjetoOmnionDBContext contexto) : base(contexto)
        {

        }
        #endregion

        #region metodos

        public async Task<Conta> ObterPorId(int id)
        {
            try
            {
                return await _contexto.Conta.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Conta> ObterPorIdCliente(int idCliente)
        {
            try
            {
                return await _contexto.Conta.FirstOrDefaultAsync(x => x.ClienteId == idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Conta> Inserir(Conta objeto)
        {
            try
            {
                await _contexto.Conta.AddAsync(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Conta> Atualizar(Conta objeto)
        {
            try
            {
                _contexto.Conta.Update(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Deletar(Conta objeto)
        {
            try
            {
                _contexto.Conta.Remove(objeto);

                await _contexto.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Conta>> Listar()
            => await _contexto.Conta.OrderByDescending(x => x.Id).ToListAsync();

        #endregion
    }
}
