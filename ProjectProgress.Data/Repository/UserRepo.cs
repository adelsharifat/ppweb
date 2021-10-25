using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Data.Repository
{
    public class UserRepo : Repo<AppUser>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }
    }
}
