using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeApplication.Models
{
    public class EmployeeProject
    {
        private static DBContext db;

        public EmployeeProject(DBContext dbc)
        {
            db = dbc;
        }

        public EmployeeProject() { }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("ProjectName")]
        public string ProjectName { get; set; }

        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }

        public decimal Time { get; set; }

        public static void Add(EmployeeProject employeeProject) 
        {
            try
            {
                db.EmployeeProjects.Add(employeeProject);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static EmployeeProject FindByID(int id)
        {
            return db.EmployeeProjects.Find(id);
        }

    }
}
