using System.ComponentModel.DataAnnotations;

namespace PlanAPI.Models.Enumeradores
{
    public enum EStatusTask
    {
        [Display(Name = "Cancelado")]
        Cancelado,
        [Display(Name = "Pendente")]
        Pendente,
        [Display(Name = "Concluído")]
        Concluido
    }
}