using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;
[Table("Catgories")]
public class Category
{
    [Key]
    [Column("PK_Category")]
    public int CategoryID { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string CategoryName { get; set; }

    private IEnumerable<ProductCategory> ProductCategories { set; get; }
} 