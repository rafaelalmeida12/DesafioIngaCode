using System.ComponentModel.DataAnnotations;

namespace IngaCode.Domain.Entities
{
    public class TimeTrackers : BaseEntity
    {
       
        public DateTime StartDate { get; set; }

   
        public DateTime EndDate { get; set; }

        public string TimeZoneId { get; set; }
        public Guid TaskId { get; set; }
        public Tasks Task { get; set; }
        public Guid CollaboratorId { get; set; }
        public Collaborators Collaborator { get; set; }


        public void Calculo()
        {
            var tempo = StartDate - EndDate;
            var minutos = tempo.TotalHours;

            var minutes = StartDate.Minute - EndDate.Minute;
            var hours = StartDate.Hour - EndDate.Hour;



        }
    }
}
