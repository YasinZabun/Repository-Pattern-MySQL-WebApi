using Data.Contexts;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private MasterContext _masterContext;
        public UnitOfWork(MasterContext masterContext)
        {
            _masterContext = masterContext;
            
        }
        private IProductRepository productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_masterContext);
                }
                return productRepository;
            }
        }
        private ICostumerRepository costumerRepository;
        public ICostumerRepository CostumerRepository 
        { 
            get 
            {
                if (costumerRepository == null)
                {
                    costumerRepository = new CostumerRepository(_masterContext);
                }
                return costumerRepository;
            }
        }

        public int complete()
        {
            return _masterContext.SaveChanges();
        }

        public void Dispose()
        {
            _masterContext.Dispose();
        }
    }
}
