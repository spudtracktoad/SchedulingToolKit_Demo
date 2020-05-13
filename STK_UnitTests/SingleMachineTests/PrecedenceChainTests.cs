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

        TotalWeightedCompletionTime _totalWeightedCompletionTime;
        PrecedenceChainCollection _precedenceChainCollection;

        [SetUp]
        public void Setup()
        {
            _totalWeightedCompletionTime = new TotalWeightedCompletionTime();
            _precedenceChainCollection = new PrecedenceChainCollection();
        }

        [Test]
        public void AddSingleJobToChain()
        {
            MachineJob job1 = new MachineJob(6, 3, "job1");
            PrecedenceChain precedenceChain = new PrecedenceChain();

            precedenceChain.AddJob(job1);

            Assert.IsTrue(precedenceChain.Pfactor == job1.WeightedProcessingTime);
            Assert.AreEqual(precedenceChain.PeekNextJob.FirstOrDefault(), job1);
        }


        [Test]
        public void BCheckGetNextJobInChain()
        {
            MachineJob job1 = new MachineJob(6, 3, "job1");
            MachineJob job2 = new MachineJob(18, 6, "job2");
            PrecedenceChain precedenceChain = new PrecedenceChain();

            precedenceChain.AddJob(job2);
            precedenceChain.AddJob(job1);

            var tmp = precedenceChain.PeekNextJob;

            Assert.IsTrue(precedenceChain.Pfactor == job1.WeightedProcessingTime);
            Assert.AreEqual(precedenceChain.PeekNextJob.FirstOrDefault(), job1);
        }

        [Test]
        public void TestAddJobToNextJobeList()
        {
            MachineJob job1 = new MachineJob(6, 3, "job1");
            MachineJob job2 = new MachineJob(18, 6, "job2");
            PrecedenceChain precedenceChain = new PrecedenceChain();

            precedenceChain.AddJob(job2);
            precedenceChain.AddJob(job1);

            precedenceChain.CheckNextJob();

            Assert.IsTrue(precedenceChain.Pfactor == 5);

            var tmp = precedenceChain.PeekNextJob;

            Assert.AreEqual(tmp[0], job1);
            Assert.AreEqual(tmp[1], job2);
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
            PrecedenceChain chain2 = new PrecedenceChain();

            chain1.AddJob(job4);
            chain1.AddJob(job3);
            chain1.AddJob(job2);
            chain1.AddJob(job1);
            chain2.AddJob(job7);
            chain2.AddJob(job6);
            chain2.AddJob(job5);

            _precedenceChainCollection.AddChain(chain1);
            _precedenceChainCollection.AddChain(chain2);

            var firstChain = _precedenceChainCollection.GetNextScheduableJob();
            var secondChain = _precedenceChainCollection.GetNextScheduableJob();
            var ThirdChain = _precedenceChainCollection.GetNextScheduableJob();
            var FourthChain = _precedenceChainCollection.GetNextScheduableJob();
            var FithChain = _precedenceChainCollection.GetNextScheduableJob();

            Assert.IsTrue(FithChain.FirstOrDefault().JobName == job4.JobName);
            Assert.IsTrue(FourthChain.FirstOrDefault().JobName == job7.JobName);
            Assert.IsTrue(ThirdChain.FirstOrDefault().JobName == job3.JobName);
            Assert.IsTrue(secondChain.FirstOrDefault().JobName == job5.JobName);
            Assert.IsTrue(firstChain.FirstOrDefault().JobName == job1.JobName);
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
