using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public interface IPrecedenceChain
    {
        /// <summary>
        /// Adds the job to the precedence chain
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void Add(BaseJob value);

        /// <summary>
        /// removes all jobs from the chain
        /// </summary>
        void Clear();

        /// <summary>
        /// returns true if the job is in a precedence chain
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Contains(BaseJob value);

        /// <summary>
        /// removes the precedence chain for the give job
        /// </summary>
        /// <param name="machineJob"></param>
        /// <returns></returns>
        bool Remove(BaseJob value);
        
        /// <summary>
        /// returns the number of chains in the class
        /// </summary>
        int Count { get; }

    }
}
