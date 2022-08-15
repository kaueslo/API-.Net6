using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio
{
    public class BaseRepositorio
    {
        #region Propriedades

        public readonly ProjetoOmnionDBContext _contexto;

        #endregion

        #region Construtores

        public BaseRepositorio(ProjetoOmnionDBContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        #endregion
    }
}
