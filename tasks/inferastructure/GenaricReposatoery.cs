using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskDate.Models;
using TaskRepos.Contractors;

namespace TaskRepos
{
   public  class GenaricReposatoery<t> : Ireposatory<t> where t : class
    {
        private readonly TaskDbcontext _taskdbcontext;
        private readonly DbSet<t> _Dbset;
        public GenaricReposatoery(TaskDbcontext taskdbcontext)
        {
             
            _taskdbcontext = taskdbcontext;
            _Dbset = _taskdbcontext.Set<t>();
        }
        public t add(t tentity)
        {
            _Dbset.Add(tentity);
            return tentity;
        }

        public bool delete(t tentity)
        {
            _Dbset.Remove(tentity);
            return true;
        }

        public IEnumerable<t> getall()
        {
            return _Dbset.ToList();
        }

        public bool update(t tentity)
        {
            _Dbset.Attach(tentity);
            _taskdbcontext.Entry(tentity).State = EntityState.Modified;
            return true;
        }
    }
}
