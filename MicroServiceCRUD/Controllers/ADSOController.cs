using MicroServiceCRUD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MicroServiceCRUD.Models;
using Microsoft.AspNetCore.Authorization;

namespace MicroServiceCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ADSOController : ControllerBase
    {
        private readonly IADSORepository _repository;

        public ADSOController(IADSORepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetADSO()
        {
            var response = await _repository.GetADSO();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostADSO([FromBody] ADSO adso)
        {
            try
            {
                var response = await _repository.PostADSO(adso);
                if (response == true)
                    return Ok("Insertado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
