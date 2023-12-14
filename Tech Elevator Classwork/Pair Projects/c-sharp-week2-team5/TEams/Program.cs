using System;
using System.Collections.Generic;

namespace TEams
{
    class Program
    {
        List<Department> departments = new List<Department>();
        List<Employee> employees = new List<Employee>();
        Dictionary<string, Project> projects = new Dictionary<string, Project>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            // create some departments
            
            CreateDepartments();

            // print each department by name
            PrintDepartments();

            // create employees
            CreateEmployees();

            // give Angie a 10% raise, she is doing a great job!
            employees[1].RaiseSalary(10.0);

            // print all employees
            PrintEmployees();

            // create the TEams project
            CreateTeamsProject();

            // create the Marketing Landing Page Project
            CreateLandingPageProject();

            // print each project name and the total number of employees on the project
            PrintProjectsReport();
        }

        /**
         * Create departments and add them to the collection of departments
         */
        Department marketing = new Department(1, "Marketing");
        Department sales = new Department(2, "Sales");
        Department engineering = new Department(3, "Engineering");
        private void CreateDepartments()
        {
            departments.Add(marketing);
            
            departments.Add(sales);
            
            departments.Add(engineering);
        }

        /**
         * Print out each department in the collection.
         */
        private void PrintDepartments()
        {
            Console.WriteLine("------------- DEPARTMENTS ------------------------------");
            foreach(Department department in departments)
            {
                Console.WriteLine(department.Name);
            }
        }

        /**
         * Create employees and add them to the collection of employees
         */
        private void CreateEmployees()
        {
            DateTime today = DateTime.Now;
            Employee person1 = new Employee();
            person1.EmployeeId = 1;
            person1.FirstName = "Dean";
            person1.LastName = "Johnson";
            person1.Email = "djohnson@teams.com";
            person1.HireDate = today;
            person1.Department = departments[2];
            employees.Add(person1);

            employees.Add(new Employee(2, "Angie", "Smith", "asmith@teams.com", departments[2], today));
            employees.Add(new Employee(3, "Margret", "Thompson", "mthompson@teams.com", departments[0], today));
        }

        /**
         * Print out each employee in the collection.
         */
        private void PrintEmployees()
        {
            Console.WriteLine("\n------------- EMPLOYEES ------------------------------");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FullName} ({employee.Salary.ToString("C2")}) {employee.Department.Name}");
            }
        }

        /**
         * Create the 'TEams' project.
         */
        private void CreateTeamsProject()
        {
            DateTime today = DateTime.Now;
            Project teams = new Project("TEams", "Project Management Software", today, today.AddDays(30.0));
            teams.TeamMembers.AddRange(GetEmployeesFromDepartment(engineering));
            projects[teams.Name] = teams;
        }

        private List<Employee> GetEmployeesFromDepartment(Department department)
        {
            List<Employee> result = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if(employee.Department == department)
                {
                    result.Add(employee);
                }
            }
            return result;
        }

        /**
         * Create the 'Marketing Landing Page' project.
         */
        private void CreateLandingPageProject()
        {
            DateTime startDate = DateTime.Now.AddDays(31);
            Project landingPage = new Project("Marketing Landing Page", "Lead Capture Landing Page for Marketing", startDate, startDate.AddDays(7));
            landingPage.TeamMembers.AddRange(GetEmployeesFromDepartment(marketing));
            projects[landingPage.Name] = landingPage;
        }

        /**
         * Print out each project in the collection.
         */
        private void PrintProjectsReport()
        {
            Console.WriteLine("\n------------- PROJECTS ------------------------------");
            foreach(KeyValuePair<string, Project> project in projects)
            {
                Console.WriteLine($"{project.Key}: {project.Value.TeamMembers.Count}");
            }

        }
    }
}
