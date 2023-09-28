using System.ComponentModel.DataAnnotations;

public class Carta
{
    [Required]
    [StringLength(255, MinimumLength = 3)]
    public string NomeCrianca { get; set; }

    [Required]
    public string Endereco { get; set; }

    [Required]
    [Range(0, 15)]
    public int IdadeCrianca { get; set; }

    [Required]
    [StringLength(500)]
    public string TextoCarta { get; set; }
}
