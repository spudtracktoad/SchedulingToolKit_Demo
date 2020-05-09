using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public class PrecedenceChainCollection : IList<PrecedenceChain>
    {
        private List<PrecedenceChain> _chains = new List<PrecedenceChain>();

        #region List Interface

        public PrecedenceChain this[int index] { get => _chains[index]; set => _chains[index] = value; }

        public int Count => _chains.Count;

        public bool IsReadOnly => false;

        public void Add(PrecedenceChain item)
        {
            _chains.Add(item);
        }

        public void Clear()
        {
            _chains.Clear();
        }

        public bool Contains(PrecedenceChain item)
        {
            return _chains.Contains(item); ;
        }

        public void CopyTo(PrecedenceChain[] array, int arrayIndex)
        {
            _chains.CopyTo(array, arrayIndex);
        }

        public IEnumerator<PrecedenceChain> GetEnumerator()
        {
            return _chains.GetEnumerator();
        }

        public int IndexOf(PrecedenceChain item)
        {
            return _chains.IndexOf(item);
        }

        public void Insert(int index, PrecedenceChain item)
        {
            _chains.Insert(index, item);
        }

        public bool Remove(PrecedenceChain item)
        {
            return _chains.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _chains.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _chains.GetEnumerator();
        }

        #endregion
    }
}
