using System.Threading.Tasks;
using Cwiczenia6.Models.DTO;

namespace Cwiczenia6.DataAccessLayer
{
    public interface IPrescriptionDataAccess
    {
        public Task<PrescriptionDTO> GetPrescriptionDTO(int IdPrescription);
    }
}
