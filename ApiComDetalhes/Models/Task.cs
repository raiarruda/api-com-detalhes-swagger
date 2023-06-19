
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiComDetalhes.Models;
[Table("tasks")]
public record Task
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [JsonPropertyName("descricao")]
    [Column("description")]
    [Required(ErrorMessage = "A descrição não pode ser vazia")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("dificuldade")]
    [Column("level")]
    [MaxLength(50)]
    [Required(ErrorMessage = "A dificuldade não pode ser vazia")]
    public string Level { get; set; } = null!;
    [JsonPropertyName("categoria")]
    public Category Category { get; } = null!;
    [Column("id_category")]
    [Required(ErrorMessage = "A categoria não pode ser vazia")]
    public int IdCategory { get; set; }

    [JsonPropertyName("finalizada")]
    [Column("is_done")]
    public bool Done;
}
