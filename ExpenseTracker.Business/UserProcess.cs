using ExpenseTracker.Business.Interface;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.DataAccess;
using System.Collections.Generic;

namespace ExpenseTracker.Business
{
    internal class UserProcess : IUserProcess
    {
        public void Create(UserDTO user)
        {
            DataFactory.GetUserData().Create(user);
        }

        public List<TransactionDTO> GetTransactions(TransactionSearchCriteriaDTO searchCriteria)
        {
            return DataFactory.GetUserData().GetTransactions(searchCriteria);
        }

        public UserDTO GetUser(string token)
        {
            return DataFactory.GetUserData().GetUser(token);
        }

        public UserDTO GetUser(Credentials credentials)
        {
            return DataFactory.GetUserData().GetUser(credentials);
        }

        public UserValidationDTO ValidateUser(UserDTO user)
        {
            UserValidationDTO validation = new UserValidationDTO();
            validation.IsValidEmail = DataFactory.GetUserData().EmailExists(user.Email);
            validation.IsValidUserName = DataFactory.GetUserData().UserNameExists(user.UserName);
            validation.IsValidUser = validation.IsValidUserName && validation.IsValidEmail;
            return validation;
        }
    }
}
