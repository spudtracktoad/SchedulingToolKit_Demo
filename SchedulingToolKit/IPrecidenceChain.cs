using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    interface IPrecidenceChain
    {
        void SetPreviousJob(BaseMachineJob job);
        List<BaseMachineJob> GetPrecidenceChain();
        double GetPFactor();
        void SetPFactor(double pFactor);
    }
}
