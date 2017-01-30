using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeApplication.Models
{
    public class Project
    {
        private static DBContext db;

        public Project(DBContext dbc)
        {
            db = dbc;
        }

        public Project() { }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [Key]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public static void Add(Project project)
        {
            try
            {
                db.Projects.Add(project);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Project FindByName(string name)
        {
            return db.Projects.Find(name);
        }

    }
}
