using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Data.Repository
{
    public class ItemRepo : Repo<Item>, IItemRepo
    {
        public ItemRepo(AppDbContext context) : base(context)
        {
        }
    }
}
