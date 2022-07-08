using System.Threading.Tasks;
using Cwiczenia6.Models;

namespace Cwiczenia6.DataAccessLayer
{
    public interface IDoctorsDataAccess
    {
        public Task<Doctor> GetDoctorDetails(int IdDoctor);
        public Task<bool> CreateDoctor(Doctor doctor);
        public Task<bool> DeleteDoctor(int IdDoctor);
        public Task<bool> ModifyDoctor(int IdDoctor, Doctor doctor);
    }
}
