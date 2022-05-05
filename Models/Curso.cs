namespace MyIF.Models;

public class Curso
{
  public int Id { get; set; }
  public string Nome { get; set; }
  public string Descricao { get; set; }
  public int CargaHoraria { get; set; }
  public DateTime DataCriacao { get; set; }
  public DateTime DataAtualizacao { get; set; }
  public decimal Preco { get; set; }
}
