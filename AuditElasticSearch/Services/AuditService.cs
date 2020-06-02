using AuditElasticSearch.Domain.Entities;
using Microsoft.Extensions.Logging;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuditElasticSearch.Services
{
    public class AuditService
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<AuditService> _logger;

        public AuditService(IElasticClient elasticClient, ILogger<AuditService> logger)
        {
            _elasticClient = elasticClient;
            _logger = logger;
        }

        public async Task SaveSingleAsync(AuditEntity audit)
        {
            var response = await _elasticClient.IndexDocumentAsync(audit);
            var test = response.Result;
        }

        public async Task SaveManyAsync(IEnumerable<AuditEntity> audits)
        {
            var result = await _elasticClient.IndexManyAsync(audits);
            if (result.Errors)
            {
                // the response can be inspected for errors
                foreach (var itemWithError in result.ItemsWithErrors)
                {
                    _logger.LogError("Failed to index document {0}: {1}",
                        itemWithError.Id, itemWithError.Error);
                }
            }
        }

        public async Task SaveBulkAsync(IEnumerable<AuditEntity> audits)
        {
            var result = await _elasticClient.BulkAsync(b => b.Index("audits").IndexMany(audits));
            if (result.Errors)
            {
                // the response can be inspected for errors
                foreach (var itemWithError in result.ItemsWithErrors)
                {
                    _logger.LogError("Failed to index document {0}: {1}",
                        itemWithError.Id, itemWithError.Error);
                }
            }
        }

        public async Task DeleteAsync(AuditEntity audit)
        {
            await _elasticClient.DeleteAsync<AuditEntity>(audit);
        }

        public async Task<IEnumerable<AuditEntity>> GetAudits()
        {
            var result = await _elasticClient.SearchAsync<AuditEntity>(x => x.MatchAll());
            return result.Documents;
        }
    }
}