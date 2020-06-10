using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskDate.Models;
using TaskRepos;

namespace inferastructure.service
{
    public class InvoiceReposatory : GenaricReposatoery<Invoice>
    {
        TaskDbcontext _taskdbcontext;
        public InvoiceReposatory(TaskDbcontext taskdbcontext) : base(taskdbcontext)
        {
            _taskdbcontext = taskdbcontext;
        }
        public List<InvoicesViewModel> getallwithname()
        {
            List<InvoicesViewModel> invoices =_taskdbcontext.invoices.Include(e=>e.product).Select(e => new
            InvoicesViewModel{
                name = e.product.ProName,
                quantity = e.Quantity,
                total = e.Total,
                unitprise = e.UnitPrice,
                id = e.Id,
                description=e.Description
            }).ToList();
            return invoices;

        }
    }
}
