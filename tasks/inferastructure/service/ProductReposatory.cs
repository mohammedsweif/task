using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskDate.Models;
using TaskRepos;

namespace Infrastructure.service
{
    public class ProductReposatory : GenaricReposatoery<Product>
    {
        TaskDbcontext _taskdbcontext;
        public ProductReposatory(TaskDbcontext taskdbcontext) : base(taskdbcontext)
        {
            _taskdbcontext = taskdbcontext;
        }
        public Product updatemin(int num,Product p)
        {
            p.Quantity -= num;
            update(p);
            return p;
        }
        public Product getone(int id)
        {
            return _taskdbcontext.Products.FirstOrDefault(e => e.Id == id);
        }

    }
}
