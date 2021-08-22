using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlanAPI.Models;
using PlanAPI.Models.Enumeradores;

namespace PlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly PlanDbContext _context;
        
        public TaskController(PlanDbContext context)
        {
            _context = context;
        }

        [Route("salvarTask/{Id}")]
        [HttpPost]
        public IActionResult Post(long Id, [FromBody] Task task)
        {
            Usuario usuarioResponsavel = null;
            var usuarioAtual = _context.Usuarios.FirstOrDefault(u => Equals(u.Id, Id));

            if (usuarioAtual == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }
            
            if (!string.IsNullOrEmpty(task.EmailAssociado))
            {
                usuarioResponsavel = _context.Usuarios.FirstOrDefault(u =>
                    Equals(u.Email, task.EmailAssociado));
            }

            task.Status = EStatusTask.Pendente;
            task.UsuarioOrigemId = Id;
            task.UsuarioOrigem = usuarioAtual;

            if (usuarioResponsavel != null)
            {
                task.UsuarioAssociadoId = usuarioResponsavel.Id;
                task.UsuarioAssociado = usuarioResponsavel;
            }

            _context.Add(task);
            _context.SaveChanges();

            return Ok("Task cadastrada com sucesso");
        }
    }
}