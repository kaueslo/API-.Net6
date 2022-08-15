using Domain.Clientes;
using Domain.Contas;
using Domain.Enderecos;
using Domain.Telefones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoOmnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        #region Propriedades

        private readonly IClienteServico? _clienteServico;

        #endregion

        #region Construtores

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico ?? throw new ArgumentNullException(nameof(clienteServico)); ;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public async Task<ActionResult<Cliente>> ListarCliente()
        {
            return Ok(await _clienteServico.Listar());
        }

        [HttpGet("Id")]
        public async Task<ActionResult<Cliente>> ListarClientePorId(int id)
        {
            return Ok(await _clienteServico.ObterPorId(id));
        }


        [HttpPost]
        public async Task<ActionResult<Cliente>> InserirAtualizar([FromBody]Cliente model)
        {
            return Ok(await _clienteServico.InserirAtualizar(model.Client, model.Conta, model.Endereco, model.Telefone));
        }

        [HttpDelete]
        public async Task<ActionResult<Cliente>> Deletar(int id)
        {
            return Ok(await _clienteServico.Deletar(id));
        }

        #endregion
    }
}
