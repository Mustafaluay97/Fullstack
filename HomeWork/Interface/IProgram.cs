using HomeWork.Models;

namespace HomeWork.Interface
{
    public interface IProgram
    {
        Task<IEnumerable<Programm>> GetAllPrograms();

        Task<Programm> CreateProgram(Programm Programm);
        Task<Programm> GetProgram(int id);

        Task<Programm> UpdateProgram(Programm Programm, int id);

        Task<bool> DeleteProgram(int id);
    }
}
