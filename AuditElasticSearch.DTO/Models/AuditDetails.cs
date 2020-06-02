using System;
using System.Collections.Generic;

namespace AuditElasticSearch.DTO.Models
{
    public class AuditDetails
    {
        public AuditDetails(Guid auditId, string parentObjectId, string objectId, string changeType, string changeBy, DateTime changeDate, IEnumerable<ChangeValue> changeValues)
        {
            AuditId = auditId;
            ParentObjectId = parentObjectId;
            ObjectId = objectId;
            ChangeType = changeType;
            ChangeDate = changeDate;
            ChangeBy = changeBy;
            ChangeValues = changeValues;
        }

        public Guid AuditId { get; set; }
        public string ParentObjectId { get; set; }
        public string ObjectId { get; set; }
        public string ChangeType { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeBy { get; set; }
        public IEnumerable<ChangeValue> ChangeValues { get; set; }
    }
}