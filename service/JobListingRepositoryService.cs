using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.model;
using CareerHub.repository;

namespace CareerHub.service
{

    public class JobListingService
    {
        private readonly IJobListingRepository _jobListingRepository;

        public JobListingService(IJobListingRepository jobListingRepository)
        {
            _jobListingRepository = jobListingRepository;
        }

        public void Apply()
        {
            Console.WriteLine("Enter Applicant ID:");
            int applicantID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Job ID:");
            int jobID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Cover Letter:");
            string coverLetter = Console.ReadLine();

            _jobListingRepository.Apply(applicantID, jobID, coverLetter);
            Console.WriteLine("Application submitted successfully.");
        }

        public void GetApplicants()
        {
            Console.WriteLine("Enter Job ID:");
            int jobID = int.Parse(Console.ReadLine());

            List<Applicant> applicants = _jobListingRepository.GetApplicants(jobID);

            Console.WriteLine("Applicants for Job:");
            foreach (var applicant in applicants)
            {
                Console.WriteLine($"ApplicantID: {applicant.ApplicantID}, Name: {applicant.FirstName} {applicant.LastName}, Email: {applicant.Email}, Phone: {applicant.Phone}");
            }
        }
    }
}