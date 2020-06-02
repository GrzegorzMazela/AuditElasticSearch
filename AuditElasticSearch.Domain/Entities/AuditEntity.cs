using System;
using System.Collections.Generic;

namespace AuditElasticSearch.Domain.Entities
{
    public partial class AuditEntity
    {
        protected AuditEntity()
        {
            ChangeValues = new List<ChangeValueEntity>();
        }

        protected AuditEntity(string createdBy) : this()
        {
            CreatedBy = createdBy;
            CreatedDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Removed { get; set; }
        public string ParentObjectId { get; set; }

        public string ObjectId { get; set; }

        public string ProcessType { get; set; }

        public List<ChangeValueEntity> ChangeValues { get; set; }
    }
}