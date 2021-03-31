using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICostumerRepository:IRepository<Costumer>
    {
        Costumer ForCostumer();
    }
}
