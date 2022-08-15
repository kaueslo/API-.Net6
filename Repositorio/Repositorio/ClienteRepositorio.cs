using Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio
{
    public class ClienteRepositorio : BaseRepositorio, IClienteRepositorio
    {
        #region Construtores
        public ClienteRepositorio(ProjetoOmnionDBContext contexto) : base(contexto)
        {

        }
        #endregion

        #region metodos

        public async Task<Cliente> ObterPorId(int id)
        {
            try
            {
                return await _contexto.Cliente.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> ObterPorCPF(string cpf)
        {
            try
            {
                return await _contexto.Cliente.FirstOrDefaultAsync(x => x.CPF == cpf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> Inserir(Cliente objeto)
        {
            try
            {
                await _contexto.Cliente.AddAsync(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> Atualizar(Cliente objeto)
        {
            try
            {
                _contexto.Cliente.Update(objeto);

                await _contexto.SaveChangesAsync();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Deletar(Cliente objeto)
        {
            try
            {
                _contexto.Cliente.Remove(objeto);

                await _contexto.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Cliente>> Listar()
            => await _contexto.Cliente.OrderByDescending(x => x.Id).ToListAsync();

        #endregion
    }
}
