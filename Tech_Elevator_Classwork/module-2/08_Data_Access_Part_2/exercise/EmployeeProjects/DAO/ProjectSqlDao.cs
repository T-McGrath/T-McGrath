using EmployeeProjects.Exceptions;
using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class ProjectSqlDao : IProjectDao
    {
        private readonly string connectionString;

        public ProjectSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Project GetProjectById(int projectId)
        {
            Project project = null;
            string sql = "SELECT project_id, name, from_date, to_date FROM project WHERE project_id = @project_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        project = MapRowToProject(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return project;
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            string sql = "SELECT project_id, name, from_date, to_date FROM project;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Project project = MapRowToProject(reader);
                        projects.Add(project);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("ERROR OCCURRED!", ex);
            }
            return projects;
        }

        public Project CreateProject(Project newProject)
        {
            Project myNewProject = null;
            string sqlInsert = "INSERT INTO project (name, from_date, to_date) " +
                                "OUTPUT INSERTED.project_id " +
                                "VALUES (@name, @from_date, @to_date);";
            int newProjectId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlInsert, conn);
                    command.Parameters.AddWithValue("@name", newProject.Name);
                    command.Parameters.AddWithValue("@from_date", newProject.FromDate);
                    command.Parameters.AddWithValue("@to_date", newProject.ToDate);
                    newProjectId = Convert.ToInt32(command.ExecuteScalar());
                }
                myNewProject = GetProjectById(newProjectId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error occurred!", ex);
            }
            return myNewProject;
        }

        public void LinkProjectEmployee(int projectId, int employeeId)
        {
            string sqlInsert = "INSERT INTO project_employee (project_id, employee_id) " +
                                "Values (@project_id, @employee_Id);";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlInsert, conn);
                    command.Parameters.AddWithValue("@project_id", projectId);
                    command.Parameters.AddWithValue("@employee_id", employeeId);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error occurred!", ex);
            }
        }

        public void UnlinkProjectEmployee(int projectId, int employeeId)
        {
            string sqlString = "DELETE FROM project_employee WHERE employee_id = @employee_id AND project_id = @project_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlString, conn);
                    command.Parameters.AddWithValue("@employee_id", employeeId);
                    command.Parameters.AddWithValue("@project_id", projectId);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error occurred!", ex);
            }
        }

        public Project UpdateProject(Project project)
        {
            Project updatedProject = null;
            string sqlUpdate = "UPDATE project SET name = @name, from_date = @from_date, to_date = @to_date WHERE project_id = @project_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlUpdate, conn);
                    command.Parameters.AddWithValue("@name", project.Name);
                    command.Parameters.AddWithValue("@from_date", project.FromDate);
                    command.Parameters.AddWithValue("@to_date", project.ToDate);
                    command.Parameters.AddWithValue("@project_id", project.ProjectId);
                    command.ExecuteNonQuery();
                }
                updatedProject = GetProjectById(project.ProjectId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error occurred!", ex);
            }
            return updatedProject;
        }

        public int DeleteProjectById(int projectId)
        {
            int numRowsAffected = 0;
            string sqlDelete = "DELETE FROM project WHERE project_id = @project_id;";
            string sqlDeleteProjectEmployee = "DELETE FROM project_employee WHERE project_id = @project_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sqlDeleteProjectEmployee, conn);
                    command.Parameters.AddWithValue("@project_id", projectId);
                    command.ExecuteNonQuery();

                    command = new SqlCommand(sqlDelete, conn);
                    command.Parameters.AddWithValue("@project_id", projectId);
                    numRowsAffected = command.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error occurred!", ex);
            }
            return numRowsAffected;
        }

        private Project MapRowToProject(SqlDataReader reader)
        {
            Project project = new Project();
            project.ProjectId = Convert.ToInt32(reader["project_id"]);
            project.Name = Convert.ToString(reader["name"]);
            if (reader["from_date"] is DBNull)
            {
                project.FromDate = null;
            }
            else
            {
                project.FromDate = Convert.ToDateTime(reader["from_date"]);
            }
            if (reader["to_date"] is DBNull)
            {
                project.ToDate = null;
            }
            else
            {
                project.ToDate = Convert.ToDateTime(reader["to_date"]);
            }

            return project;
        }
    }
}
