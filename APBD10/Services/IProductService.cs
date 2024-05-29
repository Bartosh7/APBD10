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
        public void CheckData(PostProductModel productData)
        {
            if (string.IsNullOrWhiteSpace(productData.productName))
            {
                throw new BadRequestException("Nazwa produktu nie moze byc nullem ani pusta.");
            }

            if (productData.productWeight <= 0)
            {
                throw new BadRequestException("Waga produktu musi być większa niż zero.");
            }

            if (productData.productWidth <= 0)
            {
                throw new BadRequestException("Szerokość produktu musi być większa niż zero.");
            }

            if (productData.productHeight <= 0)
            {
                throw new BadRequestException("Wysokość produktu musi być większa niż zero.");
            }

            if (productData.productDepth <= 0)
            {
                throw new BadRequestException("Głębokość produktu musi być większa niż zero.");
            }
            
            if (productData.productWeight > 999.99m)
            {
                throw new BadRequestException("Waga produktu nie może być większa niż 999.99.");
            }

            if (productData.productWidth > 999.99m)
            {
                throw new BadRequestException("Szerokość produktu nie może być większa niż 999.99.");
            }

            if (productData.productHeight > 999.99m)
            {
                throw new BadRequestException("Wysokość produktu nie może być większa niż 999.99.");
            }

            if (productData.productDepth > 999.99m)
            {
                throw new BadRequestException("Głębokość produktu nie może być większa niż 999.99.");
            }
        }


        public async Task<int> PostProduct(PostProductModel productData)
        {
            CheckData(productData);

            foreach (var categoryId in productData.productCategories)
            {
                var category = await context.Categories
                    .Where(c => c.CategoryID == categoryId)
                    .FirstOrDefaultAsync();

                if (category == null)
                {
                    throw new BadRequestException($"Nie ma kategorii o id: {categoryId}");
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