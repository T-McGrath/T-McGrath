using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEams
{
    internal class Employee
    {
        public const double startingSalary = 60000;
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }
        public DateTime HireDate { get; set; }
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }

        public Employee(long employeeId, string firstName, string lastName, string email, Department department, DateTime hireDate)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Department = department;
            HireDate = hireDate;
            Salary = startingSalary;
        }

        public Employee()
        {
            Salary = startingSalary;
        }

        public void RaiseSalary(double percent)
        {
            Salary *= 1 + percent / 100.0;
        }

    }
}
