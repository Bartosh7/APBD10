using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;
[Table("Shopping_Carts")]
public class ShoppingCart
{   
    [ForeignKey("Account")]
    [Column("FK_account")] 
    public int AccountId { get; set; }
    
    [ForeignKey("Product")]
    [Column("FK_product")] 
    public int ProductId { get; set; }

    public int ShoppingCartAmount { get; set; }

    public Account Account { set; get; }
    public Product Product { get; set; }
}