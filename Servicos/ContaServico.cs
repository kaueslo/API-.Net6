using Domain.Clientes;
using Domain.Contas;
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
    public class ContaServico : BaseRepositorio, IContaServico
    {
        #region Propriedades
        private readonly IContaRepositorio _contaRepositorio;
        private readonly IClienteRepositorio? _clienteRepositorio;
        #endregion

        #region Construtores

        public ContaServico(ProjetoOmnionDBContext projetoOmnionDBContext, IContaRepositorio contaRepositorio,
            IClienteRepositorio clienteRepositorio) : base(projetoOmnionDBContext)
        {
            _contaRepositorio = contaRepositorio ?? throw new ArgumentNullException(nameof(contaRepositorio));
            _clienteRepositorio = clienteRepositorio ?? throw new ArgumentNullException(nameof(clienteRepositorio));
        }

        #endregion

        #region Metodos

        public async Task<Conta> Inserir(Conta objeto)
        {
            try
            {
                Conta Retorno = new Conta();

                Retorno = await _contaRepositorio.Inserir(objeto);

                return Retorno;
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
                Conta Retorno = new Conta();

                Retorno = await _contaRepositorio.Atualizar(objeto);

                return Retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Conta> ObterPorIdCliente(int idCliente)
        {
            try
            {
                return _contaRepositorio.ObterPorIdCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Conta> ObterPorId(int Id)
        {
            try
            {
                Conta retorno = await _contaRepositorio.ObterPorId(Id);

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Conta> InserirAtualizar(Conta objeto)
        {
            try
            {
                Cliente cliente = await _clienteRepositorio.ObterPorId(objeto.ClienteId);
                Conta obj = await ObterPorId(objeto.Id);
                Conta Retorno = new Conta();

                if (obj != null)
                {
                    cliente.DataAlteracao = DateTime.Now;

                    Retorno = await _contaRepositorio.Atualizar(obj);
                }
                else
                {
                    Retorno = await _contaRepositorio.Inserir(obj);
                }
                return Retorno;
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
                await _contaRepositorio.Deletar(objeto);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Conta>> Listar()
        {
            try
            {
                List<Conta> retorno = await _contaRepositorio.Listar();

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Conta> AcrescentarPontosUsuario(Conta objeto, int pontos)
        {
            try
            {
                Conta conta = await ObterPorId(objeto.Id);

                Conta Retorno = new Conta();

                if (conta != null)
                {

                    conta.SaldoPontos += pontos;

                    //var saldoNovo = conta.SaldoPontos + pontos;

                    //Verificação se o usuário tem mais que 1000 pontos
                    if ((conta.SaldoPontos += pontos) > 1000)
                    {
                        throw new ArgumentException("Não é possível ter mais que 1000 pontos");
                    }

                    Retorno = await _contaRepositorio.Atualizar(conta);
                }

                return Retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Conta> RemoverPontosUsuario(Conta objeto, int pontos)
        {
            try
            {
                Conta conta = await ObterPorId(objeto.Id);

                Conta Retorno = new Conta();

                if (conta != null)
                {
                    conta.SaldoPontos -= pontos;

                    //var saldoNovo = conta.SaldoPontos - pontos;

                    if ((conta.SaldoPontos -= pontos) > 1000)
                    {
                        throw new Exception("Não é possível ter mais que 1000 pontos");
                    }

                    Retorno = await _contaRepositorio.Atualizar(conta);
                }
                return Retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion Metodos
        }

    }
}
