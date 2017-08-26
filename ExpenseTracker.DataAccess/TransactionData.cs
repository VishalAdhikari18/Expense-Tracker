using AutoMapper;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.DataAccess
{
    public class TransactionData : ITransactionData
    {
        public void Create(TransactionDTO transaction)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                var tran = new Transaction
                {
                    TransactionAmount = transaction.TransactionAmount,
                    TransactionDate = transaction.TransactionDate,
                    TransactionNote = transaction.TransactionNote,
                    CategoryId = transaction.CategoryId,
                    UserId = transaction.UserId
                };
                if (transaction.TransactionReceipts != null && transaction.TransactionReceipts.Any())
                {
                    transaction.TransactionReceipts.ToList().ForEach(t =>
                    {
                        tran.TransactionReceipts.Add(new TransactionReceipt
                        {
                            ReceiptImage = t.ReceiptImage,
                            ContentType = t.ContentType
                        });
                    });
                }
                dbctx.Transactions.Add(tran);
                dbctx.SaveChanges();
            }
        }

        public void CreateCategory(string name)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                dbctx.TransactionCategories.Add(new TransactionCategory
                {
                    CategoryName = name
                });
                dbctx.SaveChanges();
            }
        }

        public List<TransactionCategoryDTO> GetTransactionCategories()
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return Mapper.Map<List<TransactionCategoryDTO>>(dbctx.TransactionCategories.ToList());
            }
        }

        public bool CategoryExists(string name)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return dbctx.TransactionCategories.Where(x => x.CategoryName == name).Any();
            }
        }
    }
}
