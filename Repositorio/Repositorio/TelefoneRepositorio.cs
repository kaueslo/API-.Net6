using Domain.Telefones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio
{
    public class TelefoneRepositorio : BaseRepositorio, ITelefoneRepositorio
    {
        #region Construtores

        public TelefoneRepositorio(ProjetoOmnionDBContext contexto) : base(contexto)
        {

        }

        #endregion

        #region Metodos
        public async Task<Telefone> ObterPorId(int id)
        {
            try
            {
                return await _contexto.Telefone.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Telefone> ObterPorIdCliente(int idCliente)
        {
            try
            {
                return await _contexto.Telefone.FirstOrDefaultAsync(x => x.ClienteId == idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Telefone> Inserir(Telefone objeto)
        {
            try
            {
                await _contexto.Telefone.AddAsync(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Telefone> Atualizar(Telefone objeto)
        {
            try
            {
                _contexto.Telefone.Update(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Deletar(Telefone objeto)
        {
            try
            {
                _contexto.Telefone.Remove(objeto);

                await _contexto.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Telefone>> Listar()
            => await _contexto.Telefone.OrderByDescending(x => x.Id).ToListAsync();

        public async Task<List<Telefone>> ListaTelefone(int idCliente)
            => await _contexto.Telefone.Where(x => x.ClienteId == idCliente).ToListAsync();

        #endregion
    }
}
