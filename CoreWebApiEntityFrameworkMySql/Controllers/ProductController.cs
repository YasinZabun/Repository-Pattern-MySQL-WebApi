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
    public class ProductController : ControllerBase
    {
        [HttpGet("Get/{id}")]
        public Product Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                return uow.ProductRepository.GetById(id);
            }
        }
        [HttpGet("GetAll")]
        public List<Product> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                return uow.ProductRepository.GetAll().ToList();
            }
        }
        [HttpPost("Add")]
        public List<Product> Add(Product product)
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                uow.ProductRepository.Add(product);
                uow.complete();
                return uow.ProductRepository.GetAll().ToList();
            }
        }
        [HttpDelete("Delete")]
        public List<Product> Delete(Product product)
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                uow.ProductRepository.Delete(product);
                uow.complete();
                return uow.ProductRepository.GetAll().ToList();
            }
        }
        [HttpPut("Update")]
        public List<Product> Update(Product product)
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                uow.ProductRepository.Update(product);
                uow.complete();
                return uow.ProductRepository.GetAll().ToList();
            }
        }
        [HttpPost("Find")]
        public Product Find()
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.Contexts.MasterContext()))
            {
                return uow.ProductRepository.ForProduct();
            }

        }
    }
}
