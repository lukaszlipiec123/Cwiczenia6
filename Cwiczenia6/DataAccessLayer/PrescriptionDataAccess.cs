using System.Linq;
using System.Threading.Tasks;
using Cwiczenia6.Models;
using Cwiczenia6.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia6.DataAccessLayer
{
    public class PrescriptionDataAccess : IPrescriptionDataAccess
    {

        private readonly MainDbContext _mainDbContext;
        public PrescriptionDataAccess(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<PrescriptionDTO> GetPrescriptionDTO(int IdPrescription)
        {

            var dto = await _mainDbContext.Prescriptions
                      .Include(prescription => prescription.Prescription_Medicaments)
                      .Where(prescription => prescription.IdPrescription == IdPrescription)
                      .Select(prescription => new PrescriptionDTO
            {
                IdPrescription = prescription.IdPrescription,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                PatientDTO = new PatientDTO
                {
                    FirstName = prescription.Patient.FirstName,
                    LastName = prescription.Patient.LastName,
                    BirthDate = prescription.Patient.BirthDate
                },
                DoctorDTO = new DoctorDTO
                {
                    FirstName = prescription.Doctor.FirstName,
                    LastName = prescription.Doctor.LastName,
                    Email = prescription.Doctor.Email,
                },
                MedicamentDTOs = prescription.Prescription_Medicaments.Select(p => new MedicamentDTO
                {
                    Name = p.Medicament.Name,
                    Description = p.Medicament.Description,
                    Type = p.Medicament.Type
                })
            }).FirstAsync();

            return dto;
        }
    }
}
