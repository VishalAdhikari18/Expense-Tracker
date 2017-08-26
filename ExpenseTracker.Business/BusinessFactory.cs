using ExpenseTracker.Business.Interface;
using ExpenseTracker.DataAccess;

namespace ExpenseTracker.Business
{
    public static class BusinessFactory
    {
        public static IAuthenticate GetAuthentication()
        {
            return new Authenticate();
        }

        public static ITokenProcess GetTokenProcess()
        {
            return new TokenProcess();
        }

        public static IUserProcess GetUserProcess()
        {
            return new UserProcess();
        }

        public static ITransactionProcess GetTransactionProcess()
        {
            return new TransactionProcess();
        }

        public static void ConfigureMapper()
        {
            DataFactory.ConfigureMapper();
        }
    }
}
