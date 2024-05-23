﻿using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {            
            return _context.Categorias.Include(p => p.Produtos).AsNoTracking().ToList();
        }


        [HttpGet("produtos/{id:int}")]
        public ActionResult<Categoria> GetCategoriasProdutos(int id)
        {
            var cProdutos = _context.Categorias.AsNoTracking().Include(p => p.Produtos).FirstOrDefault(c => c.CategoriaId == id);

            if (cProdutos == null)
            {
                return NotFound("Categoria Não encontrada...");
            }
            return cProdutos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();
            if (categorias is null)
            {
                return NotFound("Categotias não encontradas...");
            }

            return Ok(categorias);
        }


        [HttpGet("{id:int}", Name ="ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault( c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            return categoria;
        }


        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }


        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Categoria categoria) 
        {
            if ( id != categoria.CategoriaId)
            {
                BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {

            var categoria = _context.Categorias.FirstOrDefault( c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound("Categoria não localizada...");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }
}
