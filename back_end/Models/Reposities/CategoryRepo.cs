using Doan.Entities;
using Doan.Interfaces;
using Doan.Service;
using Microsoft.EntityFrameworkCore;

namespace Doan.Models.Reposities
{
    public class CategoryRepo : ICategory
    {

        private readonly Context db;

        public CategoryRepo(Context db)
        {
            this.db = db;
        }

        public async Task<int> AddCategory(CategoryModel model)
        {
            var newCategory = new Category
            {
                //ID = model.ID,
                Name = model.Name,
                 
            };
            var s = db.Categories.Add(newCategory);
            await db.SaveChangesAsync();
            return newCategory.ID;
        }

        public async Task DeleteCategory(int id)
        {
            var deleteCategory = await db.Categories!.SingleOrDefaultAsync(c => c.ID == id);
            if(deleteCategory != null)
            {
                db.Categories!.Remove(deleteCategory);
                await db.SaveChangesAsync();
            }
        }

        //httpget
        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var data = await (from c in db.Categories
                              select new CategoryModel
                              {
                                  ID = c.ID,
                                  Name = c.Name
                              }).ToListAsync();
            return data;
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            var data = await db.Categories!.FindAsync(id);

            return new CategoryModel
            {
                ID = data.ID,
                Name = data.Name
            };
           
        }

        public async Task UpdateCategory(int id, CategoryModel model)
        {
            if(id == model.ID)
            {
                var updateCategory =await  db.Categories!.FirstOrDefaultAsync(c => c.ID == id);
                updateCategory.Name = model.Name;
                db.Categories!.Update(updateCategory);
                await db.SaveChangesAsync();
            }
        }
    }
}
