using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace SchedulingToolKit
{
    public class PrecedenceChain
    {
        private List<BaseJob> _toScheduleChain;
        private int endIndex;
        private int startIndex;

        public PrecedenceChain()
        {
            _toScheduleChain = new List<BaseJob>();
            endIndex = 0;
            startIndex = 0;
        }

        /// <summary>
        /// The total weighted processing time for all jobs in the NextJob list
        /// </summary>
        public double Pfactor 
        { 
            get 
            {
                double result = 0;
                for(int index = startIndex; index < endIndex; index++)
                {
                    result += _toScheduleChain[index].WeightedProcessingTime;
                }
                return result; 
            } 
        }

        /// <summary>
        /// List of the next job(s) to be schedule
        /// </summary>
        public List<BaseJob> NextJob 
        { 
            get
            {
                List<BaseJob> result = new List<BaseJob>();
                for (int index = startIndex; index < endIndex; index++)
                {
                    result.Add(_toScheduleChain[index]);
                }
                startIndex = endIndex;
                endIndex = startIndex + 1;
                return result;

            }
        }
        /// <summary>
        /// Each job added must be the predesor of the previous job added.
        /// Except for the first job added which should have not predecesors
        /// </summary>
        /// <param name="job"></param>
        public void AddJob(BaseJob job)
        {
            _toScheduleChain.Insert(0, job);
            endIndex = 1;
        }

        /// <summary>
        /// Add the next job in the list to the next job list
        /// </summary>
        public void CheckNextJob()
        {
            endIndex++;
        }
    }

}
       