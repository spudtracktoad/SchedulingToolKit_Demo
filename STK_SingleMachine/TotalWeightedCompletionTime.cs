using System;
using System.Collections.Generic;
using System.Text;
using SchedulingToolKit;

namespace STK_SingleMachine
{
    class PresidenceChain
    {
        List<BaseMachineJob> chain = new List<BaseMachineJob>();
    }

    public class TotalWeightedCompletionTime
    {
        List<PresidenceChain> presidenceChains = new List<PresidenceChain>();
        public List<TWeightedCompletionJobs> machineJobsList { get; } = new List<TWeightedCompletionJobs>();
        //public List<MachineJob> scheduledMachineJob { get; private set; } = new List<MachineJob>();

        public List<TWeightedCompletionJobs> ScheduleJobsWithoutPresidence()
        {
            machineJobsList.Sort((x, y) => y.WeightedProcessingTime.CompareTo(x.WeightedProcessingTime));

            return machineJobsList;
        }

        public List<TWeightedCompletionJobs> ScheduleJobsWithPresidence()
        {

            return machineJobsList;
        }

        #region Private

        #endregion

    }
}
