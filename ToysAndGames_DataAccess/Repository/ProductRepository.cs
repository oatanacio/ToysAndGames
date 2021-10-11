using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames_DataAccess.Contracts;
using ToysAndGames_DataAccess.Data;
using ToysAndGames_Models.Models;

namespace ToysAndGames_DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Product>> FindAll()
        {
            var productTypes = await _db.Products.ToListAsync();
            return productTypes;
        }

        public async Task<Product> FindById(int id)
        {
            var productTypes = await _db.Products.FindAsync(id);
            return productTypes;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Products.OrderByDescending(c => c.Price).ToList();
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _db.Products.AnyAsync(q => q.Product_Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        async Task<bool> IRepositoryBase<Product>.Create(Product entity)
        {
            await _db.Products.AddAsync(entity);
            return await Save();
        }

        async Task<bool> IRepositoryBase<Product>.Delete(Product entity)
        {
            _db.Products.Remove(entity);
            return await Save();
        }

        async Task<bool> IRepositoryBase<Product>.Update(Product entity)
        {
            _db.Products.Update(entity);
            return await Save();
        }
    }
}
