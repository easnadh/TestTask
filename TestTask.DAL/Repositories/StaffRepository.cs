using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Interfaces;
using TestTask.Domain.Models;

namespace TestTask.DAL.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationContext db;

        public StaffRepository(ApplicationContext context) 
        { 
            db = context;
        }

        public async Task<bool> Create(Staff entity)
        {
            await db.Staff.AddAsync(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Staff entity)
        {
            db.Staff.Remove(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Staff> Get(int id)
        {
            return await db.Staff.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Staff> GetByName(string name)
        {
            return await db.Staff.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Staff>> Select()
        {
            return await db.Staff.ToListAsync();
        }
    }
}
