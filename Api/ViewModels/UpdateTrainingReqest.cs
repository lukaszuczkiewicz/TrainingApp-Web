using System;

namespace TraingAppBackEnd.ViewModels
{
    public class UpdateTrainingRequest
    {
        public Guid Id { get; set; }
        public Guid RunnerId { get; set; }
        public DateTime TimeToDo { get; set; }
        public string Details { get; set; }
        public string Comments { get; set; }
    }
}
