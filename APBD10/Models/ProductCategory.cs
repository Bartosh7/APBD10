using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;
[Table("Product_Categories")]
public class ProductCategory
{
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int ProductId { get; set; }
    [ForeignKey("Category")]
    [Column("FK_category")]
    public int CategoryId { get; set; }

    public Product Product { get; set; }
    public Category Category { get; set; }
}