using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public class PrecedenceChainCollection
    {
        private List<PrecedenceChain> _chains = new List<PrecedenceChain>();
        private bool sorted;
        
        public void AddChain(PrecedenceChain chain)
        {
            _chains.Add(chain);
            if(_chains.Count > 1)
                sortChains();
        }

        public void clear()
        {
            _chains.Clear();
        }

        public List<BaseJob> GetNextScheduableJob()
        {
            //throw new NotImplementedException();
            List<BaseJob> result = _chains[0].GetNextJob;
            if (_chains.Count > 1)
                sortChains();

            return result;
        }


        private void sortChains()
        {
            sorted = false;
            bool swap = false;
            int index = 0;
            while(!sorted)
            {
                swap = false;
                if (index < _chains.Count -1)
                {
                    //pfactor equal
                    if(_chains[index].Pfactor == _chains[index+1].Pfactor)
                    {
                        if (!_chains[index].ChainComplete || !_chains[index + 1].ChainComplete)
                        {
                            _chains[index].CheckNextJob();
                            _chains[index + 1].CheckNextJob();
                            swap = true;
                        }
                    }
                    else if(_chains[index].Pfactor < _chains[index+1].Pfactor)//pfactor greater than
                    {
                        var tmpChain = _chains[index];
                        _chains[index] = _chains[index + 1];
                        _chains[index + 1] = tmpChain;
                        swap = true;
                    } 
                    if(!swap)
                    {
                        sorted = true;
                    }
                    index++;
                }
                else
                {
                    index = 0;
                }
            }
        }
    }
}
