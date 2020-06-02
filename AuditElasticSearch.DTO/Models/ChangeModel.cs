namespace AuditElasticSearch.DTO.Models
{
    public class ChangeModel
    {
        public ChangeModel(string fieldName, string value, int order, string description = "")
        {
            FieldName = fieldName;
            Value = value;
            Order = order;
            Description = description;
        }

        public string FieldName { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
    }
}