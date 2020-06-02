namespace AuditElasticSearch.DTO.Models
{
    public class ChangeField
    {
        public ChangeField(string oldValue, string newValue, int order)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Order = order;
        }

        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int Order { get; set; }
    }
}