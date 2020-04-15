using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SchedulingToolKit;
using STK_SingleMachine;

namespace STK_UnitTests.SingleMachineTests
{
    public class PrecedenceChainTests
    {

        PrecedenceChain _precedenceChain;

        [SetUp]
        public void Setup()
        {
            _precedenceChain = new PrecedenceChain();
        }

        [Test]
        public void addJobWithoutPrecedence()
        {
            _precedenceChain.Add(new MachineJob(3, 4));

            Assert.IsTrue(_precedenceChain.Count == 1);
        }

        [Test]
        public void AddMultipleJobsWithPutPrecedence()
        {
            var testInput = buildRandomjobs(4);
            foreach (var item in testInput)
            {
                _precedenceChain.Add(item);
            }

            Assert.IsTrue(_precedenceChain.Count == 4);
        }

        [Test]
        public void addSingleJobWithPrecedence()
        {
            MachineJob job1 = new MachineJob(3, 4);
            MachineJob job2 = new MachineJob(4, 3);

            job2.Add(job1);


        }



        #region helper Functions
        private List<BaseJob> buildRandomjobs(int number)
        {
            List<BaseJob> result = new List<BaseJob>();
            var rand = new Random();
            var rand2 = new Random();
            var randWeight = rand.Next();
            var randProces = rand2.Next();
            for (int i = 0; i < number; i++)
            {
                result.Add(new MachineJob(randWeight, randProces));
            }
            return result;
        }
        #endregion
    }
}
