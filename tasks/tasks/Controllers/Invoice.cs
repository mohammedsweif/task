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
    public class InvoiceController : ControllerBase
    {
        private readonly UnitOfWork _UnitOfWork;
        public InvoiceController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork as UnitOfWork;
        }
        [HttpGet("getall")]
        public IActionResult getall()
        {
            var all = _UnitOfWork._invoiceReposatory.getall();
         
            return Ok(all);// products);
        }
        [HttpGet("getallinvoices")]
        public IActionResult getallinvoices()
        {
            var all = _UnitOfWork._invoiceReposatory.getallwithname();

            return Ok(all);// products);
        }
        [HttpPost("postone")]
        public IActionResult postone(Invoice invoice)
        {
            
            _UnitOfWork._invoiceReposatory.add(invoice);
            Product p = _UnitOfWork._ProductReposatory.getone(invoice.ItemId);
            _UnitOfWork._ProductReposatory.updatemin(invoice.Quantity, p);
            return Ok();
        }

    }
}
