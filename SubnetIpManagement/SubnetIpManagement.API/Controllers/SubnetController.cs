using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubnetIpManagement.API.Dtos;
using SubnetIpManagement.API.Services;
using SubnetIpManagement.Domain.Entities;

namespace SubnetIpManagement.API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubnetController(SubnetService subnetService) : ControllerBase
    {
        private readonly SubnetService _subnetService = subnetService;

        [HttpGet]
        public async Task<IActionResult> GetSubnets(int pageNumber = 1, int pageSize = 10)
        {
            var subnets = await _subnetService.GetSubnetsAsync(pageNumber, pageSize);
            return Ok(subnets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubnetById(int id)
        {
            var subnet = await _subnetService.GetSubnetByIdAsync(id);
            if (subnet is null) return NotFound();
            return Ok(subnet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubnet([FromBody] SubnetDto subnetDto)
        {
            if (subnetDto is null) return BadRequest();
            var createdSubnet = await _subnetService.CreateSubnetAsync(subnetDto);
            return Ok(createdSubnet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubnet(int id, [FromBody] SubnetDto subnetDto)
        {
            var updatedSubnet = await _subnetService.UpdateSubnetAsync(id, subnetDto);
            return Ok(updatedSubnet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubnet(int id)
        {
            var subnet = await _subnetService.GetSubnetByIdAsync(id);
            if (subnet is null) return NotFound();
            var deletedSubnet = await _subnetService.DeleteSubnetAsync(id);
            return Ok(deletedSubnet);
        }
    }
}
