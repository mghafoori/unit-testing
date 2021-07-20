using Poco;

namespace DataAccess
{
    public interface IApplicantDataLayer
    {
        Applicant GetApplicant(int id);
    }
}
