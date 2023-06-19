
using ApiComDetalhes.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiComDetalhes.Models;

using ApiComDetalhes.ModelViews;

namespace ApiComDetalhes.Controllers;

// [ApiController] // para habilitar a validação padrão
[Route("/categorias")]
public class CategoryController : ControllerBase
{

    private BancoDadosContexto _context;

    public CategoryController(BancoDadosContexto context)
    {
        this._context = context;
    }


    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var categories = await _context.Categorias.ToListAsync();
        return StatusCode(200, categories);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Models.Category category)
    {

        if (category == null)
            return StatusCode(404);

        _context.Categorias.Add(category);
        await _context.SaveChangesAsync();

        return StatusCode(201, category);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Show([FromRoute] int id)
    {

        var category = await _context.Categorias.FindAsync(id);
        if (category is null) return StatusCode(404, new ApiError { Message = "O registro não foi encontrado", StatusCode = 404 });

        return StatusCode(200, category);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] Models.Category category)
    {

        var category_found = await _context.Categorias.FindAsync(id);
        if (category_found is null) return StatusCode(404, new ApiError { Message = "O registro não foi encontrado", StatusCode = 404 });


        _context.Categorias.Update(category);
        await _context.SaveChangesAsync();

        return StatusCode(200, category_found);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Destroy([FromRoute] int id)
    {

        var category = await _context.Categorias.FindAsync(id);
        if (category is null) return StatusCode(404, new ApiError { Message = "O registro não foi encontrado", StatusCode = 404 });

        _context.Categorias.Remove(category);
        await _context.SaveChangesAsync();

        return StatusCode(204);
    }
}