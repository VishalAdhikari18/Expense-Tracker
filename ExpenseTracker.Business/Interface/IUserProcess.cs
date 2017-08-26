using ExpenseTracker.BusinessObjects;
using System.Collections.Generic;

namespace ExpenseTracker.Business.Interface
{
    public interface IUserProcess
    {
        UserDTO GetUser(string token);

        UserDTO GetUser(Credentials credentials);

        void Create(UserDTO user);

        UserValidationDTO ValidateUser(UserDTO user);

        List<TransactionDTO> GetTransactions(TransactionSearchCriteriaDTO searchCriteria);
    }
}
