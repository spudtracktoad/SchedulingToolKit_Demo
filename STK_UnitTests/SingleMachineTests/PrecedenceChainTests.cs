﻿using System;
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

        TotalWeightedCompletionTime _totalWeightedCompletionTime;

        [SetUp]
        public void Setup()
        {
            _totalWeightedCompletionTime = new TotalWeightedCompletionTime();
        }

        [Test]
        public void AddSingleChain()
        {
            var tmpList = buildJobList(4);

            PrecedenceChain testChain = new PrecedenceChain();
            foreach (var item in tmpList)
            {
                testChain.Push(item);
            }

            _totalWeightedCompletionTime.Add(testChain);

            Assert.IsTrue(_totalWeightedCompletionTime.ChainCount == 1);
        }


        [Test]
        public void AddmultipleChains()
        {
            for (int i = 0; i < 4; i++)
            {
                var tmpList = buildJobList(4);

                PrecedenceChain testChain = new PrecedenceChain();
                foreach (var item in tmpList)
                {
                    testChain.Push(item);
                }

                _totalWeightedCompletionTime.Add(testChain);

            }

            Assert.IsTrue(_totalWeightedCompletionTime.ChainCount == 4);
        }

        [Test]
        public void testSchedule1()
        {
            MachineJob job1 = new MachineJob(6, 3, "job1");
            MachineJob job2 = new MachineJob(18, 6, "job2");
            MachineJob job3 = new MachineJob(12, 6, "job3");
            MachineJob job4 = new MachineJob(8, 5, "job4");
            MachineJob job5 = new MachineJob(8, 4, "job5");
            MachineJob job6 = new MachineJob(17, 8, "job6");
            MachineJob job7 = new MachineJob(18, 10, "job7");
            PrecedenceChain chain1 = new PrecedenceChain();
            PrecedenceChain chain2= new PrecedenceChain();

            chain1.Push(job4);
            chain1.Push(job3);
            chain1.Push(job2);
            chain1.Push(job1);
            chain2.Push(job7);
            chain2.Push(job6);
            chain2.Push(job5);

            _totalWeightedCompletionTime.Add(chain2);
            _totalWeightedCompletionTime.Add(chain1);

            var schedule = _totalWeightedCompletionTime.ScheduleJobsWithPresidence();
        }

        #region Helper Functions
        private List<MachineJob> buildJobList(int numberOfJobs)
        {
            List<MachineJob> result = new List<MachineJob>();
            for (int index = 0; index < numberOfJobs; index++)
            {
                var rand = new Random();
                var rand2 = new Random();
                var randWeight = rand.Next();
                var randProces = rand2.Next();
                MachineJob randJob = new MachineJob(randWeight, randProces, DateTime.Now, DateTime.Now.AddDays(4));
                result.Add(randJob);
            }
            return result;
        }
        #endregion
    }
}
