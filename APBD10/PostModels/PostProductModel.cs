using System.ComponentModel.DataAnnotations;

namespace APBD10.PostModels;

public class PostProductModel
{
    [Required]
    public string productName { get; set; }
    [Required]
    public decimal productWeight { get; set; }
    [Required]
    public decimal productWidth { get; set; }
    [Required]
    public decimal productHeight { get; set; }
    [Required]
    public decimal productDepth { get; set; }
    [Required]
    public List<int> productCategories { get; set; }
}