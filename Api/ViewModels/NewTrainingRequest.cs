using System;

namespace TraingAppBackEnd.ViewModels
{
    public class NewTrainingRequest
    {
        public Guid RunnerId { get; set; }
        public DateTime TimeToDo { get; set; }
        public string Details { get; set; }
        public string Comments { get; set; }
    }
}
