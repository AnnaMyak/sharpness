using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpness.Persistence.Entities;

namespace Sharpness.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        public void Delete(Report r)
        {
            var _context = new DataContext();
            _context.Reports.Remove(r);
            _context.SaveChanges();
        }

        public IEnumerable<Report> GetAllNegativeReports()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r=> r.Evaluation==false).ToList();
        }

        public IEnumerable<Report> GetAllNegativeReportsByOrgan(string Organ)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.OrganName == Organ).ToList();
        }

        public IEnumerable<Report> GetAllNegativeReportsByOrganAndUserId(string Organ, string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.OrganName == Organ && r.UserId==UserId).ToList();

        }

        public IEnumerable<Report> GetAllNegativeReportsByUser(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r=> r.UserId==UserId && r.Evaluation==false).ToList();
        }

        public IEnumerable<Report> GetAllNegativeReportsByUserLastMonth(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == false&& (r.Creation <DateTime.Now && r.Creation > DateTime.Now.AddMonths(-1))).ToList();

        }

        public IEnumerable<Report> GetAllNegativeReportsByUserLastWeek(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == false && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddDays(-7))).ToList();
        }

        public IEnumerable<Report> GetAllNegativeReportsByUserLastYear(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == false && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddYears(-1))).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReports()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r=> r.Evaluation==true).ToList();
        }

        public IEnumerable<Report> GetAllPositiveReportsByOrgan(string Organ)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.OrganName == Organ).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByOrganAndUserId(string Organ, string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.OrganName == Organ && r.UserId==UserId).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByUser(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => (r.Evaluation == true) && r.UserId == UserId).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByUserLastMonth(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == true && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddMonths(-1))).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByUserLastWeek(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == true && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddDays(-7))).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByUserLastYear(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == true && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddYears(-1))).ToList();

        }

        public IEnumerable<Report> GetAllReportByOrganAndUserId(string Organ, string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.OrganName == Organ && r.UserId == UserId).ToList();
        }

        public IEnumerable<Report> GetAllReports()
        {
            var _context = new DataContext();
            return _context.Reports.ToList();
        }
        

        public IEnumerable<Report> GetAllReportsByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId==UserId).ToList();
        }

        public IEnumerable<Report> GetAllReportsByUserIdLastWeek(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Creation > DateTime.Now.AddDays(-7)).ToList();
        }

        public IEnumerable<Report> GetAllReportsByUserLastMonth(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Creation > DateTime.Now.AddMonths(-1)).ToList();
        }

        public IEnumerable<Report> GetAllReportsByUserLastYear(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Creation > DateTime.Now.AddYears(-1)).ToList();

        }

        public IEnumerable<Report> GetAllReportsLastMonth()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation> DateTime.Now.AddMonths(-1)).ToList();
        }

        public IEnumerable<Report> GetAllReportsLastWeek()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddDays(-7)).ToList();
        }

        public IEnumerable<Report> GetAllReportsLastYear()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddYears(-1)).ToList();
        }

        public Report GetReportById(Guid ReportId)
        {
            var _context = new DataContext();
            return _context.Reports.Find(ReportId);
        }

        public Report GetReportByWSI(Guid WSIId)
        {
            throw new NotImplementedException();
        }

        public int GetTotalNumberOfNegativeTests()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r=> r.Evaluation==false && r.UserId==UserId).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastMonth()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation>DateTime.Now.AddMonths(-1)).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastMonthByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddMonths(-1) && r.UserId==UserId).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastWeek()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddDays(-7)).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastWeekByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddDays(-7) && r.UserId == UserId).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastYear()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddYears(-1)).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastYearByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddYears(-1) && r.UserId==UserId).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTests()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true).ToList().Count;
        }

        public int GetTotalNumberOfPositiveTestsByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.UserId==UserId).ToList().Count;
        }

        public int GetTotalNumberOfPositiveTestsForLastMonth()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation> DateTime.Now.AddMonths(-1)).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastMonthByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddMonths(-1) && r.UserId==UserId).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastWeek()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddDays(-7)).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastWeekByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddDays(-7) && r.UserId==UserId).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastYear()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddYears(-1)).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastYearByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddYears(-1) && r.UserId==UserId).ToList().Count;

        }

        public int GetTotalNumberOfTests()
        {
            var _context = new DataContext();
            return _context.Reports.ToList().Count;
        }

        public int GetTotalNumberOfTestsByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r=> r.UserId==UserId).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastMonth()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddMonths(-1)).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastMonthByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddMonths(-1) && r.UserId==UserId).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastWeek()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddDays(-7)).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastWeekByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddDays(-7) && r.UserId==UserId).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastYear()
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddYears(-1)).ToList().Count;   
        }

        public int GetTotalNumberOfTestsForLastYearByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddYears(-1) && r.UserId==UserId).ToList().Count;
        }

        public void Insert(Report Report)
        {
            var _context = new DataContext();
            _context.Reports.Add(Report);
            _context.SaveChanges();
        }
    }
}
