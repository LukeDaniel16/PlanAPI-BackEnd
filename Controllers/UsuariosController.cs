using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;
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

            return Ok("Usuário cadastrado com sucesso!");
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioObtido = _context.Usuarios
                    .Single(u => Equals(usuario.Email, u.Email)
                                 && Equals(usuario.Senha, u.Senha));

                if (usuarioObtido != null)
                {
                    
                }
            }
            catch (Exception e)
            {
                return Forbid("Esse usuário está incorreto");
            }

            return Ok("Login realizado com sucesso");
        }
    }
}