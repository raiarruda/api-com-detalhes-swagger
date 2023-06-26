
using ApiComDetalhes.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiComDetalhes.Models;

using ApiComDetalhes.ModelViews;

namespace ApiComDetalhes.Controllers;

// [ApiController] // para habilitar a validação padrão
[Route("/tarefas")]
public class TasksController : ControllerBase
{
    public TasksController(BancoDadosContexto context)
    {
        this._context = context;
    }

    private BancoDadosContexto _context;

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var tasks = await _context.Tarefas.ToListAsync();
        return StatusCode(200, tasks);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Models.Task task)
    {

        if (task == null)
            return StatusCode(404);

        _context.Tarefas.Add(task);
        await _context.SaveChangesAsync();

        return StatusCode(201, task);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Show([FromRoute] int id)
    {

        var task = await _context.Tarefas.FindAsync(id);
        if (task is null) return StatusCode(404, new ApiError { Message = "O registro não foi encontrado", StatusCode = 404 });

        return StatusCode(200, task);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] Models.Task task)
    {

        var task_found = await _context.Tarefas.FindAsync(id);
        if (task_found is null) return StatusCode(404, new ApiError { Message = "O registro não foi encontrado", StatusCode = 404 });
        foreach (var property in typeof(Models.Category).GetProperties())
        {
            var newValue = property.GetValue(task);
            var oldValue = property.GetValue(task_found);
            if (newValue != null && !newValue.Equals(oldValue) && property.Name != "Id")
            {
                property.SetValue(task_found, newValue);
            }
        }

        _context.Tarefas.Update(task_found);
        await _context.SaveChangesAsync();

        return StatusCode(200, task_found);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Destroy([FromRoute] int id)
    {

        var task = await _context.Tarefas.FindAsync(id);
        if (task is null) return StatusCode(404, new ApiError { Message = "O registro não foi encontrado", StatusCode = 404 });

        _context.Tarefas.Remove(task);
        await _context.SaveChangesAsync();

        return StatusCode(204);
    }
}