using Microsoft.AspNetCore.Mvc;
using MyIF.Models;
using MyIF.Services;

namespace MyIF.Controllers;

[ApiController]
[Route("cursos")]
public class CursoController : ControllerBase
{
  private readonly CursoService _cursoService;
  public CursoController([FromServices] CursoService cursoService)
  {
    _cursoService = cursoService;
  }

  [HttpGet]
  public ActionResult<List<Curso>> GetCurso()
  {
    var cursos = _cursoService.GetCursos();
    return Ok(cursos);
  }

  [HttpGet("{id:int}")]
  public ActionResult<Curso> GetCurso([FromRoute] int id)
  {
    Curso curso = _cursoService.GetCurso(id);

    if (curso is null)
      return NotFound();

    return Ok(curso);
  }

  [HttpPost]
  public ActionResult<Curso> PostCurso([FromBody] Curso c)
  {
    var curso = _cursoService.PostCurso(c);
    return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
  }

  [HttpPut("{id:int}")]
  public ActionResult<Curso> PutCurso([FromRoute] int id, [FromBody] Curso c)
  {
    var curso = _cursoService.PutCurso(id, c);

    if (curso is null)
      return NotFound();

    return Ok(curso);
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteCurso([FromRoute] int id)
  {
    try
    {
      _cursoService.DeleteCurso(id);
      return NoContent();
    }
    catch (Exception)
    {
      return NotFound();
    }
  }
}
