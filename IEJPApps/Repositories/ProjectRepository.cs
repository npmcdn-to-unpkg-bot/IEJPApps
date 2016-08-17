using System;
using System.Collections.Generic;
using System.Linq;
using IEJPApps.Models;

namespace IEJPApps.Repositories
{
    public class ProjectRepository : Repository<Project>
    {
        public List<Project> LookupAll()
        {
            return Set.ToList();
        }
    }
}
