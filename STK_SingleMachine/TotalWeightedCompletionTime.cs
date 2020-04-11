using System;
using System.Collections.Generic;
using System.Text;
using SchedulingToolKit;

namespace STK_SingleMachine
{
    public class TotalWeightedCompletionTime
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

            return machineJobsList;
        }

    }
}
