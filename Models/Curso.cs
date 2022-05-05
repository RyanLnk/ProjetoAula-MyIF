using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyIF.Models;

public class Curso
{
  [Required]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "varchar(255)")]
  public string Nome { get; set; }

  [Required]
  [Column(TypeName = "text")]
  public string Descricao { get; set; }

  [Required]
  public int CargaHoraria { get; set; }

  [Required]
  public DateTime DataCriacao { get; set; }

  [Required]
  public DateTime DataAtualizacao { get; set; }

  [Required]
  [Column(TypeName = "decimal(12,2)")]
  public decimal Preco { get; set; }
}
