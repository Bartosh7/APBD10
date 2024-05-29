namespace APBD10.RsponseModels;

public class GetAccountResponseModel
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string? email { get; set; }
    public string? phone { get; set; }
    public string role { get; set; }
    public IEnumerable<GetShoppingCartResponseModel> cart { set; get; }
    



    
    
}