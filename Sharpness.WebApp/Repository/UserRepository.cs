using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sharpness.Persistence.Entities;
using Sharpness.Persistence;
using System.Collections;

namespace Sharpness.WebApp.Repository
{
    public class UserRepository : IUserRepository
    {
        public void DeleteUserById(string UserId)
        {
            var _context = new DataContext();
            var _appContext = new ApplicationDbContext();
            var reports = _context.Reports.Where(r => r.UserId == UserId).ToList();
            foreach(var item in reports)
            {
                _context.Reports.Remove(item);
            }
            _context.SaveChanges();
            var wsis = _context.WSIs.Where(w=> w.UserId==UserId).ToList();
            foreach (var item in wsis)
            {
                _context.WSIs.Remove(item);
            }
            _context.SaveChanges();

            _appContext.Users.Remove(_appContext.Users.Find(UserId));
            _appContext.SaveChanges();


           


        }

        public IEnumerable<Report> GetAllReportsByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r=> r.UserId==UserId).ToList();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            var _context = new ApplicationDbContext();
            return _context.Users.ToList();

        }

        

        public Report GetReportByWSI(Guid WSIId)
        {
            var _context = new DataContext();
            return _context.Reports.Where(r=> r.WSIId==WSIId).FirstOrDefault();
        }

        public ApplicationUser GetUserByEmail(string Email)
        {
            var _context = new ApplicationDbContext();
            return _context.Users.Where(u => u.Email == Email).FirstOrDefault();
        }

        public ApplicationUser GetUserById(string Id)
        {
            var _context = new ApplicationDbContext();
            return _context.Users.Where(u => u.Id == Id).FirstOrDefault();
        }

        public ApplicationUser GetUserByUserName(string UserName)
        {
            var _context = new ApplicationDbContext();
            return _context.Users.Where(u => u.UserName == UserName).FirstOrDefault();
        }

        public string GetUsernameById(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Users.Where(u => u.Id == UserId).First().UserName;
        }
    }
}