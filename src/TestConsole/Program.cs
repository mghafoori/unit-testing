using Business;
using DataAccess;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataLayer = new ApplicantDataLayer();
            var logic = new ApplicantLogic(dataLayer);
            var applicant = logic.GetApplicant(0);
            Console.WriteLine($"Id: {applicant.Id}, Name: {applicant.Name}, Email: {applicant.Email} ");
        }
    }
}
