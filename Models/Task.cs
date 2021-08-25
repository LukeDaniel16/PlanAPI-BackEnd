using System;
using PlanAPI.Models.Enumeradores;

namespace PlanAPI.Models
{
    public class Task
    {
        public long Id { get; set; }
        
        public string Nome { get; set; }
        
        public EStatusTask Status { get; set; }

        public DateTime PrazoConclusao { get; set; }
        
        public string Descricao { get; set; }
        
        public string DescricaoConclusao { get; set; }
        
        public string DescricaoCancelamento { get; set; }

        public string EmailAssociado { get; set; }
        
        public long UsuarioOrigemId { get; set; }
        
        public Usuario UsuarioOrigem { get; set; }
        
        public long UsuarioAssociadoId { get; set; }
        
        public Usuario UsuarioAssociado { get; set; }
    }
}