using ExpenseTracker.Business;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.Service.Behaviours;
using ExpenseTracker.Service.ServiceContract;
using System.Collections.Generic;

namespace ExpenseTracker.Service
{
    [AutomapServiceBehavior]
    [TokenValidationServiceBehavior]
    public class ExpenseTrackerService : IExpenseTrackerService
    {
        public bool CategoryExists(string name)
        {
            return BusinessFactory.GetTransactionProcess().CategoryExists(name);
        }

        public void CreateTransaction(TransactionDTO transaction)
        {
            BusinessFactory.GetTransactionProcess().Create(transaction);
        }

        public void CreateTransactionCategory(string name)
        {
            BusinessFactory.GetTransactionProcess().CreateCategory(name);
        }

        public List<TransactionCategoryDTO> GetTransactionCategories()
        {
            return BusinessFactory.GetTransactionProcess().GetTransactionCategories();
        }

        public List<TransactionDTO> GetTransactions(TransactionSearchCriteriaDTO searchCriteria)
        {
            return BusinessFactory.GetUserProcess().GetTransactions(searchCriteria);
        }
    }
}
