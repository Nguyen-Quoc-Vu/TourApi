using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourApi.DTOs;
using TourApi.Model;
using TourApi.Model.IRepository;

namespace TourApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICostRepository _costRepository;
        public CostController(IMapper mapper, ICostRepository costRepository)
        {
            _costRepository = costRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostDTO>>> GetAllCost()
        {
            var costs = await _costRepository.GetAll();
            var costsDTO = _mapper.Map<IEnumerable<Cost>, IEnumerable<CostDTO>>(costs);
            return Ok(costsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CostDTO>> GetCost(int id)
        {
            var cost = await _costRepository.GetBy(id);

            var costDTO = _mapper.Map<Cost, CostDTO>(cost);
            return Ok(costDTO);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCost(CostDTO costDTO)
        {
            var cost = _mapper.Map<CostDTO, Cost>(costDTO);
            await _costRepository.Add(cost);
            return CreatedAtAction(nameof(GetCost), new { id = cost.CostId }, cost);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CostDTO costDTO)
        {
            if (id != costDTO.CostId)
            {
                return BadRequest();
            }
            try
            {
                var cost = _mapper.Map<CostDTO, Cost>(costDTO);
                await _costRepository.Update(id, cost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCost(int id)
        {
            if (!await CostExists(id))
            {
                return NotFound();
            }
            else
            {
                await _costRepository.Delete(id);
                return NoContent();
            }
        }
        private async Task<bool> CostExists(int id)
        {
            var cost = await _costRepository.GetBy(id);
            if (cost != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}