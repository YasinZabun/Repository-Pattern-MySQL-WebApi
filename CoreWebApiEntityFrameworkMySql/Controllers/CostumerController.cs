using Data.Models;
using DataAccess.Repositories.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiEntityFrameworkMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        [HttpGet("Get/{id}")]
        public Costumer Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                return uow.CostumerRepository.GetById(id);
            }
        }

        [HttpGet("GetAll")]
        //[HttpGet("/")]
        public List<Costumer> GetAll()
        {
            using(UnitOfWork uow=new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                return uow.CostumerRepository.GetAll().ToList();
            }
        }
        [HttpGet("GetAllById/{id}")]
        public List<Product> GetAllById(int id)
        {
            using(UnitOfWork uow=new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                return uow.ProductRepository.GetAll(p => p.OwnerId == id).ToList(); ;
            }
        }
        [HttpPost("Add")]
        public List<Costumer> Add(Costumer costumer)
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.Contexts.MasterContext())) 
            {
                uow.CostumerRepository.Add(costumer);
                uow.complete();
                return uow.CostumerRepository.GetAll().ToList();
            }
        }
        [HttpDelete("Delete")]
        public List<Costumer> Delete(Costumer costumer)
        {
            using(UnitOfWork uow =new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                uow.CostumerRepository.Delete(costumer);
                uow.complete();
                return uow.CostumerRepository.GetAll().ToList();
            }
        }
        [HttpPut("Update")]
        public List<Costumer> Update(Costumer costumer)
        {
            using(UnitOfWork uow=new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                uow.CostumerRepository.Update(costumer);
                uow.complete();
                return uow.CostumerRepository.GetAll().ToList();
            }
        }
        [HttpPost("Find")]
        public Costumer Find()
        {
            using(UnitOfWork uow=new UnitOfWork(new Data.Contexts.MasterContext())) 
            {
                return uow.CostumerRepository.ForCostumer();
            }
                
        }
    }
}
