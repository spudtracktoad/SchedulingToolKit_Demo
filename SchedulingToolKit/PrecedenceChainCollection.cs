using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public class PrecedenceChainCollection
    {
        private List<PrecedenceChain> _chains = new List<PrecedenceChain>();
        
        public void AddChain(PrecedenceChain chain)
        {
            _chains.Add(chain);
        }

        public void clear()
        {
            _chains.Clear();
            sortChains();
        }

        public List<BaseJob> GetNextScheduableJob()
        {
            List<BaseJob> result = _chains[0].NextJob;
            sortChains();

            return result;
        }


        private void sortChains()
        {

        }

    }
}
