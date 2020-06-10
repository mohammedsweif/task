using inferastructure.service;
using Infrastructure.Contractors;
using Infrastructure.service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskDate.Models;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbcontext _TaskDbcontext;
        public ProductReposatory _ProductReposatory { get; set; }
        public InvoiceReposatory _invoiceReposatory { get; set; }

        public UnitOfWork(TaskDbcontext TaskDbcontext)
        {
            _TaskDbcontext = TaskDbcontext;
            _ProductReposatory = new ProductReposatory(_TaskDbcontext);
            _invoiceReposatory = new InvoiceReposatory(_TaskDbcontext);
        }
        public  void commit()
        {
             _TaskDbcontext.SaveChanges();
        }
        public void Dispose()
        {
            commit();
            _TaskDbcontext.Dispose();
        }
    }
}
