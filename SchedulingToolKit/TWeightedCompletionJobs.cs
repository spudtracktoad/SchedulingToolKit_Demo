using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingToolKit
{
    public class TWeightedCompletionJobs : BaseMachineJob
    {
        public TWeightedCompletionJobs(int weight, int processingTime, DateTime release, DateTime due)
        {
            JobID = Guid.NewGuid();
            Weight = weight;
            ProcessTime = processingTime;
            RelaseDate = release;
            DueDate = due;
        }

    }
}
