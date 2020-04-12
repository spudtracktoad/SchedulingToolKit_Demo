using System;
using System.Collections.Generic;
using System.Text;
using SchedulingToolKit;

namespace STK_SingleMachine
{
    public class TotalWeightedCompletionTime : IPrecedenceChain
    {
        public List<TWeightedCompletionJobs> machineJobsList { get; } = new List<TWeightedCompletionJobs>();

        //public List<MachineJob> scheduledMachineJob { get; private set; } = new List<MachineJob>();

        public List<TWeightedCompletionJobs> ScheduleJobsWithoutPresidence()
        {
            machineJobsList.Sort((x, y) => y.WeightedProcessingTime.CompareTo(x.WeightedProcessingTime));

            return machineJobsList;
        }

        public List<TWeightedCompletionJobs> ScheduleJobsWithPresidence()
        {
            //While jobs need to be scheduled
            //foreach chain
                // calculate the pFactor
            //add the chain with the highets pFactor to the machineJobList
            return machineJobsList;
        }


        #region Interface

        public void SetJobPrecedence(BaseMachineJob jobA, BaseMachineJob jobB)
        {
            throw new NotImplementedException();
        }

        public List<BaseMachineJob> GetPrecidenceChain(BaseMachineJob machineJob)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private

        #endregion

    }
}
