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
    public class EscolaridadeController : ControllerBase
    {
        private readonly IEscolaridadeService escolaridadeService;
       public EscolaridadeController(IEscolaridadeService escolaridadeService)
       {
           this.escolaridadeService = escolaridadeService;
       }
       
        /// <summary>
        /// Pode ser feito com Paginação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<Escolaridade>> Get()
        {
            return escolaridadeService.GetAll();
        }
       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound("Id não pode ser zero");
            }
            return Ok(escolaridadeService.Find(id).Result);
        }
        
        [HttpPost]
        public Task<Escolaridade> Post(Escolaridade obj)
        {
            return escolaridadeService.Insert(obj);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Escolaridade obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            await escolaridadeService.Update(id, obj);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            await escolaridadeService.Delete(id);
            return Ok();
        }
    }
}
