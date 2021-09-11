using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Interfaces;
using Domain.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
       public UsuarioController(IUsuarioService usuarioService)
       {
           this.usuarioService = usuarioService;
       }


       
        /// <summary>
        /// Pode ser feito com Paginação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<Usuario>> Get()
        {
            return usuarioService.GetAll();
        }
       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound("Id não pode ser zero");
            }
            return Ok(usuarioService.Find(id).Result);
        }
        
        [HttpPost]
        public Task<Usuario> Post(Usuario obj)
        {
            return usuarioService.Insert(obj);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            await usuarioService.Update(id, obj);
            return Ok();
        }
    }
}
