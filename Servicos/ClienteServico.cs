using Domain.Clientes;
using Domain.Contas;
using Domain.Enderecos;
using Domain.Telefones;
using Microsoft.Extensions.Logging;
using Repositorio;
using Repositorio.Repositorio;

namespace Servicos
{
    public class ClienteServico : IClienteServico
    {
        #region Propriedades

        private readonly IClienteRepositorio? _clienteRepositorio;
        private readonly IContaRepositorio? _contaRepositorio;
        private readonly IEnderecoRepositorio? _enderecoRepositorio;
        private readonly ITelefoneRepositorio? _telefoneRepositorio;

        #endregion

        #region Construtores

        public ClienteServico(IClienteRepositorio clienteRepositorio,
            IContaRepositorio contaRepositorio, IEnderecoRepositorio enderecoRepositorio, ITelefoneRepositorio telefoneRepositorio)
        {
            _clienteRepositorio = clienteRepositorio ?? throw new ArgumentNullException(nameof(clienteRepositorio));
            _contaRepositorio = contaRepositorio ?? throw new ArgumentNullException(nameof(contaRepositorio));
            _enderecoRepositorio = enderecoRepositorio ?? throw new ArgumentNullException(nameof(enderecoRepositorio));
            _telefoneRepositorio = telefoneRepositorio ?? throw new ArgumentNullException(nameof(telefoneRepositorio));
        }

        #endregion

        #region Metodos

        public async Task<Cliente> ObterPorId(int Id)
        {
            try
            {
                Cliente retorno = await _clienteRepositorio.ObterPorId(Id);

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Cliente> VerificaCPF(Cliente objeto)
        {
            try
            {
                Cliente retorno = await _clienteRepositorio.ObterPorCPF(objeto.CPF);

                //Verificando se a pessoa já está cadastrada ou não no banco
                if (retorno != null)
                {
                    throw new Exception("Não é possível cadastrar um usuário já cadastrado");
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Telefone> VerificaTelefone(Telefone objeto)
        {
            try
            {
                List<Telefone> retorno = await _telefoneRepositorio.ListaTelefone(objeto.ClienteId);

                //Verificando se o celular já está cadastrado para o mesmo usuário

                if (retorno.Count > 1)
                {
                    throw new Exception("Não é possível cadastrar mais que um número de celular por usuário");
                }

                return retorno.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Cliente> InserirAtualizar(Cliente objeto, Conta conta, Endereco endereco, Telefone telefone)
        {
            try
            {
                Cliente obj = await ObterPorId(objeto.Id);
                Conta objconta = await _contaRepositorio.ObterPorIdCliente(objeto.Id);
                Telefone objtelefone = await _telefoneRepositorio.ObterPorIdCliente(objeto.Id);
                Endereco objendereco = await _enderecoRepositorio.ObterPorIdCliente(objeto.Id);
                VerificaCampos(obj, conta, telefone, endereco);
                Cliente Retorno = new Cliente();
                Conta RetornoConta = new Conta();
                Telefone RetornoTelefone = new Telefone();
                Endereco RetornoEndereco = new Endereco();

                if (obj != null)
                {
                    conta.ClienteId = objconta.ClienteId;
                    conta.SaldoPontos = objconta.SaldoPontos;
                    objtelefone.ClienteId = objtelefone.ClienteId;
                    telefone.DDD = objtelefone.DDD;
                    telefone.Numero = objtelefone.Numero;
                    endereco.Rua = objendereco.Rua;
                    endereco.Numero = objendereco.Numero;
                    endereco.CEP = objendereco.CEP;

                    obj.DataAlteracao = DateTime.Now;
                    RetornoConta = await _contaRepositorio.Atualizar(objconta);
                    RetornoTelefone = await _telefoneRepositorio.Atualizar(objtelefone);
                    RetornoEndereco = await _enderecoRepositorio.Atualizar(objendereco);
                    Retorno = await _clienteRepositorio.Atualizar(obj);
                }
                else
                {
                    conta.ClienteId = objconta.ClienteId;
                    conta.SaldoPontos = objconta.SaldoPontos;
                    objtelefone.ClienteId = objtelefone.ClienteId;
                    telefone.DDD = objtelefone.DDD;
                    telefone.Numero = objtelefone.Numero;
                    endereco.Rua = objendereco.Rua;
                    endereco.Numero = objendereco.Numero;
                    endereco.CEP = objendereco.CEP;

                    obj.DataCadastro = DateTime.Now;
                    obj.DataAlteracao = DateTime.Now;

                    //Fazendo as verificações da regra de negócio
                    await VerificaCPF(obj);
                    await VerificaTelefone(objtelefone);

                    RetornoConta = await _contaRepositorio.Atualizar(objconta);
                    RetornoTelefone = await _telefoneRepositorio.Atualizar(objtelefone);
                    RetornoEndereco = await _enderecoRepositorio.Atualizar(objendereco);
                    Retorno = await _clienteRepositorio.Atualizar(obj);

                }

                return Retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Deletar(int id)
        {
            try
            {
                Cliente cliente = await _clienteRepositorio.ObterPorId(id);
                Conta conta = await _contaRepositorio.ObterPorIdCliente(id);
                Endereco endereco = await _enderecoRepositorio.ObterPorIdCliente(id);
                Telefone telefone = await _telefoneRepositorio.ObterPorIdCliente(id);

                await _clienteRepositorio.Deletar(cliente);
                await _contaRepositorio.Deletar(conta);
                await _enderecoRepositorio.Deletar(endereco);
                await _telefoneRepositorio.Deletar(telefone);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Cliente>> Listar()
        {
            try
            {
                List<Cliente> retorno = await _clienteRepositorio.Listar();

                retorno.OrderByDescending(x => x.Id);

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void VerificaCampos(Cliente cliente, Conta conta, Telefone telefone, Endereco endereco)
        {
            if (cliente.Nome == null) throw new Exception("Por gentileza, preencha o campo Nome");
            if (cliente.CPF == null) throw new Exception("Por gentileza, preencha o campo CPF");
            if (conta.SaldoPontos == 0) throw new Exception("Por gentileza, preencha o campo de Pontos");
            if (telefone.DDD == 0) throw new Exception("Por gentileza, preencha o campo DDD");
            if (telefone.Numero == 0) throw new Exception("Por gentileza, preencha o campo de Número do telefone");
            if (endereco.Rua == null) throw new Exception("Por gentileza, preencha o campo Rua");
            if (endereco.Numero == 0) throw new Exception("por gentileza, preencha o campo Número");
            if (endereco.CEP == null) throw new Exception("Por gentileza, preencha o campo CEP");
        }

        #endregion Metodos
    }
}
