using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public class UserValidationDTO
    {
        [DataMember]
        public bool IsValidUser { get; set; }

        [DataMember]
        public bool IsValidUserName { get; set; }

        [DataMember]
        public bool IsValidEmail { get; set; }
    }
}
