using HomeWork.Models;

namespace HomeWork.Interface
{
    public interface ITrainer
    {
        public Task<IEnumerable<Trainer>> GetAllTrainers();

        public Task<Trainer> GetTrainer(int id);

        public Task<Trainer> CreateTrainer(Trainer trainer);

        public Task<Trainer> UpdateTrainer(Trainer trainer , int id);

        public  Task<bool> DeleteTrainer(int id);



    }
}
