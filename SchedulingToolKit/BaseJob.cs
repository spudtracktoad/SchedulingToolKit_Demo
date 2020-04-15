using System;

namespace SchedulingToolKit
{
    public abstract class BaseJob
    {
        #region Public
        public int Weight { get; set; }

        public int ProcessTime { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime RelaseDate { get; set; }

        public Guid JobID { get; set; }

        public string JobName { get; set; }

        public bool Scheduled { get; set; }

        public double WeightedProcessingTime => Weight / ProcessTime;
        #endregion

    }
}
