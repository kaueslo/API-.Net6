using Domain.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contas
{
    public class Conta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int SaldoPontos { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}
