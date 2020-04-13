using System;
using System.Collections.Generic;
using System.Text;
using SchedulingToolKit;

namespace STK_SingleMachine
{
    public class TotalWeightedCompletionTime : IPrecedenceChain, IBaseJobList
    {
        private List<List<BaseMachineJob>> precedenceChainsList = new List<List<BaseMachineJob>>();

        private List<TWeightedCompletionJobs> machineJobsList { get; } = new List<TWeightedCompletionJobs>();

        //public List<MachineJob> scheduledMachineJob { get; private set; } = new List<MachineJob>();
        #region public 
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

        #endregion


        #region Interface

        public void SetJobPrecedence(BaseMachineJob jobA, BaseMachineJob jobB)
        {
            TWeightedCompletionJobs TWeigthJobB = (TWeightedCompletionJobs)jobB;
            TWeigthJobB.AddPredecesor(jobA);
            updatePrecedenceChains();
        }

        public List<BaseMachineJob> GetPrecidenceChain(BaseMachineJob machineJob)
        {
            if (machineJobsList.Contains((TWeightedCompletionJobs)machineJob))
            {
                return ((TWeightedCompletionJobs)machineJob).GetPredecesorJobs();
            }
            return new List<BaseMachineJob>();
        }

        public BaseMachineJob this[int index] { get => machineJobsList[index]; set => machineJobsList[index] = (TWeightedCompletionJobs)value; }

        public void Add(BaseMachineJob newJob)
        {
            machineJobsList.Add((TWeightedCompletionJobs)newJob);
        }
        public void Add(TWeightedCompletionJobs newJob)
        {
            machineJobsList.Add(newJob);
        }

        public void Remove(BaseMachineJob job)
        {
            machineJobsList.Remove((TWeightedCompletionJobs)job);
        }

        public int Count
        {
            get { return machineJobsList.Count; }
        }
        
        #endregion 

        #region Private
        
        private void updatePrecedenceChains()
        {
            //do some stuff here......
        }
        #endregion

    }
}
