using System.Runtime.Serialization;

namespace ExpenseTracker.BusinessObjects
{
    [DataContract]
    public class TransactionCategoryDTO
    {
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }
    }
}
