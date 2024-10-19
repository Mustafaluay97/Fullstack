using HomeWork.Interface;
using HomeWork.Models;

namespace HomeWork.Service
{
    public class TrainerService : ITrainer
    {

        public static List<Trainer> trainers = new List<Trainer>();

        public async Task<IEnumerable<Trainer>> GetAllTrainers()
        {
            return await Task.FromResult(trainers);
        }

        
        public async Task<Trainer> GetTrainer(int id)
        {
            var myTrainer = trainers.FirstOrDefault(x => x.Id == id);   
            if (myTrainer == null)
            {
                return await Task.FromResult<Trainer>(null);
            }
            return await Task.FromResult(myTrainer);

        }
        public async Task<Trainer> CreateTrainer(Trainer trainer)
        {
            if (trainer != null)
            {
                trainers.Add(trainer);
                return await Task.FromResult(trainer);
            }
            return await Task.FromResult<Trainer>(null);
        }

        public async Task<bool> DeleteTrainer(int id)
        {
            var IsDeleted = trainers.FirstOrDefault(t => t.Id == id);   
            if (IsDeleted != null)
            {
                trainers.Remove(IsDeleted);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

   

        public async Task<Trainer> UpdateTrainer(Trainer trainer, int id)
        {
            var newTrainer = trainers.FirstOrDefault(t => t.Id == id);
            if (newTrainer != null)
            {
                newTrainer.Salary = trainer.Salary;
                return await Task.FromResult(newTrainer);
            }
            return await Task.FromResult<Trainer>(null);
        }
    }
}
