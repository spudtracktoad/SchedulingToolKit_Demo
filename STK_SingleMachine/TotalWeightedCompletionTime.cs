using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SchedulingToolKit;

namespace STK_SingleMachine
{
    public class TotalWeightedCompletionTime : IBaseJobList
    {
        private List<MachineJob> scheduledJobList = new List<MachineJob>();

        private List<MachineJob> unscheduledJobList = new List<MachineJob>();

        //public List<MachineJob> scheduledMachineJob { get; private set; } = new List<MachineJob>();
        #region public 
        public List<MachineJob> ScheduleJobsWithoutPresidence()
        {
            unscheduledJobList.Sort((x, y) => y.WeightedProcessingTime.CompareTo(x.WeightedProcessingTime));

            return unscheduledJobList;
        }

        public List<MachineJob> ScheduleJobsWithPresidence()
        {
            //While jobs need to be scheduled
            //foreach chain
                // calculate the pFactor
            //add the chain with the highets pFactor to the machineJobList
            return unscheduledJobList;
        }

        #endregion


        #region Interface

        public BaseJob this[int index] { get => unscheduledJobList[index]; set => unscheduledJobList[index] = (MachineJob)value; }

        public void Add(BaseJob newJob)
        {
            unscheduledJobList.Add((MachineJob)newJob);
        }
        public void Add(MachineJob newJob)
        {
            unscheduledJobList.Add(newJob);
        }

        public void Remove(BaseJob job)
        {
            unscheduledJobList.Remove((MachineJob)job);
        }

        public void Clear()
        {
            scheduledJobList.Clear();
            unscheduledJobList.Clear();
        }

        public bool Contains(BaseJob value)
        {
            return unscheduledJobList.Contains((MachineJob)value);
        }

        public int Count
        {
            get { return unscheduledJobList.Count; }
        }

        #endregion

        #region Private

        #endregion

    }
}
