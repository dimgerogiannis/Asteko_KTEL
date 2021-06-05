using System.Collections.Generic;

namespace ClassesFolder
{
    public interface IChief
    {
        void ChangeDistributionManagerState(ItineraryDistributionManager distributor, bool state);
        bool CheckDuplicateUsername(string username);
        void DeleteBusDriver(string username);
        void DeleteClientComplaints(List<ClientComplaint> complaints);
        void DeleteEmployee(string username);
        void DeletePaidLeaveApplications(List<PaidLeaveApplication> applications);
        void DeletePaidLeaveDates(string username);
        void DeleteUser(string username);
        BusDriver GetBusDriver(string username);
        List<DismissalPetition> GetDismissalPetitions();
        List<ItineraryDistributionManager> GetDistributionManagers();
        List<Employee> GetEmployees();
        List<PaidLeaveApplication> GetPaidLeaveApplications(string username);
        List<Transaction> GetTransactions(string startDate, string endDate);
        List<PaidLeaveApplication> GetUncheckedPaidLeaveApplications();
        string GetUserFullNameFromDatabase(string username);
        void InsertBusDriverInInDatabase(string username);
        void InsertEmployeeInDatabase(string username, int salary, int experience);
        void InsertItineraryDistributionManagerInInDatabase(string username);
        void InsertQualityManagerInInDatabase(string username);
        void InsertUserInDatabase(string username, string password, string name, string surname, string prop);
        void SetDiscountCategoryPercentage(Enums.Category category, int percentage);
        void SetNewMonthlyCardPrice(int value);
        void SetNewTicketPrice(decimal value);
    }
}