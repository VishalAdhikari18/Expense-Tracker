using ExpenseTracker.Business.Interface;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.DataAccess;
using ExpenseTracker.DataAccess.Interface;

namespace ExpenseTracker.Business
{
    internal class Authenticate : IAuthenticate
    {
        public string BuildToken(Credentials credentials)
        {
            ITokenProcess tokenBuilder = new TokenProcess();
            return tokenBuilder.Build(credentials);
        }

        public bool IsValid(Credentials credentails)
        {
            return DataFactory.GetUserData().IsValid(credentails);
        }
    }
}
