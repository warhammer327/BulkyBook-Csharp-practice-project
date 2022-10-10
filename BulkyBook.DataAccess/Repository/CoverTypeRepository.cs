using BulkyBook.DataAccess.Repository.IRepolository;
using BulkyBook.Models;
using BulkyBookWeb.Controllers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        void ICoverTypeRepository.Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
