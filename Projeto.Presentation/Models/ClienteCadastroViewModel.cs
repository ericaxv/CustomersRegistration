using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projeto.Repository.Entities;

namespace Projeto.Presentation.Models
{
    public class ClienteCadastroViewModel
    {
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [Required(ErrorMessage = "Por favor informe o nome completo do cliente.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [Required(ErrorMessage = "Por favor informe o email do cliente.")]
        public string Email { get; set; }

        
    }
}