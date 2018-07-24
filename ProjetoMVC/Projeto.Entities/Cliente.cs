using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public Status Status { get; set; }

    }
}
