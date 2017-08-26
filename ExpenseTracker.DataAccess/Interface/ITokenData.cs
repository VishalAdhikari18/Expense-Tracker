using ExpenseTracker.BusinessObjects;

namespace ExpenseTracker.DataAccess.Interface
{
    public interface ITokenData
    {
        bool IsValid(string token);

        UserToken GetToken(string token);

        void Create(Credentials credentials, string token);
    }
}