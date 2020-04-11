using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public class TWeightedCompletionJobs : BaseMachineJob, IPrecidenceChain
    {
        private List<BaseMachineJob> precidenceChain = new List<BaseMachineJob>();
        private double pFactor;

        public TWeightedCompletionJobs(int weight, int processingTime, DateTime release, DateTime due)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = release;
            DueDate = due;
        }

        #region IPrecidenceChain
        public List<BaseMachineJob> GetPrecidenceChain()
        {
            return precidenceChain;
        }

        public double GetPFactor()
        {
            return pFactor;
        }

        public void SetPFactor(double Factor)
        {
            pFactor = Factor;
        }

        public void SetPreviousJob(BaseMachineJob job)
        {
            precidenceChain.Add(job);
        }

        #endregion
    }
}
