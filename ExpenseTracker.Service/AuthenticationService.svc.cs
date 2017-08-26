using ExpenseTracker.Business;
using ExpenseTracker.Business.Interface;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.BusinessObjects.Exception;
using ExpenseTracker.Service.Behaviours;
using ExpenseTracker.Service.ServiceContract;
using System.ServiceModel;

namespace ExpenseTracker.Service
{
    [AutomapServiceBehavior]
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticateResultDTO Authenticate(Credentials credentials)
        {
            AuthenticateResultDTO result = new AuthenticateResultDTO();
            IAuthenticate authenticate = BusinessFactory.GetAuthentication();
            if (authenticate.IsValid(credentials))
            {
                result.IsAuthenticated = true;
                result.UserId = BusinessFactory.GetUserProcess().GetUser(credentials).UserId;
                result.Token = authenticate.BuildToken(credentials);
            }
            else
            {
                result.IsAuthenticated = false;
                result.ErrorMessage = "Invalid username or password.";
            }
            return result;
        }
    }
}