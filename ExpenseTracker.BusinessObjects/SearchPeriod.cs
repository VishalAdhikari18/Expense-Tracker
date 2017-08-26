using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public enum SearchPeriod
    {
        [EnumMember]
        Weekly = 1,
        [EnumMember]
        Monthly = 2,
        [EnumMember]
        Yearly = 3
    }
}
