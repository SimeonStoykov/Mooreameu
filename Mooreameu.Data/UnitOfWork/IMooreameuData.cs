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

        IRepository<Contest> Contests {get; }

        IRepository<ProfilePicture> ProfilePictures { get; }

        IRepository<Picture> Pictures { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Reward> Rewards { get; } 

        void SaveChanges();
    }
}
