using ExpenseTracker.BusinessObjects;
using ExpenseTracker.DataAccess.Interface;
using System;
using System.Linq;

namespace ExpenseTracker.DataAccess
{
    internal class TokenData : ITokenData
    {
        public UserToken GetToken(string token)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return dbctx.UserTokens
                    .Where(userToken => userToken.Token == token && userToken.ExpiryDate > DateTime.Now)
                    .SingleOrDefault();
            }
        }

        public bool IsValid(string token)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return dbctx.UserTokens
                    .Where(userToken => userToken.Token == token && userToken.ExpiryDate > DateTime.Now)
                    .Count() == 1;
            }
        }

        public void Create(Credentials credentials, string token)
        {
            UserData userData = new UserData();
            UserDTO user = userData.GetUser(credentials);
            using (var dbctx = new ExpenseTrackerEntities())
            {
                UserToken userToken = dbctx.UserTokens.Where(t => t.UserId == user.UserId).SingleOrDefault();
                if (userToken != null)
                {
                    userToken.Token = token;
                    userToken.ExpiryDate = DateTime.Now.AddHours(4);
                    dbctx.Entry(userToken).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    dbctx.UserTokens.Add(new UserToken
                    {
                        UserId = user.UserId,
                        Token = token,
                        ExpiryDate = DateTime.Now.AddHours(4)                        
                    });                    
                }
                dbctx.SaveChanges();
            }
        }
    }
}
