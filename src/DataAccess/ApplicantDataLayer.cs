using Poco;
using System;

namespace DataAccess
{
    public class ApplicantDataLayer : IApplicantDataLayer
    {
        public Applicant GetApplicant(int id)
        {
            // Assume that this code is actually talking to a database
            // and the data is retrieved from tables
            return new Applicant
            {
                Id = id,
                Name = $"Name of Applicant #{id}",
                Email = $"applicant.{id}@somecompany.com"
            };
        }
    }
}
