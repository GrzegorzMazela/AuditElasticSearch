using System;

namespace AuditElasticSearch.Domain.Entities
{
    public class ChangeValueEntity
    {
        protected ChangeValueEntity()
        {
        }

        public static ChangeValueEntity CreateChangeValue(string fieldName, string fieldType, string oldValue, string newValue, int order,
            string description)
        {
            if ((oldValue?.Length > 2000) || (newValue?.Length > 2000))
            {
                oldValue = oldValue?.Substring(0, 2000);
                newValue = newValue?.Substring(0, 2000);
            }

            var changeValueEntity = new ChangeValueEntity
            {
                Id = Guid.NewGuid(),
                FieldName = fieldName,
                FieldType = fieldType,
                OldValue = oldValue,
                NewValue = newValue,
                Order = order,
                Description = description,
            };
            return changeValueEntity;
        }

        public Guid Id { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
    }
}