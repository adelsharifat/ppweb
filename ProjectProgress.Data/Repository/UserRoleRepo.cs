using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Data.Repository
{
    public class UserRoleRepo : Repo<UserRole>, IUserRoleRepo
    {
        public UserRoleRepo(AppDbContext context) : base(context)
        {
        }
    }
}
