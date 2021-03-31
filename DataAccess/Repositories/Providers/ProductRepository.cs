using Data.Contexts;
using Data.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Providers
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MasterContext context):base(context)
        {

        }
        public Product ForProduct()
        {
            return masterContext.Products.Find(16);
        }

        public MasterContext masterContext { get { return DbContext as MasterContext; } }
    }
}
