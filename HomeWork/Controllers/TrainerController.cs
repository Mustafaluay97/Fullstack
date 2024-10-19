using HomeWork.Interface;
using HomeWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {

        private ITrainer _trainer;
        public TrainerController(ITrainer trainer)
        {
           _trainer = trainer;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllTrainers() 
        {
            var trainers = await _trainer.GetAllTrainers();
            return Ok(trainers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTrainer(int id)
        {
            var trainers = await _trainer.GetTrainer(id);
            if (trainers == null)
            {
                return NotFound("This Trainer Is Not Found");
            }
            return Ok(trainers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainer([FromBody] Trainer trainer)
        {
            var newTrainer = await _trainer.CreateTrainer(trainer);
            if (newTrainer == null)
            {
                return NotFound("This Trainer Is Not Found");
            }
            return Ok(newTrainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer([FromBody] Trainer trainer, int id)
        {
            var newTrainer = await _trainer.UpdateTrainer(trainer, id);
            if(newTrainer == null)
            {
                return NotFound("This Trainer Is Not Found");
            }
            return Ok(newTrainer);
        }

        [HttpDelete("{id}")]
          
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var IsDeleted = await _trainer.DeleteTrainer(id);
            if(!IsDeleted)
            {
                return NotFound("This Trainer Is Not Found");
            }
            return Ok("This Trainer Is Deleted Successfully");
        }

    }
}
