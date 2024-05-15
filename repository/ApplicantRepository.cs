using CareerHub.util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.exception;

namespace CareerHub.repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly string _connectionString;

        public ApplicantRepository()
        {
            _connectionString = DbConnUtil.GetConnectionString();
        }

        public void CreateProfile(string email, string firstName, string lastName, string phone)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Applicants (FirstName, LastName, Email, Phone) " +
                                   "VALUES (@FirstName, @LastName, @Email, @Phone)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (DatabaseConnectionHandlingException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ApplyForJob(int applicantID, int jobID, string coverLetter)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Applications (ApplicantID, JobID, CoverLetter, ApplicationDate) " +
                               "VALUES (@ApplicantID, @JobID, @CoverLetter, @ApplicationDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicantID", applicantID);
                    command.Parameters.AddWithValue("@JobID", jobID);
                    command.Parameters.AddWithValue("@CoverLetter", coverLetter);
                    command.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
