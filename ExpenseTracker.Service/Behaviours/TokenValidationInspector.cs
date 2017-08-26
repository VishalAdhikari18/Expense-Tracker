using ExpenseTracker.Business;
using ExpenseTracker.Business.Interface;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.BusinessObjects.Exception;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace ExpenseTracker.Service.Behaviours
{
    public class TokenValidationInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Return BadRequest if request is null
            if (WebOperationContext.Current == null)
            {
                throw new FaultException<UnAuthorisedException>(new UnAuthorisedException(), new FaultReason("User Unauthorised"));
            }
            // Get Token from header
            var token = WebOperationContext.Current.IncomingRequest.Headers["AUTH_TOKEN"];

            // Validate the Token
            ITokenProcess tokenBuilder = BusinessFactory.GetTokenProcess();
            if (!tokenBuilder.IsValid(token))
            {
                throw new FaultException<UnAuthorisedException>(new UnAuthorisedException(), new FaultReason("User Unauthorised"));
            }
            UserDTO user = BusinessFactory.GetUserProcess().GetUser(token);
            if (user == null)
            {
                throw new FaultException<UnAuthorisedException>(new UnAuthorisedException(), new FaultReason("User Unauthorised"));
            }
            // Add User ids to the header so the service has them if needed
            WebOperationContext.Current.IncomingRequest.Headers.Add("UserName", user.UserName);
            WebOperationContext.Current.IncomingRequest.Headers.Add("UserId", user.UserId.ToString());
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}