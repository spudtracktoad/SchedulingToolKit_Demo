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
            _totalWeightedCompletionTime.Add(job1);

            Assert.IsTrue(_totalWeightedCompletionTime.Count == 1);
        }

        [Test]
        public void RemoveSingleMachineToTotalWeightedCompletionTime()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            TWeightedCompletionJobs job2 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            _totalWeightedCompletionTime.Add(job1);
            _totalWeightedCompletionTime.Add(job2);

            Assert.IsTrue(_totalWeightedCompletionTime.Count == 2);

            _totalWeightedCompletionTime.Remove(job2);

            Assert.IsTrue(_totalWeightedCompletionTime.Count == 1);
        }

        [Test]
        public void ScheduleTotalWeightedCompletionTimeNoPresedence()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            TWeightedCompletionJobs job2 = new TWeightedCompletionJobs(5, 2, DateTime.Now, DateTime.Now.AddDays(3));
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

        [Test]
        public void BuildPrecedenceChain()
        {
            TWeightedCompletionJobs job1 = new TWeightedCompletionJobs(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            TWeightedCompletionJobs job2 = new TWeightedCompletionJobs(7, 4, DateTime.Now, DateTime.Now.AddDays(3));
            TWeightedCompletionJobs job3 = new TWeightedCompletionJobs(2, 5, DateTime.Now, DateTime.Now.AddDays(3));
            TWeightedCompletionJobs job4 = new TWeightedCompletionJobs(6, 3, DateTime.Now, DateTime.Now.AddDays(3));
            _totalWeightedCompletionTime.Add(job1);
            _totalWeightedCompletionTime.Add(job2);
            _totalWeightedCompletionTime.Add(job3);
            _totalWeightedCompletionTime.Add(job4);

            _totalWeightedCompletionTime.SetJobPrecedence(job3, job2);

            var job3First = _totalWeightedCompletionTime.GetPrecidenceChain(job2);

            Assert.IsTrue(job3First.FirstOrDefault() == job3);
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