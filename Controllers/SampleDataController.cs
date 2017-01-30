using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeApplication.Models;
using System.Collections;

namespace TimeApplication.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        //two types for fetching data
        public class EmployeeWithTime : Employee
        {
            public decimal Time { get; set; }
        }

        public class ProjectInfo : Project
        {
            public decimal Time { get; set; }
            public int Employees { get; set; }
        }


        private readonly DBContext dbContext;

        public SampleDataController(DBContext db)
        {
            dbContext = db;
        }


        [HttpGet("[action]/{firstName}/{lastName}")]
        public IActionResult AddEmployee(string firstName, string lastName)
        {
            Employee employee = new Employee(dbContext);

            employee.FirstName = firstName;
            employee.LastName = lastName;

            Employee.Add(employee);

            return Ok(new {  FirstName = employee.FirstName, LastName = employee.LastName, Id = employee.EmployeeID });
        }


        [HttpGet("[action]/{name}/{description}")]
        public IActionResult AddProject(string name, string description)
        {
            Project project = new Project(dbContext);

            project.Description = description;
            project.Name = name;

            try
            {
                Project.Add(project);
            }
            catch (Exception e)
            {
                return Ok(new { Error = "error" });
            }

            return Ok(new { Name = project.Name, Description = project.Description});
        }


        [HttpGet("[action]")]
        public List<ProjectInfo> InitProjectInfo()
        {
            List<ProjectInfo> result = new List<ProjectInfo>();
            List<Project> projects = dbContext.Projects.ToList();

            decimal t;  
            int c;
            ProjectInfo pi;// temporary variables for calcilating

            foreach (Project project in projects)
            {
                pi = new ProjectInfo();
                t = 0;
                c = 0;

                t = dbContext.EmployeeProjects.Where(p => p.ProjectName == project.Name).Sum(p => p.Time);//getting all time
                c = (from p in dbContext.EmployeeProjects.Where(p => p.ProjectName == project.Name).ToList()
                     group p by p.EmployeeID into projectGroup
                     select c).Count();//counting number of employees on project
                pi = new ProjectInfo();
                pi.Description = project.Description;
                pi.Name = project.Name;
                pi.Time = t;
                pi.Employees = c;
                result.Add(pi);
            }

            return result;
        }

        [HttpGet("[action]")]
        public List<EmployeeWithTime> InitEmployeeInfo()
        {
            List<EmployeeWithTime> result = new List<EmployeeWithTime>();
            List<Employee> employees = dbContext.Employees.ToList();

            decimal t;
            EmployeeWithTime ewt;// temporary variables for calcilating

            foreach (Employee emp in employees)
            {
                ewt = new EmployeeWithTime();
                t = 0;

                t = dbContext.EmployeeProjects.Where(p => p.EmployeeID == emp.EmployeeID).Sum(p => p.Time);//getting all time

                ewt.EmployeeID = emp.EmployeeID;
                ewt.FirstName = emp.FirstName;
                ewt.LastName = emp.LastName;
                ewt.Time = t;

                result.Add(ewt);
            }

            return result;
        }


        [HttpGet("[action]")]
        public List<Project> InitUpdate()
        {
            return dbContext.Projects.ToList();
        }


        [HttpGet("[action]/{projectName}/{employeeID}/{time}")]
        public IActionResult AddTiming(string projectName, int employeeID, decimal time)
        {
            EmployeeProject ep = new EmployeeProject(dbContext);

            ep.EmployeeID = employeeID;
            ep.ProjectName = projectName;
            ep.Time = time;

            try
            {
                EmployeeProject.Add(ep);
            }
            catch (Exception e)
            {
                return Ok(new { Error = "error" });
            }

            return Ok(new { EmployeeId = ep.EmployeeID, ProjectName = ep.ProjectName, Time = ep.Time });
        }


        [HttpGet("[action]/{employeeID}")]
        public List<EmployeeProject> GetEmployeeInfo(int employeeID)
        {
            List<EmployeeProject> result = new List<EmployeeProject>();
            List<EmployeeProject> projects =  dbContext.EmployeeProjects.Where(p => p.EmployeeID == employeeID).ToList();
            
            for(int i=0; i<projects.Count; i++)
            {
                projects[i].Time = projects.Where(p => p.ProjectName == projects[i].ProjectName).Sum(p => p.Time);//getting all time
                result.Add(projects[i]);
                projects.RemoveAll(p => p.ProjectName == projects[i].ProjectName);//ddeleting similar rows to avoid repeating
                i--;
            }
                return result;
        }


       
       
    }
}
