using Domain.SharedKernel;
using System;

namespace Domain
{
    public class Training : Entity
    {
        protected Training()
        {}

        private Training(Coach coach, DateTime dateToDo, TraningDetails traningDetails)
        {
            Coach = coach;
            DateToDo = dateToDo;
            TraningDetails = traningDetails;
            IsDone = false;
        }

        public static Training Create (Coach coach, DateTime dateToDo, TraningDetails traningDetails)
        {
            return new Training(coach, dateToDo, traningDetails);
        }

        public Coach Coach { get; protected set; }

        public DateTime DateToDo { get; protected set; }
        public DateTime Created { get; protected set; }
        public TraningDetails TraningDetails { get; protected set; }
        public bool IsDone { get; protected set; }
        public Runner Runner { get; protected set; }

        #region Methods
        public void UpdateTraningDate(DateTime dateTime)
        {
            this.DateToDo = dateTime;
        }
        #endregion
    }
}
