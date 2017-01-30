using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeApplication.Models
{
    public class Employee
    {
        private static DBContext db;

        public Employee(DBContext dbc)
        {
            db = dbc;
        }

        public Employee() { }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }


        public static void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public static Employee FindByID(int id)
        {
            return db.Employees.Find(id);
        }
    }
}
