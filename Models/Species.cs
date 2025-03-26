using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishReportApi.Models
{
  public class Species
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Habitat cannot be longer than 100 characters.")]

    public string? Habitat { get; set; }
    [Range(0.0, 500.0, ErrorMessage = "Length must be between 1 and 500 cm.")]
    public int Length { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Population must be 0 or greater.")]
    public int? Population { get; set; }
    [Range(1, 60, ErrorMessage = "Lifespan must be at least 1 year.")]
    public int Lifespan { get; set; }
    [Range(0.01, 200.00, ErrorMessage = "Price must be between $0.01 and $200.00.")]
    public decimal Price { get; set; }
  }
}