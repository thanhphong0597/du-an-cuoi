using Doan.Entities;
using Doan.Models;

namespace Doan.Interfaces
{
    public interface ICategory
    {
        public Task<IEnumerable<CategoryModel>> GetCategories();
        public Task<CategoryModel> GetCategory(int id);
        public Task<int> AddCategory(CategoryModel model);
        public Task UpdateCategory(int id, CategoryModel model);
        public Task DeleteCategory(int id);

    }

    public interface IGeneralProduct
    {
        public Task<IEnumerable<GeneralProductModel>> GetAllGeneralProducts();
        public Task<GeneralProduct> GetGeneralProduct(int id);
        public Task<int> AddGeneralProduct(GeneralProductModel model);
        public Task UpdateGeneralProduct(int id, GeneralProductModel model);
        public Task DeleteGeneralProduct(int id);

    }
    public interface IProduct
    {
        public Task<IEnumerable<ProductModel>> GetAllProducts();

    }

}
