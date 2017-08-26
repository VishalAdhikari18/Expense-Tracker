using ExpenseTracker.BusinessObjects;
using ExpenseTracker.DataAccess.Interface;
using System.Linq;
using System.Data.Entity;
using System;
using AutoMapper;
using System.Collections.Generic;

namespace ExpenseTracker.DataAccess
{
    internal class UserData : IUserData
    {
        public bool IsValid(Credentials credentials)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return dbctx.Users
                    .Where(user => user.UserName == credentials.UserName && user.Password == credentials.Password)
                    .Count() == 1;
            }
        }

        public UserDTO GetUser(Credentials credentials)
        {
            User userData;
            using (var dbctx = new ExpenseTrackerEntities())
            {
                userData = dbctx.Users
                    .Where(user => user.UserName == credentials.UserName && user.Password == credentials.Password)
                    .Include(x => x.UserToken)
                    .SingleOrDefault();
            }
            return Mapper.Map<UserDTO>(userData);
        }

        public UserDTO GetUser(string token)
        {
            User userData;
            using (var dbctx = new ExpenseTrackerEntities())
            {
                userData = dbctx.Users
                    .Where(user => user.UserToken.Token == token && user.UserToken.ExpiryDate > DateTime.Now)
                    .SingleOrDefault();
            }
            return Mapper.Map<UserDTO>(userData);
        }

        public void Create(UserDTO user)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                dbctx.Users.Add(new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    UserName = user.UserName
                });
                dbctx.SaveChanges();
            }
        }

        public bool UserNameExists(string username)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return !dbctx.Users.Where(user => user.UserName == username).Any();
            }
        }

        public bool EmailExists(string email)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return !dbctx.Users.Where(user => user.Email == email).Any();
            }
        }

        public List<TransactionDTO> GetTransactions(TransactionSearchCriteriaDTO searchCriteria)
        {
            List<TransactionDTO> trans;
            using (var dbctx = new ExpenseTrackerEntities())
            {
                dbctx.Configuration.ProxyCreationEnabled = false;
                trans = dbctx.Transactions
                    .Where(t => t.TransactionDate >= searchCriteria.StartDate.Date
                            && t.TransactionDate <= searchCriteria.EndDate)
                    .Include(t => t.TransactionCategory)
                    .OrderBy(t => t.TransactionDate)
                    .Select(t => new TransactionDTO
                    {
                        TransactionId = t.TransactionId,
                        TransactionAmount = t.TransactionAmount,
                        TransactionDate = t.TransactionDate,
                        TransactionNote = t.TransactionNote,
                        TransactionCategory = new TransactionCategoryDTO { CategoryName = t.TransactionCategory.CategoryName },
                        HasReceipts = t.TransactionReceipts.Any()
                    })
                    .ToList();
            }
            return trans;
        }
    }
}
