using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.UnitOfWorks
{
    public interface IUnitOfWork:IDisposable
    {
        ICostumerRepository CostumerRepository { get; }
        IProductRepository ProductRepository { get; }
        int complete();
    }
}
