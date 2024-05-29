using APBD10.Contexts;
using APBD10.RsponseModels;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Services;

public interface IAccountService
{
   Task<GetAccountResponseModel?> GetAccountByIdAssync(int id);
}

public class AccountService(DatabaseContext context) : IAccountService
{
   public async Task<GetAccountResponseModel?> GetAccountByIdAssync(int id)
   {
      var response = await context.Accounts
         .Where(a => a.AccountId == id)
         .Select(a => new GetAccountResponseModel
         {
            firstName = a.AccountFirstName,
            lastName = a.AccountLastName,
            email  = a.AccountEmail,
            phone = a.AccountPhone,
            role = a.Role.RoleName,
            cart = a.ShoppingCarts.Select(sc => new GetShoppingCartResponseModel
            {
               productId = sc.ProductId,
               productName = sc.Product.ProductName,
               amount = sc.ShoppingCartAmount
            })
         })
         .FirstOrDefaultAsync();

      if (response == null)
      {
         throw new NotFoundException($"Account with that id:{id} does not exist");
      }


      return response;



   }
}