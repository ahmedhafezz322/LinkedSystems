using LinkedSystems.BL.DTOs;
namespace LinkedSystems.BL;
public interface IProductsManager
{
    List<ProductReadDTO> GetAll();
    ProductReadDTO GetById(Guid id);
    ProductReadDTO Add(ProductAddDTO productAddDTO);
    bool Update(ProductUpdateDTO productUpdateDTO);
    void Delete(Guid id);
}
