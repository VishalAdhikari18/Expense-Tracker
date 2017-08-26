using System;
using System.ServiceModel.Configuration;

namespace ExpenseTracker.Service.Behaviours
{
    public class TokenValidationBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(TokenValidationServiceBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new TokenValidationServiceBehavior();
        }
    }
}