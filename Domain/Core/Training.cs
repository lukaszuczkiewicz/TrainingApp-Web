using Domain.SharedKernel;
using System;

namespace Domain
{
    public class Training : Entity
    {
        protected Training()
        {}

        private Training(DateTime dateToDo, TraningDetails traningDetails)
        {

            DateToDo = dateToDo;
            TraningDetails = traningDetails;
            IsDone = false;
        }

        public static Training Create (DateTime dateToDo, TraningDetails traningDetails)
        {
            return new Training(dateToDo, traningDetails);
        }

        public DateTime DateToDo { get; protected set; }
        public DateTime Created { get; protected set; }
        public virtual TraningDetails TraningDetails { get; protected set; }
        public bool IsDone { get; protected set; }
        public virtual Runner Runner { get; set; }

        #region Methods
        public void UpdateTraningDate(DateTime dateTime)
        {
            this.DateToDo = dateTime;
        }
        #endregion
    }
}
