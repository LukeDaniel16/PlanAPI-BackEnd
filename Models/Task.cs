using System;
using System.ComponentModel.DataAnnotations;
using PlanAPI.Models.Enumeradores;

namespace PlanAPI.Models
{
    public class Task
    {
        public string Nome { get; set; }
        
        public EStatusTask Status { get; set; }
        
        public DateTime PrazoConclusao { get; set; }
        
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "É necessário um usuário de origem.")]
        public string EmailResponsavel { get; set; }
        
        public string EmailAssociado { get; set; }
        
        public Usuario UsuarioOrigem { get; set; }
        
        public Usuario UsuarioAssociado { get; set; }
    }
}