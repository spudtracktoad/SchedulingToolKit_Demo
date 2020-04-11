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

        [Test]
        public void AddSingleMachineToTotalWeightedCompletionTime()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            _totalWeightedCompletionTime.machineJobsList.Add(job1);

            Assert.IsTrue(_totalWeightedCompletionTime.machineJobsList.Count == 1);
        }

        [Test]
        public void RemoveSingleMachineToTotalWeightedCompletionTime()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            TWeightedCompletionJobs job2 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            _totalWeightedCompletionTime.machineJobsList.Add(job1);
            _totalWeightedCompletionTime.machineJobsList.Add(job2);

            Assert.IsTrue(_totalWeightedCompletionTime.machineJobsList.Count == 2);

            _totalWeightedCompletionTime.machineJobsList.Remove(job2);

            Assert.IsTrue(_totalWeightedCompletionTime.machineJobsList.Count == 1);
        }

        [Test]
        public void ScheduleTotalWeightedCompletionTimeNoPresedence()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            TWeightedCompletionJobs job2 = new TWeightedCompletionJobs(5, 2, DateTime.Now, DateTime.Now.AddDays(3));
            _totalWeightedCompletionTime.machineJobsList.Add(job1);
            _totalWeightedCompletionTime.machineJobsList.Add(job2);

            Assert.AreEqual(job2, _totalWeightedCompletionTime.ScheduleJobsWithoutPresidence().FirstOrDefault());
        }

        [Test]
        public void ScheduleTotalWeightedCompletionTimeNoPresedenceRandomJobs()
        {
            foreach (var item in buildJobList(500))
            {
                _totalWeightedCompletionTime.machineJobsList.Add(item);
            }

            _totalWeightedCompletionTime.ScheduleJobsWithoutPresidence();

            for(int index = 0; index < _totalWeightedCompletionTime.machineJobsList.Count-1; index++)
            {
                Assert.IsTrue(_totalWeightedCompletionTime.machineJobsList[index].WeightedProcessingTime >= _totalWeightedCompletionTime.machineJobsList[index + 1].WeightedProcessingTime);
            }

        }

        [Test]
        public void SetSinglePreviousJob()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            TWeightedCompletionJobs job2 = new TWeightedCompletionJobs(5, 2, DateTime.Now, DateTime.Now.AddDays(3));
            job1.SetPreviousJob(job2);

            Assert.IsTrue(job1.GetPrecidenceChain().Count == 1);
            Assert.AreEqual(job1.GetPrecidenceChain().FirstOrDefault(), job2);

        }

        [Test]
        public void SetMultiplePreviousJob()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            var length = 3;
            var previousJobs = buildJobList(length);
            foreach (var item in previousJobs)
            {
                job1.SetPreviousJob(item);
            }

            Assert.IsTrue(job1.GetPrecidenceChain().Count == length);

            foreach (var item in job1.GetPrecidenceChain())
            {
                Assert.IsTrue(previousJobs.Contains(item));
            }

        }

        [Test]
        public void TestPFactor()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            var testPFactor = 3.5;

            job1.SetPFactor(testPFactor);

            Assert.AreEqual(job1.GetPFactor(), testPFactor, .01);

        }

        #region Helper Functions
        private List<TWeightedCompletionJobs> buildJobList(int numberOfJobs)
        {
            List<TWeightedCompletionJobs> result = new List<TWeightedCompletionJobs>();
            for(int index = 0; index < numberOfJobs; index++)
            {
                var rand = new Random();
                var rand2 = new Random();
                var randWeight = rand.Next();
                var randProces = rand2.Next();
                TWeightedCompletionJobs randJob = new TWeightedCompletionJobs(randWeight, randProces, DateTime.Now, DateTime.Now.AddDays(4));
                result.Add(randJob);
            }
            return result;
        }
        #endregion
    }
}