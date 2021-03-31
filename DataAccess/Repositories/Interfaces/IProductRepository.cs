using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
   public interface IProductRepository:IRepository<Product>
    {
        Product ForProduct();
    }
}
