using Doan.Entities;
using Doan.Interfaces;
using Doan.Service;
using Microsoft.EntityFrameworkCore;

namespace Doan.Models.Reposities
{
    public class GeneralProductRepo : IGeneralProduct
    {
        protected readonly Context db;

        public GeneralProductRepo(Context db)
        {
            this.db = db;
        }

        public async Task<int> AddGeneralProduct(GeneralProductModel model)
        {
            //var p = new GeneralProduct
            //{
            //    Name = model.Name,
            //    Count = model.Count,
            //    Description = model.Description,
            //    Price = model.Price,
            //    Rate = model.Rate,
            //    Title = model.Title,  
            //    ID = model.ID,
            //    CategoryID = model.CategoryID,
            //};
            //var q = await db.Categories.FirstOrDefaultAsync(a=>a.ID == model.CategoryID);
            //p.Category=q.
            return 1;
        }

        public Task DeleteGeneralProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GeneralProductModel>> GetAllGeneralProducts()
        {
            var data = await (from p in db.GeneralProducts
                              select new GeneralProductModel
                              {
                                  ID = p.ID,
                                  Count = p.Count,
                                  Name = p.Name,
                                  Description = p.Description,
                                  Price = p.Price,
                                  Rate = p.Rate,
                                  Title = p.Title,
                                  CategoryID = p.CategoryID,
                                  Ima=p.Ima
                              }).ToListAsync();

            foreach(var i in data)
            {
                var q = await (from a in db.Categories
                        where a.ID == i.CategoryID
                        select a.Name).FirstOrDefaultAsync();

                i.Category = q;

                var q2 = await (from p in db.Products
                                join s in db.Sizes on p.SizeID equals s.ID
                                join c in db.Colors on p.ColorID equals c.ID
                                join g in db.GeneralProducts on p.ProductID equals g.ID
                                where p.ProductID==i.ID
                                select new ProductModel
                                {
                                    ID = g.ID.ToString()+"_"+s.Name+"_"+c.Name,
                                    Color = c.Name,
                                    Size = s.Name,
                                    Stock = p.Stock,
                                    Ima = p.Ima,
                                    Product = g.Name
                                }).ToListAsync();
                i.Products = q2;
            }
            return data;
        }

        public Task<GeneralProduct> GetGeneralProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGeneralProduct(int id, GeneralProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
