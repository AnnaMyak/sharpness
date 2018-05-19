using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Repositories
{
    public interface IReportRepository
    {
        //Liste
        IEnumerable<Report> GetAllReports();
        IEnumerable<Report> GetAllReportsLastWeek();
        IEnumerable<Report> GetAllReportsLastMonth();
        IEnumerable<Report> GetAllReportsLastYear();


        IEnumerable<Report> GetAllReportsByUserId(string UserId);
        IEnumerable<Report> GetAllReportsByUserIdLastWeek(string UserId);
        IEnumerable<Report> GetAllReportsByUserLastMonth(string UserId);
        IEnumerable<Report> GetAllReportsByUserLastYear(string UserId);



        
        IEnumerable<Report> GetAllReportByOrganAndUserId(string Organ, string UserId);

        IEnumerable<Report> GetAllPositiveReports();
        IEnumerable<Report> GetAllNegativeReports();

        IEnumerable<Report> GetAllPositiveReportsByUser(string UserId);
        IEnumerable<Report> GetAllNegativeReportsByUser(string UserId);

        IEnumerable<Report> GetAllPositiveReportsByOrgan(string Organ);
        IEnumerable<Report> GetAllNegativeReportsByOrgan(string Organ);

        IEnumerable<Report> GetAllPositiveReportsByOrganAndUserId(string Organ, string UserId);
        IEnumerable<Report> GetAllNegativeReportsByOrganAndUserId(string Organ, string UserId);

        
        IEnumerable<Report> GetAllPositiveReportsByUserLastWeek(string UserId);
        IEnumerable<Report> GetAllNegativeReportsByUserLastWeek(string UserId);
        IEnumerable<Report> GetAllPositiveReportsByUserLastMonth(string UserId);
        IEnumerable<Report> GetAllNegativeReportsByUserLastMonth(string UserId);
        IEnumerable<Report> GetAllPositiveReportsByUserLastYear(string UserId);
        IEnumerable<Report> GetAllNegativeReportsByUserLastYear(string UserId);



        //Report
        Report GetReportById(Guid ReportId);
        
        //ADMIN
        //Common
        int GetTotalNumberOfTests();
        int GetTotalNumberOfTestsForLastWeek();
        int GetTotalNumberOfTestsForLastMonth();
        int GetTotalNumberOfTestsForLastYear();

        //positive
        int GetTotalNumberOfPositiveTests();
        int GetTotalNumberOfPositiveTestsForLastWeek();
        int GetTotalNumberOfPositiveTestsForLastMonth();
        int GetTotalNumberOfPositiveTestsForLastYear();

        //negative
        int GetTotalNumberOfNegativeTests();
        int GetTotalNumberOfNegativeTestsForLastWeek();
        int GetTotalNumberOfNegativeTestsForLastMonth();
        int GetTotalNumberOfNegativeTestsForLastYear();

        //USER
        //common
        int GetTotalNumberOfTestsByUserId(string UserId);
        int GetTotalNumberOfTestsForLastWeekByUserId(string UserId);
        int GetTotalNumberOfTestsForLastMonthByUserId(string UserId);
        int GetTotalNumberOfTestsForLastYearByUserId(string UserId);

        //positive
        int GetTotalNumberOfPositiveTestsByUserId(string UserId);
        int GetTotalNumberOfPositiveTestsForLastWeekByUserId(string UserId);
        int GetTotalNumberOfPositiveTestsForLastMonthByUserId(string UserId);
        int GetTotalNumberOfPositiveTestsForLastYearByUserId(string UserId);

        //negative
        int GetTotalNumberOfNegativeTestsByUserId(string UserId);
        int GetTotalNumberOfNegativeTestsForLastWeekByUserId(string UserId);
        int GetTotalNumberOfNegativeTestsForLastMonthByUserId(string UserId);
        int GetTotalNumberOfNegativeTestsForLastYearByUserId(string UserId);

        Report GetReportByWSI(Guid WSIId);

        //CRUD

        void Insert(Report Report);
        void Delete(Report Report);


    }
}
