using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Repository.Entities;

namespace Projeto.Presentation.Models
{
    public class ClienteExclusaoViewModel
    {
        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
    }
}