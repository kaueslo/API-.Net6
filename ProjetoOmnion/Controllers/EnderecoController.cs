using Domain.Enderecos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoOmnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        #region Propriedades

        private readonly IEnderecoServico? _enderecoController;

        #endregion

        #region Construtores

        public EnderecoController(IEnderecoServico enderecoServico)
        {
            _enderecoController = enderecoServico ?? throw new ArgumentNullException(nameof(enderecoServico)); ;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public async Task<ActionResult> ListarEndereco()
        {
            return Ok(await _enderecoController.Listar());
        }

        [HttpGet("Id")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            return Ok(await _enderecoController.ObterPorId(id));
        }

        [HttpGet("IdCliente")]
        public async Task<ActionResult> ObterPorIdCliente(int idCliente)
        {
            return Ok(await _enderecoController.ObterPorIdCliente(idCliente));
        }

        #endregion
    }
}
