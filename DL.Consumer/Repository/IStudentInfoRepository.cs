using System.Collections.Generic;
using System.Threading.Tasks;
using DL.Consumer.Model;

namespace DL.Consumer.Repository
{
    public interface IStudentInfoRepository
    {
        Task<List<StudentInfo>> GetStudentInfoAsync();

        Task<StudentInfo> GetStudentInfoAsync(int id);

        Task<StudentInfo> InsertStudentInfo(StudentInfo customer);
        Task<bool> UpdateStudentInfoAsync(StudentInfo customer);
        Task<bool> DeleteStudentInfoAsync(int id);
    }
}
