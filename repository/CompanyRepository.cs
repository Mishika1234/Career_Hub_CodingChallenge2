using CareerHub.model;
using CareerHub.util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly string _connectionString;

        public CompanyRepository()
        {
            _connectionString = DbConnUtil.GetConnectionString();
        }

        public void PostJob(int companyId, string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO JobListings (CompanyId, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                               "VALUES (@CompanyId, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    command.Parameters.AddWithValue("@JobTitle", jobTitle);
                    command.Parameters.AddWithValue("@JobDescription", jobDescription);
                    command.Parameters.AddWithValue("@JobLocation", jobLocation);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@JobType", jobType);
                    command.Parameters.AddWithValue("@PostedDate", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<JobListing> GetJobs(int companyId)
        {
            List<JobListing> jobs = new List<JobListing>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM JobListings WHERE CompanyId = @CompanyId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", companyId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JobListing job = new JobListing
                            {
                                JobID = reader.GetInt32(reader.GetOrdinal("JobID")),
                                CompanyID = reader.GetInt32(reader.GetOrdinal("CompanyId")),
                                JobTitle = reader.GetString(reader.GetOrdinal("JobTitle")),
                                JobDescription = reader.GetString(reader.GetOrdinal("JobDescription")),
                                JobLocation = reader.GetString(reader.GetOrdinal("JobLocation")),
                                Salary = reader.GetDecimal(reader.GetOrdinal("Salary")),
                                JobType = reader.GetString(reader.GetOrdinal("JobType")),
                                PostedDate = reader.GetDateTime(reader.GetOrdinal("PostedDate"))
                            };
                            jobs.Add(job);
                        }
                    }
                }
            }

            return jobs;
        }
    }
}

