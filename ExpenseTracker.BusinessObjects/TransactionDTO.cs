using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public class TransactionDTO
    {
        [DataMember]
        public int TransactionId { get; set; }

        [DataMember]
        public double TransactionAmount { get; set; }

        [DataMember]
        public DateTime TransactionDate { get; set; }

        [DataMember]
        public string TransactionNote { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public bool HasReceipts { get; set; }

        [DataMember]
        public TransactionCategoryDTO TransactionCategory { get; set; }

        [DataMember]
        public IList<TransactionReceiptDTO> TransactionReceipts { get; set; }
    }
}
