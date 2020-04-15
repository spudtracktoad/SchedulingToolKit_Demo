using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchedulingToolKit
{
    public interface IBaseJobList
    {
        void Add(BaseJob job);
        void Remove(BaseJob job);
        int Count{ get; }
        BaseJob this[int index]
        {
            get;
            set;
        }

    }
}
