using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public class AuthenticateResultDTO
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public bool IsAuthenticated { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
