using System.ComponentModel.DataAnnotations;

namespace PlanAPI.Models.Enumeradores
{
    public enum EStatusTask
    {
        Cancelado,
        Pendente,
        [Display(Name = "Concluído")]
        Concluido
    }
}