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
    public string Name { get; set; }
    [Required]
    [StringLength(100)]
    public string Habitat { get; set; }
    [Range(0.0, 500.0)]
    public int Length { get; set; }
    public int? Population { get; set; }
    public int Lifespan { get; set; }
  }
}