using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.API.DTO;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedangsController : ControllerBase
    {
        private readonly IPedang _pedangs;
        private readonly IMapper _mapper;
        public PedangsController(IPedang pedangs, IMapper mapper)
        {
            _pedangs = pedangs;
            _mapper = mapper;
        }


        // GET: api/<PedangsController>
        [HttpGet]
        public async Task<IEnumerable<PedangDTO>> Get()
        {
            var results = await _pedangs.GetAll();
            var output = _mapper.Map<IEnumerable<PedangDTO>>(results);
            return output;
        }

        // GET api/<PedangsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedangDTO>> GetById(int id)
        {
            var result = await _pedangs.GetById(id);
            if (result == null)
                return NotFound();
            else
                return Ok(_mapper.Map<PedangDTO>(result));
        }

        // POST api/<PedangsController>
        [HttpPost]
        public async Task<ActionResult> Post(PedangCreateDTO pedangCreateDTO)
        {
            try
            {
                var newPedang = _mapper.Map<Pedang>(pedangCreateDTO);
                var result = await _pedangs.Insert(newPedang);
                var pedangDTO = _mapper.Map<PedangDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, pedangDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Element")]
        public async Task<ActionResult> PostWithElement(PedangCreateWithElementDTO pedangCreateWithElement)
        {
            try
            {
                var newPedang = _mapper.Map<Pedang>(pedangCreateWithElement);
                var result = await _pedangs.InsertPedangWithElement(newPedang);
                var pedangDTO = _mapper.Map<PedangDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, pedangDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PedangsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PedangCreateDTO pedangCreateDTO)
        {
            try
            {
                var updatePedang = _mapper.Map<Pedang>(pedangCreateDTO);
                var result = await _pedangs.Update(id, updatePedang);
                var pedangDTO = _mapper.Map<PedangDTO>(result);
                return Ok(pedangDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PedangsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _pedangs.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
