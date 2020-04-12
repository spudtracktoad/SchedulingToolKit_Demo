using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public interface IPrecedenceChain
    {
        /// <summary>
        /// jobA comes before jobB
        /// </summary>
        /// <param name="jobA"></param>
        /// <param name="jobB"></param>
        void SetJobPrecedence(BaseMachineJob jobA, BaseMachineJob jobB);
        /// <summary>
        /// Get the precedence chain of machineJob
        /// </summary>
        /// <param name="machineJob"></param>
        /// <returns></returns>
        List<BaseMachineJob> GetPrecidenceChain(BaseMachineJob machineJob);
    }
}
