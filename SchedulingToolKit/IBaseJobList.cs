using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchedulingToolKit
{
    public interface IBaseJobList
    {
        void Add(BaseMachineJob job);
        void Remove(BaseMachineJob job);
        int Count{ get; }
        BaseMachineJob this[int index]
        {
            get;
            set;
        }

    }
}
