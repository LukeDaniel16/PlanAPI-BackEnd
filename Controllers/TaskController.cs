using System.Collections.Generic;
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

        [Route("buscarTasks/{Id}/{paraMim}")]
        [HttpPost]
        public IActionResult BuscarTask(long Id, bool paraMim)
        {
            List<Task> tasksObtidas;
            
            tasksObtidas = paraMim 
                ? _context.Tasks.Where(t => t.UsuarioAssociadoId == Id).ToList() 
                : _context.Tasks.Where(t => t.UsuarioOrigemId == Id).ToList();
            
            return Ok(tasksObtidas);
        }

        [Route("concluirTask/{Id}")]
        [HttpPut]
        public IActionResult ConcluirTask(long Id, [FromBody] Task task)
        {
            var taskObtida = _context.Tasks.FirstOrDefault(t => t.Id == Id);

            if (taskObtida == null)
            {
                return NotFound();
            }
            
            taskObtida.Status = EStatusTask.Concluido;
            taskObtida.DescricaoConclusao = task.DescricaoConclusao;
            _context.SaveChanges();
            return Ok("Tarefa concluída com sucesso!");
        }

        [Route("cancelarTask/{Id}")]
        [HttpPut]
        public IActionResult CancelarTask(long Id, [FromBody] Task task)
        {
            var taskObtida = _context.Tasks.FirstOrDefault(t => t.Id == Id);

            if (taskObtida == null)
            {
                return NotFound();
            }
            
            taskObtida.Status = EStatusTask.Cancelado;
            taskObtida.DescricaoCancelamento = task.DescricaoCancelamento;
            _context.SaveChanges();
            return Ok("Tarefa cancelada com sucesso!");
        }
    }
}