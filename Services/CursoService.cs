using Microsoft.AspNetCore.Mvc;
using MyIF.Data;
using MyIF.Models;

namespace MyIF.Services;

public class CursoService
{
  private readonly MyIFContext _context;

  public CursoService([FromServices] MyIFContext context)
  {
    _context = context;
  }

  public List<Curso> GetCursos()
  {
    return _context.Cursos.ToList();
  }

  public Curso GetCurso(int id)
  {
    var curso = _context.Cursos.SingleOrDefault(c => c.Id == id);

    if (curso is null)
      //return NotFound();
      return null;

    return curso;
  }

  public Curso PostCurso(Curso curso)
  {
    var dataAgora = DateTime.Now;
    curso.DataCriacao = dataAgora;
    curso.DataAtualizacao = dataAgora;

    _context.Cursos.Add(curso);
    _context.SaveChanges();

    return curso;
  }

  public Curso PutCurso(int id, Curso c)
  {
    var curso = _context.Cursos.SingleOrDefault(c => c.Id == id);

    if (curso is null)
      return null;

    curso.Nome = c.Nome;
    curso.Descricao = c.Descricao;
    curso.Preco = c.Preco;
    curso.CargaHoraria = c.CargaHoraria;
    curso.DataAtualizacao = DateTime.Now;

    _context.SaveChanges();

    return curso;
  }
}
