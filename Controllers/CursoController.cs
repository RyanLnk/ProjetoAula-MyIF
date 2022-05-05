using Microsoft.AspNetCore.Mvc;
using MyIF.Data;
using MyIF.Models;

namespace MyIF.Controllers;

[ApiController]
[Route("cursos")]
public class CursoController : ControllerBase
{
  [HttpGet]
  public List<Curso> GetCursos([FromServices] MyIFContext context)
  {
    return context.Cursos.ToList();
  }

  [HttpGet("{id:int}")]
  public Curso GetCurso([FromRoute] int id, [FromServices] MyIFContext context)
  {
    var curso = context.Cursos.SingleOrDefault(c => c.Id == id);
    return curso;
  }

  [HttpPost]
  public Curso PostCurso([FromBody] Curso curso, [FromServices] MyIFContext context)
  {
    var dataAgora = DateTime.Now;
    curso.DataCriacao = dataAgora;
    curso.DataAtualizacao = dataAgora;

    context.Cursos.Add(curso);
    context.SaveChanges();
    return curso;
  }
}
