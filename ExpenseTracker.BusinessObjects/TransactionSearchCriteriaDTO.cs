using System;
using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public class TransactionSearchCriteriaDTO
    {
        [DataMember]
        public SearchPeriod SearchPeriod { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int PageNumber { get; set; }
    }
}
