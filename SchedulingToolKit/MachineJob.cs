using System;

namespace SchedulingToolKit
{
    public abstract class MachineJob
    {
        private Guid b_JobID;
        private int b_Weight;
        private int b_ProcessTime;
        private DateTime b_RelaseDate;
        private DateTime b_DueDate;


        #region Constructors
        public MachineJob(int weight, int processing, DateTime due, DateTime release)
        {
            JobID = new Guid();
            DueDate = due;
            RelaseDate = release;
            Weight = weight;
            ProcessTime = processing;
            WeightedProcessingTime = weight / processing;
            if (processing != 0)
                pFactor = weight / processing;
            else
                pFactor = 0;
        }
        #endregion

        #region Public
        public int Weight
        {
            get { return b_Weight; }
            private set
            {
                b_Weight = value;
                if (ProcessTime != 0)
                    WeightedProcessingTime = Weight / ProcessTime;
                else
                    WeightedProcessingTime = 0;
            }
        }

        public int ProcessTime
        {
            get { return b_ProcessTime; }
            private set
            {
                b_ProcessTime = value;
                if (ProcessTime != 0)
                    WeightedProcessingTime = Weight / ProcessTime;
                else
                    WeightedProcessingTime = 0;
            }
        }
        public DateTime DueDate
        {
            get { return b_DueDate; }
            private set { b_DueDate = value; }
        }

        public DateTime RelaseDate
        {
            get { return b_RelaseDate; }
            private set { b_RelaseDate = value; }
        }

        public Guid JobID
        {
            get { return b_JobID; }
            private set { b_JobID = value; }
        }

        public double WeightedProcessingTime { get; private set; }
        public double pFactor { get; set; }

        #endregion

        #region Private
        #endregion



    }
}
