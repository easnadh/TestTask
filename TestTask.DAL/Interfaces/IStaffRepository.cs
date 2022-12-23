using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Service.Models;

namespace TestTask.DAL.Interfaces
{
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        Staff GetByName(string name);
    }
}
