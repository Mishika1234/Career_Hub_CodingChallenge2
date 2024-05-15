using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.model;
using CareerHub.repository;

namespace CareerHub.service
{
    public class ApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public void CreateProfile()
        {
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();

            _applicantRepository.CreateProfile(email, firstName, lastName, phone);
            Console.WriteLine("Profile created successfully.");
        }

        public void ApplyForJob()
        {
            Console.WriteLine("Enter Applicant ID:");
            int applicantID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Job ID:");
            int jobID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Cover Letter:");
            string coverLetter = Console.ReadLine();

            _applicantRepository.ApplyForJob(applicantID, jobID, coverLetter);
            Console.WriteLine("Job application submitted successfully.");
        }
    }
}
