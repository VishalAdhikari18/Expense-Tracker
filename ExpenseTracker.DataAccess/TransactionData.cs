using AutoMapper;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.DataAccess.Interface;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<TransactionReceiptDTO> GetTransactionReceipts(int transactionId)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return Mapper.Map<List<TransactionReceiptDTO>>(dbctx.
                    TransactionReceipts.Where(r => r.TransactionId == transactionId));
            }
        }

        public TransactionDTO GetTransaction(int transactionId)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                return dbctx.Transactions
                    .Where(t => t.TransactionId == transactionId)
                    .Select(t => new TransactionDTO
                    {
                        TransactionId = t.TransactionId,
                        TransactionAmount = t.TransactionAmount,
                        TransactionDate = t.TransactionDate,
                        TransactionNote = t.TransactionNote,
                        TransactionCategory = new TransactionCategoryDTO
                        {
                            CategoryId = t.TransactionCategory.CategoryId,
                            CategoryName = t.TransactionCategory.CategoryName
                        }
                    })
                    .SingleOrDefault();
            }
        }

        public void DeleteTransaction(int transactionId)
        {
            using (var dbctx = new ExpenseTrackerEntities())
            {
                Transaction transaction = dbctx.Transactions
                    .Where(t => t.TransactionId == transactionId)
                    .Include(t => t.TransactionReceipts)
                    .Single();
                dbctx.TransactionReceipts.RemoveRange(transaction.TransactionReceipts);
                dbctx.Transactions.Remove(transaction);
                dbctx.SaveChanges();
            }
        }
    }
}
