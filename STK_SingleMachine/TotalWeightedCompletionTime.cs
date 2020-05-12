using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulingToolKit;

namespace STK_SingleMachine
{
    public class TotalWeightedCompletionTime : IBaseJobList, IPrecedenceChain
    {
        private PrecedenceChainCollection PrecedenceColleciton = new PrecedenceChainCollection();

        private List<MachineJob> unscheduledJobList = new List<MachineJob>();

        public List<MachineJob> scheduledJobList { get; private set; } = new List<MachineJob>();
        #region public 
        public List<MachineJob> ScheduleJobsWithoutPresidence()
        {
            unscheduledJobList.Sort((x, y) => y.WeightedProcessingTime.CompareTo(x.WeightedProcessingTime));

            return unscheduledJobList;
        }

        //Needs work 9May2020 will come back to this
        public List<MachineJob> ScheduleJobsWithPresidence()
        {
            throw new NotImplementedException();
            //While jobs need to be scheduled
            while(PrecedenceColleciton.Count>0)
            {
                //Find the chain with the highest pFactor
                //var nextChain = FindHighestPfactorChain();
                ////add chain to schedule list
                //foreach (var item in nextChain)
                //{
                //    scheduledJobList.Add(item);
                //}
            }
            return scheduledJobList;
        }

        #endregion


        #region Interface

        public BaseJob this[int index] { get => unscheduledJobList[index]; set => unscheduledJobList[index] = (MachineJob)value; }

        PrecedenceChain IPrecedenceChain.this[int index] { get => PrecedenceColleciton[index]; set => PrecedenceColleciton[index] = value; }

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
            PrecedenceColleciton.Clear();
            unscheduledJobList.Clear();
        }

        public bool Contains(BaseJob value)
        {
            return unscheduledJobList.Contains((MachineJob)value);
        }

        public void Add(PrecedenceChain chain)
        {
            PrecedenceColleciton.Add(chain);
        }

        public void Remove(PrecedenceChain chain)
        {
            PrecedenceColleciton.Remove(chain);
        }

        public bool Contains(PrecedenceChain value)
        {
            return PrecedenceColleciton.Contains(value);
        }

        public int Count
        {
            get { return unscheduledJobList.Count; }
        }

        public int ChainCount
        {
            get { return PrecedenceColleciton.Count; }
        }


        #endregion

        #region Private

        //private List<MachineJob> FindHighestPfactorChain()
        //{
        //    var result = new List<MachineJob>();
        //    List<List<MachineJob>> tmpMachineJobs = new List<List<MachineJob>>();

        //    foreach (var item in PrecedenceColleciton)
        //    {
        //        var tmpPfactor = item.Pop();
        //        List<MachineJob> tmp = new List<MachineJob>();
        //        tmp.Add((MachineJob)tmpPfactor);
        //        tmpMachineJobs.Add(tmp);
        //    }

        //    double max = 0;
        //    int resultChainIndex = -1;
        //    for(int index = 0; index < tmpMachineJobs.Count; index++)
        //    {
        //        for (int jndex = 0; jndex < tmpMachineJobs[index].Count; jndex++)
        //        {
        //            if (max == tmpMachineJobs[index][jndex].WeightedProcessingTime)
        //            {
        //                double nextMax = max;
        //                for (int nextChain = 0; nextChain < tmpMachineJobs.Count; nextChain++)
        //                {
        //                    for(int nextJob = 0; nextJob < tmpMachineJobs[nextChain].Count; nextJob++)
        //                    {
        //                        if (max == tmpMachineJobs[nextChain][nextJob].WeightedProcessingTime && nextMax >= tmpMachineJobs[nextChain][nextJob].WeightedProcessingTime)
        //                        {
        //                            var tmpJob = PrecedenceColleciton[nextChain].Pop();
        //                            tmpMachineJobs[nextChain].Add((MachineJob)tmpJob);
        //                            if(nextMax < tmpJob.WeightedProcessingTime)
        //                            {
        //                                nextMax = tmpJob.WeightedProcessingTime;
        //                                resultChainIndex = nextChain;
        //                            }
        //                        }
        //                    }
        //                }
        //                max = nextMax;
        //            }
        //            if(max < tmpMachineJobs[index][jndex].WeightedProcessingTime)
        //            {
        //                max = tmpMachineJobs[index][jndex].WeightedProcessingTime;
        //                resultChainIndex = index;
        //            }
        //        }

        //    }
        //    result = new List<MachineJob>(tmpMachineJobs[resultChainIndex]);
        //    tmpMachineJobs[resultChainIndex].Clear();

        //    for (int i = 0; i < tmpMachineJobs[i].Count; i++)
        //    {
        //        foreach (var item in tmpMachineJobs[i])
        //        {
        //            PrecedenceColleciton[i].Push(item);
        //        }
        //    }
        //    return result;
        //}

        #endregion

    }
}
