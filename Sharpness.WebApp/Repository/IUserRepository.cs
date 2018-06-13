using IdentitySample.Models;
using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Repository

{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(string Id);
        ApplicationUser GetUserByUserName(string UserName);
        ApplicationUser GetUserByEmail(string Email);
        string GetUsernameById(string UserId);
        void DeleteUserById(string UserId); 

       
        

    }
}
