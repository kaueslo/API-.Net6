using Domain.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Telefones
{
    public class Telefone
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int DDD { get; set; }
        public decimal Numero { get; set; }
        public Cliente Cliente { get; set; }
    }
}
