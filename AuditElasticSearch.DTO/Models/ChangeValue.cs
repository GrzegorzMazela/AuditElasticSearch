using System.Collections.Generic;
using System.Linq;

namespace AuditElasticSearch.DTO.Models
{
    public class ChangeValue
    {
        public ChangeValue(string fieldName, string fieldType, IEnumerable<ChangeField> changeFields)
        {
            FieldName = fieldName;
            FieldType = fieldType;
            ChangeFields = changeFields;
        }

        public string FieldName { get; set; }
        public string FieldType { get; set; }

        public int Order
        {
            get
            {
                return ChangeFields.Min(x => x.Order);
            }
        }

        public IEnumerable<ChangeField> ChangeFields { get; set; }
    }
}