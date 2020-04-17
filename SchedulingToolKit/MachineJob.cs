using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public class MachineJob : BaseJob
    {
        private List<BaseJob> _predecesorJobs = new List<BaseJob>();

        #region Constructor
        public MachineJob(int weight, int processingTime)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(1);
        }

        public MachineJob(int weight, int processingTime, string name)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(1);
            JobName = name;
        }

        public MachineJob(int weight, int processingTime, List<BaseJob> predecesors)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(1);
            _predecesorJobs = predecesors;
        }

        public MachineJob(int weight, int processingTime, List<BaseJob> predecesors, string name)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(1);
            _predecesorJobs = predecesors;
            JobName = name;
        }

        public MachineJob(int weight, int processingTime, DateTime release, DateTime due)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = release;
            DueDate = due;
        }

        public MachineJob(int weight, int processingTime, DateTime release, DateTime due, List<BaseJob> predecesors)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = release;
            DueDate = due;
            _predecesorJobs = predecesors;
        }

        public MachineJob(int weight, int processingTime, DateTime release, DateTime due, List<BaseJob> predecesors, string name)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = release;
            DueDate = due;
            JobName = name;
            _predecesorJobs = predecesors;
        }
        #endregion

        #region Public

        public void Add(BaseJob job)
        {
            _predecesorJobs.Add(job);
        }

        public void Clear()
        {
            _predecesorJobs.Clear();
        }

        public int Count => _predecesorJobs.Count;

        public bool Remove(BaseJob job)
        {
            return _predecesorJobs.Remove(job);
        }

        public bool Contains(BaseJob job)
        {
            return _predecesorJobs.Contains(job);
        }

        public List<BaseJob> GetPrecidenceChain()
        {
            return _predecesorJobs;
        }

        #endregion

    }
}
