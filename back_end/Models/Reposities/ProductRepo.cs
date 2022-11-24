using Doan.Interfaces;
using Doan.Service;
using Microsoft.EntityFrameworkCore;

namespace Doan.Models.Reposities
{
    public class ProductRepo : IProduct
    {
        protected readonly Context db;

        public ProductRepo(Context db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var data = await (from p in db.Products
                              join g in db.GeneralProducts on p.ProductID equals g.ID
                              join c in db.Colors on p.ColorID equals c.ID
                              join s in db.Sizes on p.SizeID equals s.ID
                              select new ProductModel
                              {
                                ID = g.ID.ToString() + "_" + s.Name + "_" + c.Name,
                                Color = c.Name,
                                Size=s.Name,
                                Ima=p.Ima,
                                Product=g.Name,
                                Stock=p.Stock
                              }).ToListAsync();
            return data;
        }
    }
}
