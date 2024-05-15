using CareerHub.model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareerHub.util;

namespace CareerHub.repository
{

    public class JobListingRepository : IJobListingRepository
    {
        private readonly string _connectionString;

        public JobListingRepository()
        {
            _connectionString = DbConnUtil.GetConnectionString();
        }

        public void Apply(int jobID, int applicantID, string coverLetter)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO JobApplications (JobID, ApplicantID, CoverLetter, ApplicationDate) " +
                               "VALUES (@JobID, @ApplicantID, @CoverLetter, @ApplicationDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@JobID", jobID);
                    command.Parameters.AddWithValue("@ApplicantID", applicantID);
                    command.Parameters.AddWithValue("@CoverLetter", coverLetter);
                    command.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Applicant> GetApplicants(int jobID)
        {
            List<Applicant> applicants = new List<Applicant>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Applicants WHERE ApplicantID IN (SELECT ApplicantID FROM JobApplications WHERE JobID = @JobID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@JobID", jobID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate Applicant object from SqlDataReader
                            Applicant applicant = new Applicant
                            {
                                // Populate properties from reader columns
                            };
                            applicants.Add(applicant);
                        }
                    }
                }
            }

            return applicants;
        }
    }
}

