using HomeWork.Interface;
using HomeWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {

        private IProgram _ProgramService;

        public ProgramController(IProgram ProgramService)
        {
            _ProgramService = ProgramService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrograms()
        {
            var programs = await _ProgramService.GetAllPrograms();
            return Ok(programs);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram([FromBody] Programm program)
        {
            if (program != null)
            {
                await _ProgramService.CreateProgram(program);
                return Ok(program);
            }
            return NotFound("Can Not Add Null Value");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgram(int id)
        {
            var GetPro = await _ProgramService.GetProgram(id);
            if (GetPro != null)
            {
                return Ok(GetPro);
            }

            return NotFound("This Program Not Found");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProgram(int id, [FromBody] Programm program)
        {
            var newProgram = await _ProgramService.UpdateProgram(program, id);
            if (newProgram != null)
            {
                return Ok(newProgram);
            }
            return NotFound("This Program Not Found");
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProgram(int id)
        {
            var isDeleted = await _ProgramService.DeleteProgram(id);
            if (!isDeleted)
            {
                return NotFound("This Program Not Found");
            }
            return NotFound("This Program Is Deleted Successfully");
        }
    }
}
