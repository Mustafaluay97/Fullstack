using HomeWork.Interface;
using HomeWork.Models;

namespace HomeWork.Service
{
    public class ProgramService : IProgram
    {

        public static List<Programm> programs = new List<Programm>();
        public async Task<IEnumerable<Programm>> GetAllPrograms()
        {
            return await Task.FromResult(programs);
        }

        public async Task<Programm> GetProgram(int id)
        {
            var MyProgram = programs.FirstOrDefault(c => c.Id == id);
            if (MyProgram != null)
            {
                return await Task.FromResult(MyProgram);
            }
            return await Task.FromResult<Programm>(null);
        }

      
        public async Task<Programm> CreateProgram(Programm program)
        {
            if (program != null)
            {
                programs.Add(program);
                return await Task.FromResult(program);
            }

            return await Task.FromResult<Programm>(null);
        }

        public async Task<bool> DeleteProgram(int id)
        {
            var IsDeleted = programs.FirstOrDefault(c => c.Id == id);

            if (IsDeleted != null)
            {
                programs.Remove(IsDeleted);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }



        public async Task<Programm> UpdateProgram(Programm program, int id)
        {
            var newProgram = programs.FirstOrDefault(c => c.Id == id);

            if (newProgram != null)
            {
                newProgram.Title = program.Title;
                return await Task.FromResult(newProgram);
            }
            return await Task.FromResult<Programm>(null);
        }

        
    }
}
