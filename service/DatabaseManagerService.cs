using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.model;
using CareerHub.repository;

namespace CareerHub.service
{
    public class CareerHubService
    {
        private readonly DatabaseManagerRepository _databaseManager;

        public CareerHubService(DatabaseManagerRepository databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public Company CreateCompanyFromInput()
        {
            Console.WriteLine("Enter Company Name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Enter Location:");
            string location = Console.ReadLine();

            return new Company
            {
                CompanyName = companyName,
                Location = location
            };
        }

        public Applicant CreateApplicantFromInput()
        {
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();

            return new Applicant
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            };
        }

        public JobApplication CreateJobApplicationFromInput()
        {
            Console.WriteLine("Enter Job ID:");
            int jobId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Applicant ID:");
            int applicantId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Application Date (YYYY-MM-DD HH:MM:SS):");
            DateTime applicationDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Cover Letter:");
            string coverLetter = Console.ReadLine();

            return new JobApplication
            {
                JobID = jobId,
                ApplicantID = applicantId,
                ApplicationDate = applicationDate,
                CoverLetter = coverLetter
            };
        }
    }
}

    

