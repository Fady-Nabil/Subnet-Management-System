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
    public class IPAddressController(IPAddressService ipAddressService) : ControllerBase
    {
        private readonly IPAddressService _ipAddressService = ipAddressService;

        [HttpGet("subnet/{subnetId}")]
        public async Task<IActionResult> GetIPsBySubnetId(int subnetId)
        {
            var ips = await _ipAddressService.GetAllIPsBySubnetIdAsync(subnetId);
            return Ok(ips);
        }

        [HttpPost]
        public async Task<IActionResult> AddIPAddress([FromBody] IpAddressDto ipAddressDto)
        {
            var createdIPaddress = await _ipAddressService.CreateIPAddressAsync(ipAddressDto);
            return Ok(createdIPaddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIPAddress(int id, [FromBody] IpAddressDto ipAddressDto)
        {
            var updatedIpAdress = await _ipAddressService.UpdateIPAddressAsync(id, ipAddressDto);
            return Ok(updatedIpAdress);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIPAddress(int id)
        {
            var ipAddress = await _ipAddressService.GetIPAddressByIdAsync(id);
            if (ipAddress is null) return NotFound();
            var deletedIpAddress = await _ipAddressService.DeleteIPAddressAsync(id);
            return Ok(deletedIpAddress);
        }
    }
}
