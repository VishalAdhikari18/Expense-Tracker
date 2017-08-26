using ExpenseTracker.BusinessObjects;
using System.Collections.Generic;

namespace ExpenseTracker.DataAccess.Interface
{
    public interface IUserData
    {
        bool IsValid(Credentials credentials);

        UserDTO GetUser(string token);

        UserDTO GetUser(Credentials credentials);

        void Create(UserDTO user);

        bool UserNameExists(string username);

        bool EmailExists(string email);

        List<TransactionDTO> GetTransactions(TransactionSearchCriteriaDTO searchCriteria);
    }
}
