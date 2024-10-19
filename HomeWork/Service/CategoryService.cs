
using HomeWork.Interface;
using HomeWork.Models;

namespace HomeWork.Service
{
    public class CategoryService : ICategory
    {

        public static List<Category> categories = new List<Category>();
        public async Task<IEnumerable<Category>> GetAllGategory()
        {
            return await Task.FromResult(categories);
        }  

        public async Task<Category> GetCategory(int id)
        {
            var MyCategoey = categories.FirstOrDefault(c => c.Id == id);
            if (MyCategoey != null)
            {
                return await Task.FromResult(MyCategoey);
            }
            return await Task.FromResult<Category>(null);
        }
        public async Task<Category> CreateCategory(Category category)
        {
            if (category != null)
            {
                categories.Add(category);
                return await Task.FromResult(category);
            }

            return await Task.FromResult<Category>(null);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var IsDeleted = categories.FirstOrDefault(c => c.Id == id);

            if (IsDeleted != null)
            {
                categories.Remove(IsDeleted);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

       

        public async Task<Category> UpdateCategory(Category category, int id)
        {
            var newCategory = categories.FirstOrDefault(c => c.Id == id);

            if (newCategory != null)
            {
                newCategory.Name = category.Name;
                return await Task.FromResult(newCategory);
            }
            return await Task.FromResult<Category>(null);
        }
    }
}
