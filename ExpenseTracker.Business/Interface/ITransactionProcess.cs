using ExpenseTracker.BusinessObjects;
using System.Collections.Generic;

namespace ExpenseTracker.Business.Interface
{
    public interface ITransactionProcess
    {
        void Create(TransactionDTO transaction);

        void CreateCategory(string name);

        List<TransactionCategoryDTO> GetTransactionCategories();

        bool CategoryExists(string name);

        List<TransactionReceiptDTO> GetTransactionReceipts(int transactionId);

        TransactionDTO GetTransaction(int transactionId);

        void DeleteTransaction(int transactionId);
    }
}
