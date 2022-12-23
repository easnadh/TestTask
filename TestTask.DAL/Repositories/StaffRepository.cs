using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Interfaces;
using TestTask.Service.Models;

namespace TestTask.DAL.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationContext db;

        public StaffRepository(ApplicationContext context) 
        { 
            db = context;
        }

        public bool Create(Staff entity)
        {
            db.Staff.Add(entity);
            db.SaveChanges();

            return true;
        }

        public bool Delete(Staff entity)
        {
            db.Staff.Remove(entity);
            db.SaveChanges();

            return true;
        }

        public Staff Get(int id)
        {
            return db.Staff.FirstOrDefault(x => x.Id == id);
        }

        public Staff GetByName(string name)
        {
            return db.Staff.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Staff> Select()
        {
            return db.Staff.ToList();
        }
    }
}
