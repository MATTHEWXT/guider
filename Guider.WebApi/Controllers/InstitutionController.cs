using Guider.Application.Interfaces;
using Guider.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateInstitution([FromBody] CreateInstitutionReq req)
        {
            try
            {
                await _institutionService.CreateAsync(req);

                return Ok();
            }

            catch (Exception) {
                return BadRequest("Create Institution error.");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInstitutions()
        {
            try
            {
                var institutions = await _institutionService.GetAllAsync();

                var institutionsDtoList = institutions
                        .Select(i => _institutionService.GetInstitutionDto(i))
                        .ToList();

                return Ok(institutionsDtoList);
            }
            catch (Exception)
            {
                return BadRequest("Get Institution error.");
            }
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInstitution(Guid id, [FromBody] UpdateInstitutionReq req)
        {
            try
            {
                var institution = await _institutionService.GetByIdAsync(id);

                await _institutionService.UpdateAsync(req, institution);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Update Institution error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInstitution(Guid id)
        {
            try
            {
                await _institutionService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Delete Institution error.");

            }
        }
    }
}
