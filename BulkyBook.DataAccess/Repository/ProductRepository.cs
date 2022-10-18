using BulkyBook.DataAccess.Repository.IRepolository;
using BulkyBook.Models;
using BulkyBookWeb.Controllers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        void IProductRepository.Update(Product obj)
        {
           var objFromDb =  _db.Products.FirstOrDefault(product=>product.Id == obj.Id);
            if (objFromDb !=null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price100 = obj.Price100;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if (objFromDb.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL; 
                }
            }
        }
    }
}
