using IngaCode.Domain.Entities;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace IngaCode.Application.Models.InputModels
{
    public class TimeTrackerInputModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TimeZoneId { get; set; }
        public Guid TaskId { get; set; }
        public Guid CollaboratorId { get; set; }

        public TimeTrackers ToEntity()
        {
            var time = new TimeTrackers
            {
                StartDate = StartDate,
                EndDate = EndDate,
                TimeZoneId = TimeZoneId,
                TaskId = TaskId,
                CollaboratorId = CollaboratorId
            };
            return time;
        }

        public bool Validar(Tasks task)
        {
            if (StartDate >= EndDate)
                throw new ArgumentException("A data de ínicio deve ser maior ou igual a data de término");

            var totalHoras = 0;
            foreach (var item in task.Trackers)
            {
                if (item.StartDate.Date == StartDate.Date)
                {
                    if (item.StartDate <= StartDate && StartDate <= item.EndDate)
                        throw new ArgumentException("Horario ja cadastrado para a atividade");

                    var time =  (item.StartDate.TimeOfDay -item.EndDate.TimeOfDay);
                    totalHoras = totalHoras + time.Hours;
                }
            }
            return true;
        }
    }
}
