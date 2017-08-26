using System;
using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public class TokenDTO
    {
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
        [DataMember]
        public UserDTO User { get; set; }
    }
}
