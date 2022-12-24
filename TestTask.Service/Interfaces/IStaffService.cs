using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Models;
using TestTask.Service.Response;

namespace TestTask.Service.Interfaces
{
    public interface IStaffService
    {
        Task<IBaseResponse<IEnumerable<Staff>>> GetStaff();
    }
}
