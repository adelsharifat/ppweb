using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Data.Repository
{
    public class RoleRepo : Repo<AppRole>, IRoleRepo
    {
        public RoleRepo(AppDbContext context) : base(context)
        {

        }
    }
}
