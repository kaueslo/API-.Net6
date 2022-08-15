using Domain.Telefones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoOmnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TelefoneController : ControllerBase
    {
        #region Propriedades

        private readonly ITelefoneServico? _telefoneController;

        #endregion

        #region Construtores

        public TelefoneController(ITelefoneServico telefoneServico)
        {
            _telefoneController = telefoneServico ?? throw new ArgumentNullException(nameof(telefoneServico)); ;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public async Task<ActionResult> ListarTelefone()
        {
            return Ok(await _telefoneController.Listar());
        }

        [HttpGet("Id")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            return Ok(await _telefoneController.ObterPorId(id));
        }

        [HttpGet("IdCliente")]
        public async Task<ActionResult> ObterPorIdCliente(int idCliente)
        {
            return Ok(await _telefoneController.ObterPorIdCliente(idCliente));
        }

        #endregion
    }
}
