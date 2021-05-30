using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesFolder
{
    public static class Enums
    {
        public enum BusSize
        {
            SMALL,
            MEDIUM,
            LARGE
        };

        public enum ClientComplaintCategory
        {
            Rude,
            LateForNoReason,
            AggresiveBehaviour,
            CarelessDriving,
            DrivingRuleViolation
        };

        public enum Category : int
        {
            Student,
            Soldier,
            DissabilityIssues,
            LowIncome
        };

        public enum ItineraryStatus
        {
            NoDelayed,
            Delayed
        };

        public enum Status
        {
            Pending,
            Accepted,
            Rejected
        };

        public enum SanitaryComplaintCategory
        {
            WeakMaskRefusal,
            CloseDistance,
            HasIllnessSymptoms
        };
    }
}
