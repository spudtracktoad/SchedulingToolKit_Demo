using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SchedulingToolKit;
using STK_SingleMachine;

namespace STK_UnitTests
{
    public class TotalWeightedCompletionTimeTests
    {
        TotalWeightedCompletionTime _totalWeightedCompletionTime;

        [SetUp]
        public void Setup()
        {
            _totalWeightedCompletionTime = new TotalWeightedCompletionTime();
        }

        #region Scheduling test

        [Test]
        public void AddSingleMachineToTotalWeightedCompletionTime()
        {
            MachineJob job1 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            _totalWeightedCompletionTime.Add(job1);

            Assert.IsTrue(_totalWeightedCompletionTime.Count == 1);
        }

        [Test]
        public void RemoveSingleMachineToTotalWeightedCompletionTime()
        {
            MachineJob job1 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            MachineJob job2 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            _totalWeightedCompletionTime.Add(job1);
            _totalWeightedCompletionTime.Add(job2);

            Assert.IsTrue(_totalWeightedCompletionTime.Count == 2);

            _totalWeightedCompletionTime.Remove(job2);

            Assert.IsTrue(_totalWeightedCompletionTime.Count == 1);
        }

        [Test]
        public void ScheduleTotalWeightedCompletionTimeNoPresedence()
        {
            MachineJob job1 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            MachineJob job2 = new MachineJob(5, 2, DateTime.Now, DateTime.Now.AddDays(3));
            _totalWeightedCompletionTime.Add(job1);
            _totalWeightedCompletionTime.Add(job2);

            Assert.AreEqual(job2, _totalWeightedCompletionTime.ScheduleJobsWithoutPresidence().FirstOrDefault());
        }

        [Test]
        public void ScheduleTotalWeightedCompletionTimeNoPresedenceRandomJobs()
        {
            foreach (var item in buildJobList(500))
            {
                _totalWeightedCompletionTime.Add(item);
            }

            _totalWeightedCompletionTime.ScheduleJobsWithoutPresidence();

            for(int index = 0; index < _totalWeightedCompletionTime.Count-1; index++)
            {
                Assert.IsTrue(_totalWeightedCompletionTime[index].WeightedProcessingTime >= _totalWeightedCompletionTime[index + 1].WeightedProcessingTime);
            }

        }

        #endregion

        #region Helper Functions
        private List<MachineJob> buildJobList(int numberOfJobs)
        {
            List<MachineJob> result = new List<MachineJob>();
            for(int index = 0; index < numberOfJobs; index++)
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