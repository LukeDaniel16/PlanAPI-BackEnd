using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanAPI.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        
        [MaxLength(160, ErrorMessage = "O número máximo de caracteres foi inserido")]
        public string Nome { get; set; }
        
        [MaxLength(80, ErrorMessage = "O número máximo de caracteres foi inserido")]
        public string Apelido { get; set; }
        
        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Insira uma senha!")]
        [MinLength(6, ErrorMessage = "Digite uma senha maior!")]
        [MaxLength(160, ErrorMessage = "O número máximo de caracteres foi inserido")]
        public string Senha { get; set; }
        
        public DateTime DataCriacaoConta { get; set; }
        
        public List<Task> TasksCriadas { get; set; }
        
        public List<Task> TasksAssociadas { get; set; }
    }
}