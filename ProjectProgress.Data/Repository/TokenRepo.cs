using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Data.Repository
{
    public class TokenRepo : Repo<RefreshToken>, ITokenRepo
    {
        public TokenRepo(AppDbContext context) : base(context)
        {
        }
    }
}
