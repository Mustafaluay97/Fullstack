using HomeWork.Models;

namespace HomeWork.Interface
{
    public interface ICategory
    {

        Task<IEnumerable<Category>> GetAllGategory();

        Task<Category> CreateCategory(Category category);
        Task<Category> GetCategory(int id);

        Task<Category> UpdateCategory(Category category,int id);

        Task<bool> DeleteCategory(int id);
    }
}
