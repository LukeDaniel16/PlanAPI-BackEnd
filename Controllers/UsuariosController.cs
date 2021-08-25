using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlanAPI.Models;

namespace PlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly PlanDbContext _context;
        
        public UsuariosController(PlanDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Unauthorized("Não é possível retornar usuários dessa rota!");
        }
        
        [HttpPost]
        [Route("cadastro")]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Add(usuario);
            _context.SaveChanges();
            
            return Ok(usuario.Id);
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioObtido = _context.Usuarios
                    .FirstOrDefault(u => Equals(u.Email, usuario.Email) 
                                         && Equals(u.Senha, usuario.Senha));

                if (usuarioObtido == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                
                return Ok(usuarioObtido.Id);
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }
    }
}