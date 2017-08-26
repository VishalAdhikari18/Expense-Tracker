using ExpenseTracker.Business.Interface;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.DataAccess;
using System;
using System.Security.Cryptography;

namespace ExpenseTracker.Business
{
    internal class TokenProcess : ITokenProcess
    {
        //TODO: move this to web.config
        private const int TOKEN_LENGTH = 50;

        public string Build(Credentials credentails)
        {
            if (DataFactory.GetUserData().IsValid(credentails))
            {
                string token = GetTokenString(TOKEN_LENGTH);
                DataFactory.GetTokenData().Create(credentails, token);
                return token;
            }
            return string.Empty;
        }

        public bool IsValid(string token)
        {
            return DataFactory.GetTokenData().IsValid(token);
        }

        private string GetTokenString(int length)
        {
            var buffer = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }
    }
}
