using System;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia6.Models;

namespace Cwiczenia6.DataAccessLayer
{
    public class DoctorsDataAccess : IDoctorsDataAccess
    {

        private readonly MainDbContext _mainDbContext;

        public DoctorsDataAccess(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<Doctor> GetDoctorDetails(int IdDoctor)
        {
            var doctor = await _mainDbContext.Doctors.FindAsync(IdDoctor);
            
            if(doctor == null)
            {
                throw new Exception("Doktor o podanym Id nie znaleziony");
            }

            return await _mainDbContext.Doctors.FindAsync(IdDoctor);
        }

        public async Task<bool> CreateDoctor(Doctor doctor)
        {
            var addDoctor = new Doctor
            {
                IdDoctor = _mainDbContext.Doctors.Max(x => x.IdDoctor) + 1,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };

            await _mainDbContext.AddAsync(doctor);
            await _mainDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteDoctor(int IdDoctor)
        {
            var doctor = await _mainDbContext.Doctors.FindAsync(IdDoctor);

            if (doctor == null)
            {
                throw new Exception("Doktor o podanym Id nie znaleziony");
            }

            _mainDbContext.Remove(doctor);
            await _mainDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ModifyDoctor(int IdDoctor, Doctor doctor)
        {

            var currentDoctor = await _mainDbContext.Doctors.FindAsync(IdDoctor);

            if (currentDoctor == null)
            {
                throw new Exception("Doktor o podanym Id nie znaleziony");
            }
            
            currentDoctor.FirstName = doctor.FirstName;
            currentDoctor.LastName = doctor.LastName;
            currentDoctor.Email = doctor.Email;

            await _mainDbContext.SaveChangesAsync();
            
            return true;
        }
    }
}
