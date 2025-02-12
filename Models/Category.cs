using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models;

public class Category{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(250)]
    public required string Description { get; set; }
    public IList<Product>? Products { get; set; }
}