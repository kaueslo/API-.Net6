using Domain.Clientes;
using Domain.Contas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoOmnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContaController : ControllerBase
    {
        #region Propriedades

        private readonly IContaServico? _contaServico;

        #endregion

        #region Construtores

        public ContaController(IContaServico contaServico)
        {
            _contaServico = contaServico ?? throw new ArgumentNullException(nameof(contaServico)); ;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public async Task<ActionResult<Conta>> ListarConta()
        {
            return Ok(await _contaServico.Listar());
        }

        [HttpGet("Id")]
        public async Task<ActionResult<Conta>> ObterPorId(int id)
        {
            return Ok(await _contaServico.ObterPorId(id));
        }

        [HttpGet("IdCliente")]
        public async Task<ActionResult<Conta>> ObterPorIdCliente(int idCliente)
        {
            return Ok(await _contaServico.ObterPorIdCliente(idCliente));
        }

        [HttpPost("AcrescentarPontos")]
        public async Task<ActionResult<Conta>> AcrescentarPonto([FromBody] Conta conta, int pontos)
        {
            return Ok(await _contaServico.AcrescentarPontosUsuario(conta, pontos));
        }

        [HttpPost("RemoverPontos")]
        public async Task<ActionResult<Conta>> RemoverPontos([FromBody] Conta conta, int pontos)
        {
            return Ok(await _contaServico.RemoverPontosUsuario(conta, pontos));
        }

        #endregion
    }
}
