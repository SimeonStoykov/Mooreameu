using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooreameu.Data.Repositories;
using Mooreameu.Model;

namespace Mooreameu.Data.UnitOfWork
{
    public interface IMooreameuData
    {
        IRepository<User> Users { get; }

        void SaveChanges();
    }
}
