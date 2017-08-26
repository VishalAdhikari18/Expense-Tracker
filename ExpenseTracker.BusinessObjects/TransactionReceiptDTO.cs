using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public class TransactionReceiptDTO
    {
        [DataMember]
        public int TransactionReceiptId { get; set; }
        [DataMember]
        public int TransactionId { get; set; }
        [DataMember]
        public byte[] ReceiptImage { get; set; }
        [DataMember]
        public string ContentType { get; set; }
    }
}
