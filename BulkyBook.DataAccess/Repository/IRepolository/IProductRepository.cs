﻿using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepolository
{
    public interface IProductRepository:IRepository<Product>
    {
        void Update(Product obj);
    }
}
