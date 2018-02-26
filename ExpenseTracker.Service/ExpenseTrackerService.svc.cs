using ExpenseTracker.Business;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.Service.Behaviours;
using ExpenseTracker.Service.ServiceContract;
using System.Collections.Generic;
using System;

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

        public List<TransactionReceiptDTO> GetTransactionReceipts(int transactionId)
        {
            return BusinessFactory.GetTransactionProcess().GetTransactionReceipts(transactionId);
        }

        public List<TransactionDTO> GetTransactions(TransactionSearchCriteriaDTO searchCriteria)
        {
            return BusinessFactory.GetUserProcess().GetTransactions(searchCriteria);
        }

        public TransactionDTO GetTransaction(int transactionId)
        {
            return BusinessFactory.GetTransactionProcess().GetTransaction(transactionId);
        }

        public void DeleteTransaction(int transactionId)
        {
            BusinessFactory.GetTransactionProcess().DeleteTransaction(transactionId);
        }
    }
}
