using ExpenseTracker.BusinessObjects;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ExpenseTracker.Service.ServiceContract
{
    [ServiceContract]
    interface IAuthenticationService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        AuthenticateResultDTO Authenticate(Credentials credentials);
    }
}
