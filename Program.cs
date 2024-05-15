using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CareerHub.model;
using CareerHub.repository;
using CareerHub.service;
using CareerHub.util;


namespace CareerHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IJobListingRepository jobListingRepository = new JobListingRepository();
            JobListingService jobListingService = new JobListingService(jobListingRepository);

            ICompanyRepository companyRepository = new CompanyRepository();
            CompanyService companyService = new CompanyService(companyRepository);

            IApplicantRepository applicantRepository = new ApplicantRepository();
            ApplicantService applicantService = new ApplicantService(applicantRepository);

           var databaseManagerRepository = new DatabaseManagerRepository();
            var careerHubService = new CareerHubService(databaseManagerRepository);
           
            while (true)
            {
                Console.WriteLine("\nJob Listing Management System\n");
                Console.WriteLine("1. Get Applicants");
                Console.WriteLine("2. Apply");
                Console.WriteLine("3. Create Profile");
                Console.WriteLine("4. Apply for Job");
                Console.WriteLine("5. Post Job");
                Console.WriteLine("6. Get Jobs");
                Console.WriteLine("7. InsertCompany");
                Console.WriteLine("8. Insert Applicant");
                //  Console.WriteLine(" CareerHub Main Menu");
                Console.WriteLine("9. Insert Job Listing");

                // Console.WriteLine("9. Exit");



                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        jobListingService.GetApplicants();
                        break;
                    case 2:
                        jobListingService.Apply();
                        break;
                    case 3:
                        applicantService.CreateProfile();
                        break;
                    case 4:
                        applicantService.ApplyForJob();
                        break;
                    case 5:
                        companyService.PostJob();
                        break;
                    case 6:
                        companyService.GetJobs();
                        break;
                    case 7:
                        careerHubService.InsertCompany();
                        break;
                    case 8:
                        careerHubService.InsertApplicant();
                        break;
                    case 9:
                        careerHubService.InsertJobListing();
                        break;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}

