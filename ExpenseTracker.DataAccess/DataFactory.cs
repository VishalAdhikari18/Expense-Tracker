using ExpenseTracker.DataAccess.Interface;

namespace ExpenseTracker.DataAccess
{
    public static class DataFactory
    {
        public static IUserData GetUserData()
        {
            return new UserData();
        }

        public static ITokenData GetTokenData()
        {
            return new TokenData();
        }

        public static ITransactionData GetTransactionData()
        {
            return new TransactionData();
        }

        public static void ConfigureMapper()
        {
            AutoMapperConfig.Initialize();
        }
    }
}
