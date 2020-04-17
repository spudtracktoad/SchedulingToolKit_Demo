using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace SchedulingToolKit
{
    public class PrecedenceChain
    {
        private List<List<BaseJob>> BasePrecedenceChains = new List<List<BaseJob>>();
        private int _JobCount;

        public PrecedenceChain(List<BaseJob> baseJobs)
        {
            foreach (var item in baseJobs)
            {
                BuildList(item);
            }
        }

        private void BuildList(BaseJob newJob)
        {
            //check if the baseJob has any precedence requirments
            if(((MachineJob)newJob).Count > 0)
            {
                if (!Contains(newJob))
                {
                    foreach (var item in ((MachineJob)newJob).GetPrecidenceChain())
                    {
                        List<BaseJob> newJobList = new List<BaseJob>();
                        newJobList.Add(item);
                        newJobList.Add(newJob);

                        BasePrecedenceChains.Add(newJobList);
                        _JobCount += newJobList.Count;
                    }
                }
                else
                {
                    //find existing job and insert precedence before it in all lists
                }
            }
            else // no precedence
            {
                //check if the job is in the list
                if(!Contains(newJob))
                {
                    //add the job to the next empty list
                    List<BaseJob> newJobList = new List<BaseJob>();
                    newJobList.Add(newJob);
                    BasePrecedenceChains.Add(newJobList);
                    _JobCount++;
                }
            }
        }

        /// <summary>
        /// returns the number of Jobs in the class
        /// </summary>
        public int JobCount => _JobCount;
        
        /// <summary>
        /// returns the number of Chains in the class
        /// </summary>
        public int ChainCount => BasePrecedenceChains.Count;

        /// <summary>
        /// returns true if the job is in a precedence chain
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool Contains(BaseJob value)
        {
            foreach (var item in BasePrecedenceChains)
            {
                if (item.Contains(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}


//    /// <summary>
//    /// Adds the job to the precedence chain
//    /// </summary>
//    /// <param name="value"></param>
//    /// <returns></returns>
//    public void Add(BaseJob value)
//    {
//        var newJob = (MachineJob)value;
//        if ((_count == 0) && (newJob.Count ==0))
//        {
//            var tmpList = new List<BaseJob>();
//            tmpList.Add(newJob);
//            baseMachineJobs.Add(tmpList);
//            _count++;
//            return;
//        }
//        if(!Contains(value) && (newJob.Count == 0))
//        {
//            var tmpList = new List<BaseJob>();
//            tmpList.Add(newJob);
//            baseMachineJobs.Add(tmpList);
//            _count++;
//            return;
//        }
//        buildPrecedenceChain(value);
//    }

//    /// <summary>
//    /// removes all jobs from the chain
//    /// </summary>
//    public void Clear()
//    {
//        foreach (var item in baseMachineJobs)
//        {
//            item.Clear();
//        }
//        _count = 0;
//    }


//    /// <summary>
//    /// Removes the given job from the precedence chain
//    /// </summary>
//    /// <param name="value"></param>
//    public bool Remove(BaseJob value)
//    {
//        foreach (var item in baseMachineJobs)
//        {
//            if(item.Contains(value))
//            {
//                if(item.Remove(value))
//                {
//                    _count--;
//                    return true;
//                }
//            }
//        }
//        return false;
//    }

//    /// <summary>
//    /// returns the precedence chain for the give job
//    /// </summary>
//    /// <param name="machineJob"></param>
//    /// <returns></returns>
//    public List<BaseJob> GetPrecidenceChain(BaseJob machineJob)
//    {
//        throw new NotImplementedException();
//    }

//    private void buildPrecedenceChain(BaseJob newjob)
//    {

//    }
//}
//}
