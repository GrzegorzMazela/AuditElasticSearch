using System;

namespace AuditElasticSearch.DTO.Models
{
    public class Audit
    {
        public Audit(Guid auditId, string parentObjectId, string objectId, string changeTypeId, string changeTypeName, string changeBy, DateTime changeDate)
        {
            AuditId = auditId;
            ParentObjectId = parentObjectId;
            ObjectId = objectId;
            ChangeType = changeTypeId;
            ChangeTypeName = changeTypeName;
            ChangeBy = changeBy;
            ChangeDate = changeDate;
        }

        public Guid AuditId { get; set; }
        public string ParentObjectId { get; set; }
        public string ObjectId { get; set; }
        public string ChangeType { get; set; }
        public string ChangeTypeName { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}