using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public class TWeightedCompletionJobs : BaseMachineJob
    {
        #region Pivate
        private List<BaseMachineJob> predecesorJobList = new List<BaseMachineJob>();
        #endregion

        #region Constructor
        public TWeightedCompletionJobs(int weight, int processingTime, DateTime release, DateTime due)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = release;
            DueDate = due;
        }
        #endregion

        #region Public

        public void AddPredecesor(BaseMachineJob predecesorJob)
        {
            predecesorJobList.Add(predecesorJob);
        }

        public List<BaseMachineJob> GetPredecesorJobs()
        {
            return predecesorJobList;
        }

        #endregion

    }
}
