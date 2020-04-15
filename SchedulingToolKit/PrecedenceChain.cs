using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace SchedulingToolKit
{
    public class PrecedenceChain : IPrecedenceChain
    {
        private List<List<BaseJob>> baseMachineJobs = new List<List<BaseJob>>();
        private int _count;

        /// <summary>
        /// returns the number of chains in the class
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Adds the job to the precedence chain
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Add(BaseJob value)
        {
            var newJob = (MachineJob)value;
            if ((_count == 0) && (newJob.Count ==0))
            {
                var tmpList = new List<BaseJob>();
                tmpList.Add(newJob);
                baseMachineJobs.Add(tmpList);
                _count++;
                return;
            }
            if(!Contains(value) && (newJob.Count == 0))
            {
                var tmpList = new List<BaseJob>();
                tmpList.Add(newJob);
                baseMachineJobs.Add(tmpList);
                _count++;
                return;
            }
            buildPrecedenceChain(value);
        }

        /// <summary>
        /// removes all jobs from the chain
        /// </summary>
        public void Clear()
        {
            foreach (var item in baseMachineJobs)
            {
                item.Clear();
            }
            _count = 0;
        }

        /// <summary>
        /// returns true if the job is in a precedence chain
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(BaseJob value)
        {
            foreach (var item in baseMachineJobs)
            {
                if (item.Contains(value))
                {
                    return item.Remove(value);
                }
            }
            return false;
        }

        /// <summary>
        /// Removes the given job from the precedence chain
        /// </summary>
        /// <param name="value"></param>
        public bool Remove(BaseJob value)
        {
            foreach (var item in baseMachineJobs)
            {
                if(item.Contains(value))
                {
                    if(item.Remove(value))
                    {
                        _count--;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// returns the precedence chain for the give job
        /// </summary>
        /// <param name="machineJob"></param>
        /// <returns></returns>
        public List<BaseJob> GetPrecidenceChain(BaseJob machineJob)
        {
            throw new NotImplementedException();
        }

        private void buildPrecedenceChain(BaseJob newjob)
        {

        }
    }
}
