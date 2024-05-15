using CareerHub.model;
using CareerHub.util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.service
{
    public class ApplicantProfileCreationService
    {
        private readonly string _connectionString;

        public ApplicantProfileCreationService()
        {
            _connectionString = DbConnUtil.GetConnectionString();
        }

        public void CreateApplicantProfile(string firstName, string lastName, string email, string phone)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Applicants (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Applicant profile created successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create applicant profile.");
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("");
            }
        }
    }
}
