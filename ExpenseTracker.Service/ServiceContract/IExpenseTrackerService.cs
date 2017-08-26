using ExpenseTracker.BusinessObjects;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ExpenseTracker.Service.ServiceContract
{
    [ServiceContract]
    [ServiceKnownType(typeof(SearchPeriod))]
    public interface IExpenseTrackerService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        void CreateTransaction(TransactionDTO transaction);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        void CreateTransactionCategory(string name);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<TransactionCategoryDTO> GetTransactionCategories();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        bool CategoryExists(string name);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json)]
        List<TransactionDTO> GetTransactions(TransactionSearchCriteriaDTO searchCriteria);
    }
}
