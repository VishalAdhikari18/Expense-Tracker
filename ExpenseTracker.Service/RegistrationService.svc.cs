using ExpenseTracker.Business;
using ExpenseTracker.BusinessObjects;
using ExpenseTracker.Service.Behaviours;
using ExpenseTracker.Service.ServiceContract;

namespace ExpenseTracker.Service
{
    [AutomapServiceBehavior]
    public class RegistrationService : IRegistrationService
    {
        public UserValidationDTO ValidateUser(UserDTO user)
        {
            return BusinessFactory.GetUserProcess().ValidateUser(user);
        }

        public void Register(UserDTO user)
        {
            BusinessFactory.GetUserProcess().Create(user);
        }
    }
}
