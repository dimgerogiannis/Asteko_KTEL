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

        public enum BusPart
        {
            Back,
            Full,
            Front
        }

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

        #region Sanitary
        public static string SanitaryComplaintCategoryFromEnumToDatabaseEquivalant(SanitaryComplaintCategory cat)
        {
            switch (cat)
            {
                case SanitaryComplaintCategory.CloseDistance:
                    return "close_distance";
                case SanitaryComplaintCategory.HasIllnessSymptoms:
                    return "has_illness_symptoms";
                default:
                    return "wear_mask_refusal";
            }
        }

        public static SanitaryComplaintCategory SanitaryComplaintCategoryFromDatabaseToEnumEquivalant(string cat)
        {
            switch (cat)
            {
                case "close_distance":
                    return SanitaryComplaintCategory.CloseDistance;
                case "has_illness_symptoms":
                    return SanitaryComplaintCategory.HasIllnessSymptoms;
                default:
                    return SanitaryComplaintCategory.WeakMaskRefusal;
            }
        }
        #endregion

        #region Status
        public static string StatusFromEnumToDatabaseEquivalant(Status status)
        {
            switch (status)
            {
                case Status.Accepted:
                    return "accepted";
                case Status.Rejected:
                    return "rejected";
                default:
                    return "pending";
            }
        }

        public static Status StatusFromDatabaseToEnumEquivalant(string status)
        {
            switch (status)
            {
                case "accepted":
                    return Status.Accepted;
                case "rejected":
                    return Status.Rejected;
                default:
                    return Status.Pending;
            }
        }
        #endregion

        #region ItineraryStatus
        public static string ItineraryStatusFromEnumToDatabaseEquivalant(ItineraryStatus status)
        {
            switch (status)
            {
                case ItineraryStatus.Delayed:
                    return "delayed";
                default:
                    return "no_delayed";
            }
        }
        
        public static ItineraryStatus ItineraryStatusFromDatabaseToEnumEquivalant(string status)
        {
            switch (status)
            {
                case "delayed":
                    return ItineraryStatus.Delayed;
                default:
                    return ItineraryStatus.NoDelayed;
            }
        }
        #endregion

        #region Category
        public static string CategoryFromEnumToDatabaseEquivalant(Category category)
        {
            switch (category)
            {
                case Category.DissabilityIssues:
                    return "dissabilities";
                case Category.LowIncome:
                    return "low_income";
                case Category.Soldier:
                    return "soldier";
                default:
                    return "student";
            }
        }

        public static Category CategoryFromDatabaseToEnumEquivalant(string category)
        {
            switch (category)
            {
                case "dissabilities":
                    return Category.DissabilityIssues;
                case "low_income":
                    return Category.LowIncome;
                case "soldier":
                    return Category.Soldier;
                default:
                    return Category.Student;
            }
        }
        #endregion

        #region ClientComplaintCategory

        public static string ClientComplaintCategoryFromEnumToDatabaseEquivalant(ClientComplaintCategory category)
        {
            switch (category)
            {
                case ClientComplaintCategory.AggresiveBehaviour:
                    return "aggresive_behavior";
                case ClientComplaintCategory.CarelessDriving:
                    return "aggresive_driving";
                case ClientComplaintCategory.DrivingRuleViolation:
                    return "driving_rules_violation";
                case ClientComplaintCategory.LateForNoReason:
                    return "late_for_no_reason";
                default:
                    return "rude_bus_driver";
            }
        }

        public static ClientComplaintCategory ClientComplaintCategoryFromDatabaseToEnumEquivalant(string category)
        {
            switch (category)
            {
                case "aggresive_behavior":
                    return ClientComplaintCategory.AggresiveBehaviour;
                case "aggresive_driving":
                    return ClientComplaintCategory.CarelessDriving;
                case "driving_rules_violation":
                    return ClientComplaintCategory.DrivingRuleViolation;
                case "late_for_no_reason":
                    return ClientComplaintCategory.LateForNoReason;
                default:
                    return ClientComplaintCategory.Rude;
            }
        }

        #endregion

        #region BusSize

        public static string BusSizeFromEnumToDatabaseEquivalant(BusSize size)
        {
            switch (size)
            {
                case BusSize.LARGE:
                    return "large";
                case BusSize.MEDIUM:
                    return "medium";
                default:
                    return "small";
            }
        }

        public static BusSize BusSizeFromDatabaseToEnumEquivalant(string size)
        {
            switch (size)
            {
                case "large":
                    return BusSize.LARGE;
                case "medium":
                    return BusSize.MEDIUM;
                default:
                    return BusSize.SMALL;
            }
        }

        #endregion
    }
}
