using System;
using System.Collections.Generic;
using System.Linq;
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
            //_precedenceChain = new PrecedenceChain();
        }

        [Test]
        public void addJobWithoutPrecedence()
        {
            List<BaseJob> tmp = new List<BaseJob>();
            tmp.Add(new MachineJob(3, 4));

            _precedenceChain = new PrecedenceChain(tmp);

            Assert.IsTrue(_precedenceChain.JobCount == 1);
        }

        [Test]
        public void AddMultipleJobsWithPutPrecedence()
        {
            var testInput = buildRandomjobs(4);

            _precedenceChain = new PrecedenceChain(testInput);

            Assert.IsTrue(_precedenceChain.JobCount == 4);
        }

        [Test]
        public void addSingleJobWithPrecedence()
        {
            MachineJob job1 = new MachineJob(3, 4, "job1");
            MachineJob job2 = new MachineJob(4, 3, "job2");

            job2.Add(job1);
            List<BaseJob> tmpjobList = new List<BaseJob>();
            tmpjobList.Add(job2);
            tmpjobList.Add(job1);

            _precedenceChain = new PrecedenceChain(tmpjobList);

            Assert.IsTrue(_precedenceChain.ChainCount == 1);
            Assert.IsTrue(_precedenceChain.JobCount == 2);
        }

        [Test]
        public void addMultipleJobsWithPrecedence()
        {
            MachineJob job1 = new MachineJob(3, 4, "job1");
            MachineJob job2 = new MachineJob(4, 3, "job2");
            MachineJob job3 = new MachineJob(3, 4, "job3");
            MachineJob job4 = new MachineJob(4, 3, "job4");

            job2.Add(job1);
            job2.Add(job4);
            job1.Add(job3);
            List<BaseJob> tmpjobList = new List<BaseJob>();
            tmpjobList.Add(job2);
            tmpjobList.Add(job1);
            tmpjobList.Add(job3);
            tmpjobList.Add(job4);

            _precedenceChain = new PrecedenceChain(tmpjobList);

            Assert.IsTrue(_precedenceChain.ChainCount == 1);
            Assert.IsTrue(_precedenceChain.JobCount == 2);
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
