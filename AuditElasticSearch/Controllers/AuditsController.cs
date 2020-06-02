using AuditElasticSearch.Domain.Entities;
using AuditElasticSearch.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuditElasticSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditsController : ControllerBase
    {
        private readonly AuditService _auditService;

        public AuditsController(AuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAudit([FromBody]AuditEntity audit)
        {
            await _auditService.SaveSingleAsync(audit);
            return Ok();
        }

        [HttpPost("many")]
        public async Task<IActionResult> CreateAudist([FromBody]IEnumerable<AuditEntity> audits)
        {
            await _auditService.SaveBulkAsync(audits);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAudist()
        {
            return Ok(await _auditService.GetAudits());
        }
    }
}