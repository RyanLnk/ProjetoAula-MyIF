using Microsoft.EntityFrameworkCore;
using MyIF.Models;

namespace MyIF.Data;

public class MyIFContext : DbContext
{

  //Construtor da maneira que o WEBAPI espera
  public MyIFContext(DbContextOptions<MyIFContext> options) : base(options)
  {

  }

  //Propriedades que representam cada tabela do banco de dados
  public DbSet<Curso> Cursos { get; set; }

}
