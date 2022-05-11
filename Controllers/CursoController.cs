using Microsoft.AspNetCore.Mvc;
using MyIF.Data;
using MyIF.Models;

namespace MyIF.Controllers;

[ApiController]
[Route("cursos")]
public class CursoController : ControllerBase
{
  [HttpGet]
  public ActionResult<List<Curso>> GetCursos([FromServices] MyIFContext context)
  {
    return Ok(context.Cursos.ToList());
  }

  [HttpGet("{id:int}")]
  public ActionResult<Curso> GetCurso([FromRoute] int id, [FromServices] MyIFContext context)
  {
    var curso = context.Cursos.SingleOrDefault(c => c.Id == id);

    if (curso is null)
      return NotFound();

    return Ok(curso);
  }

  [HttpPost]
  public ActionResult<Curso> PostCurso([FromBody] Curso curso, [FromServices] MyIFContext context)
  {
    var dataAgora = DateTime.Now;
    curso.DataCriacao = dataAgora;
    curso.DataAtualizacao = dataAgora;

    context.Cursos.Add(curso);
    context.SaveChanges();
    return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
  }
}
