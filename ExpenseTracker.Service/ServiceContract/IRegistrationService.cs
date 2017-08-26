using ExpenseTracker.BusinessObjects;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ExpenseTracker.Service.ServiceContract
{
    [ServiceContract]
    public interface IRegistrationService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void Register(UserDTO user);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        UserValidationDTO ValidateUser(UserDTO user);
    }
}
