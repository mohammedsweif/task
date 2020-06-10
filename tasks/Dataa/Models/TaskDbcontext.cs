using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDate.Models
{
   public class TaskDbcontext:DbContext
    {
        

        public TaskDbcontext(DbContextOptions<TaskDbcontext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> invoices { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product {
                    Id=1,
                  ProName="apple",
                  Quantity=100,
                  Unitprice = 10 },
             new Product
             {
                 Id = 2,
                 ProName = "orange",
                 Quantity = 200,
                 Unitprice = 12
             }, new Product
             {
                 Id = 3,
                 ProName = "banana",
                 Quantity = 300,
                 Unitprice = 3
             } );
        }
        
    }
}
