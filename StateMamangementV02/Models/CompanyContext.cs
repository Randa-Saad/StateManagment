using System;
using System.Data.Entity;
using System.Linq;

namespace StateMamangementV02.Models
{
    public class CompanyContext : DbContext
    {
        
        public CompanyContext()
            : base("name=CompanyDB")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }

}