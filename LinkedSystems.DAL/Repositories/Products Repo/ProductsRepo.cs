
namespace LinkedSystems.DAL.Repositories.Products_Repo;

public class ProductsRepo : GenericRepo<Product> , IProductsRepo
{
    #region Fields
    private readonly LinkedSystemsContext _context;
    #endregion

    #region Ctor
    public ProductsRepo(LinkedSystemsContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Methods

    #endregion
}
