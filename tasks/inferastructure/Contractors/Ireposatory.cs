using System;
using System.Collections.Generic;
using System.Text;

namespace TaskRepos.Contractors
{
    public interface Ireposatory<t> where t:class
    {
         
        IEnumerable<t> getall();
        t add(t tentity);
        bool update(t tentity);
        bool delete(t tentity);

    }
}
