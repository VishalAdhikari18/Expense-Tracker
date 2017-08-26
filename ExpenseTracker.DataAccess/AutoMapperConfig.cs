using AutoMapper;
using ExpenseTracker.BusinessObjects;

namespace ExpenseTracker.DataAccess
{
    internal class AutoMapperConfig
    {
        public static void Initialize()
        {            
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserToken, TokenDTO>();
                cfg.CreateMap<TransactionReceipt, TransactionReceiptDTO>();
                cfg.CreateMap<Transaction, TransactionDTO>();
                cfg.CreateMap<TransactionCategory, TransactionCategoryDTO>();
             });
        }
    }
}
