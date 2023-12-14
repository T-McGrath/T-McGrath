using EmployeeProjects.Exceptions;
using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class DepartmentSqlDao : IDepartmentDao
    {
        private readonly string connectionString;

        public DepartmentSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Department GetDepartmentById(int departmentId)
        {
            Department department = null;

            string sql = @"SELECT department_id, name FROM department 
                           WHERE department_id = @department_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@department_id", ((object)departmentId ?? DBNull.Value));

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        department = MapRowToDepartment(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("ERROR, ERROR!", ex);
            }
            return department;
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            string sql = "SELECT department_id, name FROM department;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Department department = MapRowToDepartment(reader);
                        departments.Add(department);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("ERROR, ERROR!", ex);
            }
            return departments;
        }

        public Department CreateDepartment(Department department)
        {
            Department newDept = null;
            string sqlInsert = "INSERT INTO department (name) " +
                                "OUTPUT INSERTED.department_id " +
                                "VALUES (@name);";
            int newDeptId;
            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlInsert, conn);
                    command.Parameters.AddWithValue("@name", department.Name);
                    newDeptId = Convert.ToInt32(command.ExecuteScalar());
                }
                newDept = GetDepartmentById(newDeptId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Whoopsie, an error occurred!", ex);
            }
            return newDept;
        }

        public Department UpdateDepartment(Department department)
        {
            Department updatedDept = null;
            string sqlUpdate = "UPDATE department SET name = @department_name " +
                                "WHERE department_id = @department_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlUpdate, conn);
                    command.Parameters.AddWithValue("@department_name", department.Name);
                    command.Parameters.AddWithValue("@department_id", department.DepartmentId);

                    command.ExecuteNonQuery();
                }
                updatedDept = GetDepartmentById(department.DepartmentId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Whoopsie, an error occurred!", ex);
            }
            return updatedDept;
        }

        public int DeleteDepartmentById(int id)
        {
            int rowsAffected = 0;
            string sqlDeleteDept = "DELETE FROM department WHERE department_id = @department_id;";
            string sqlDeleteEmployee = "DELETE FROM employee WHERE department_id = @department_id;";
            string sqlDeleteProjectEmployee = "DELETE FROM project_employee WHERE employee_id IN " +
                                                "(SELECT employee_id FROM employee WHERE department_id = @department_id);";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Delete employee from project_employee
                    SqlCommand command = new SqlCommand(sqlDeleteProjectEmployee, conn);
                    command.Parameters.AddWithValue("@department_id", id);
                    command.ExecuteNonQuery();

                    // Delete employee with to-be-deleteded department_id
                    command = new SqlCommand(sqlDeleteEmployee, conn);
                    command.Parameters.AddWithValue("@department_id", id);
                    command.ExecuteNonQuery();

                    // Delete department with given department_id
                    command = new SqlCommand(sqlDeleteDept, conn);
                    command.Parameters.AddWithValue("@department_id", id);
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Whoopsie, an error occurred!", ex);
            }
            return rowsAffected;
        }

        private Department MapRowToDepartment(SqlDataReader reader)
        {
            Department department = new Department();
            department.DepartmentId = Convert.ToInt32(reader["department_id"]);
            department.Name = Convert.ToString(reader["name"]);

            return department;
        }
    }
}
