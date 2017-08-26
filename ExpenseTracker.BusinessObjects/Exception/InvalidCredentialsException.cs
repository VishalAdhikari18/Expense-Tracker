using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects.Exception
{
    [DataContract]
    public class InvalidCredentialsException
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
