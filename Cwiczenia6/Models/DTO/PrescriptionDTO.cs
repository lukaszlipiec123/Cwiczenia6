using System;
using System.Collections.Generic;

namespace Cwiczenia6.Models.DTO
{
    public class PrescriptionDTO
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientDTO PatientDTO { get; set; }
        public DoctorDTO DoctorDTO { get; set; }
        public IEnumerable<MedicamentDTO> MedicamentDTOs {get; set;}
    }
}
