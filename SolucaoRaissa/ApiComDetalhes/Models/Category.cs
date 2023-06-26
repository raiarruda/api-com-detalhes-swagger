using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiComDetalhes.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        [Column("name")]
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        public string Name { get; set; } = default!;
    }
}