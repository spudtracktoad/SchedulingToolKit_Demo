using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SchedulingToolKit;

namespace STK_UnitTests.SingleMachineTests
{
    public class MachineJobTests
    {
        #region MachineJob Test

        [Test]
        public void AddJobToPrecedenceList()
        {
            MachineJob job1 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            MachineJob job2 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            job2.Add(job1);

            Assert.IsTrue(job2.Contains(job1));
        }

        [Test]
        public void RemoveJobFromPrecedenceList()
        {
            MachineJob job1 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            MachineJob job2 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            job2.Add(job1);

            Assert.IsTrue(job2.Contains(job1));

            job2.Remove(job1);

            Assert.IsFalse(job2.Contains(job1));
        }

        [Test]
        public void ClearJobPrecedenceList()
        {
            MachineJob job1 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            MachineJob job2 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            MachineJob job3 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            job2.Add(job1);
            job2.Add(job3);

            Assert.IsTrue(job2.Count == 2);

            job2.Clear();

            Assert.IsTrue(job2.Count == 0);
        }

        //get job precedence list
        [Test]
        public void GetJobPrecedenceList()
        {
            MachineJob job1 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            MachineJob job2 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            MachineJob job3 = new MachineJob(3, 2, DateTime.Now, DateTime.Now.AddDays(3));
            job2.Add(job1);
            job2.Add(job3);

            var tmp = job2.GetPrecidenceChain();

            foreach (var item in tmp)
            {
                Assert.IsTrue((item == job1) || (job3 == item));
            }
        }

        #endregion

    }
}
