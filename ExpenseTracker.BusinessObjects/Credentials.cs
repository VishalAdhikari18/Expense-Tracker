using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public class Credentials
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
