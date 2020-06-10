using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contractors
{
   public  interface IUnitOfWork :IDisposable
    {
        void commit();
       
    }
}
