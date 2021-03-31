using Data.Contexts;
using Data.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Providers
{
    public class CostumerRepository : Repository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(MasterContext context) : base(context)
        {
            
        }
        public Costumer ForCostumer()
        {
            return masterContext.Costumers.Find(100);
        }

        public MasterContext masterContext { get { return DbContext as MasterContext; } }
    }
}
