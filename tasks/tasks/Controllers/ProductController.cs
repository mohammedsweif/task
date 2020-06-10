using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskDate.Models;

namespace tasks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly UnitOfWork _UnitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork as UnitOfWork;
        }
        [HttpGet("getall")]
        public IActionResult getall()
        {
           List<Product> products = _UnitOfWork._ProductReposatory.getall().ToList();
            return Ok(products);
        }
        [HttpGet("postone")]
        public IActionResult postone(Product p)
        {
            
            _UnitOfWork._ProductReposatory.add(p);
            return Ok();
        }
    }
}
