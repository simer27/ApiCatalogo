using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.Categorias.ToList();
            if (categorias is null)
            {
                return NotFound("Categotias não encontradas...");
            }

            return Ok(categorias);
        }

        [HttpGet("{id:int}")]

        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault( c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            return categoria;
        }
    }
}
