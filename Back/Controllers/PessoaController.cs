using Microsoft.AspNetCore.Mvc;
using provagui.Models;
using provagui.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace provagui.Controllers
{
    [ApiController]
    [Route("v1/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly DataContext _context;
        public PessoaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pessoa pessoa)
        {
            if (PessoaExists(pessoa)){
                return StatusCode(400);
            }
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }


        [HttpGet]
        public async Task<IActionResult> List() => Ok(await _context.Pessoa.ToListAsync());



        
        private bool PessoaExists(Pessoa pessoa) =>  _context.Pessoa.Any(c => c.Name == pessoa.Name);
        private bool PessoaExistsById(Pessoa pessoa) =>  _context.Pessoa.Any(c => c.Id == pessoa.Id);
    }
}