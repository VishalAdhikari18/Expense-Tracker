using ExpenseTracker.Business.Interface;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.DataAccess;
using System.Collections.Generic;
using System;

namespace ExpenseTracker.Business
{
    internal class TransactionProcess : ITransactionProcess
    {
        public void Create(TransactionDTO transaction)
        {
            DataFactory.GetTransactionData().Create(transaction);
        }

        public void CreateCategory(string name)
        {
            DataFactory.GetTransactionData().CreateCategory(name);
        }

        public List<TransactionCategoryDTO> GetTransactionCategories()
        {
            return DataFactory.GetTransactionData().GetTransactionCategories();
        }

        public bool CategoryExists(string name)
        {
            return DataFactory.GetTransactionData().CategoryExists(name);
        }

        public List<TransactionReceiptDTO> GetTransactionReceipts(int transactionId)
        {
            return DataFactory.GetTransactionData().GetTransactionReceipts(transactionId);
        }

        public TransactionDTO GetTransaction(int transactionId)
        {
            return DataFactory.GetTransactionData().GetTransaction(transactionId);
        }

        public void DeleteTransaction(int transactionId)
        {
            DataFactory.GetTransactionData().DeleteTransaction(transactionId);
        }
    }
}
