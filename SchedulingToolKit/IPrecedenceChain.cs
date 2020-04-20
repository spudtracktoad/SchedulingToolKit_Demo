using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public interface IPrecedenceChain
    {
        void Add(PrecedenceChain chain);
        
        void Remove(PrecedenceChain chain);

        void Clear();

        bool Contains(PrecedenceChain value);

        int Count { get; }

        PrecedenceChain this[int index]
        {
            get;
            set;
        }
    }
}
