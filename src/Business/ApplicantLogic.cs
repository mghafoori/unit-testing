using DataAccess;
using Poco;
using System;

namespace Business
{
    public class ApplicantLogic
    {
        private readonly IApplicantDataLayer _dataLayer;

        public ApplicantLogic(IApplicantDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        
        public Applicant GetApplicant(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id), $"Invalid applicant id: {id}");
            }
            var applicant = _dataLayer.GetApplicant(id);
            return applicant;
        }
    }
}
