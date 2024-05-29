using APBD10.Contexts;
using APBD10.Models;
using APBD10.PostModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace APBD10.Services
{
    public interface IProductService
    {
        Task<int> PostProduct(PostProductModel product);
    }

    public class ProductService(DatabaseContext context) : IProductService
    {
        

        

        public async Task<int> PostProduct(PostProductModel productData)
        {
            
            foreach (var categoryId in productData.productCategories)
            {
                var category = await context.Categories
                    .Where(c => c.CategoryID == categoryId)
                    .FirstOrDefaultAsync();

                if (category == null)
                {
                    throw new NotFoundException($"Nie ma kategorii o id: {categoryId}");
                }
            }

            
            var product = new Product
            {
                ProductName = productData.productName,
                ProductWeight = productData.productWeight,
                ProductWidth = productData.productWidth,
                ProductHeight = productData.productHeight,
                ProductDepth = productData.productDepth
            };

            
            context.Products.Add(product);
            await context.SaveChangesAsync();

            
            foreach (var categoryId in productData.productCategories)
            {
                var productCategory = new ProductCategory
                {
                    ProductId = product.ProductId,
                    CategoryId = categoryId
                };
                context.ProductCategories.Add(productCategory);
            }

            
            await context.SaveChangesAsync();

            return product.ProductId;
        }
    }
}
