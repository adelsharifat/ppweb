using Microsoft.EntityFrameworkCore;
using ProjectProgress.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IUserRepo userRepo;
        public IUserRepo UserRepo {
            get
            {
                if (userRepo == null) userRepo = new UserRepo(_context);
                return userRepo;
            }
        }

        private IRoleRepo roleRepo;
        public IRoleRepo RoleRepo {
            get
            {
                if (roleRepo == null) roleRepo =  new RoleRepo(_context);
                return roleRepo;
            }
        }

        private IUserRoleRepo userRoleRepo;
        public IUserRoleRepo UserRoleRepo
        {
            get
            {
                if (userRoleRepo == null) userRoleRepo =  new UserRoleRepo(_context);
                return userRoleRepo;
            }
        }

        private ITokenRepo tokenRepo;
        public ITokenRepo TokenRepo
        {
            get
            {
                if (tokenRepo == null) tokenRepo = new TokenRepo(_context);
                return tokenRepo;
            }
        }

        private IItemRepo itemRepo;
        public IItemRepo ItemRepo
        {
            get
            {
                if (itemRepo == null) itemRepo = new ItemRepo(_context);
                return itemRepo;
            }
        }

        private IAttachmentRepo attachmentRepo;
        public IAttachmentRepo AttachmentRepo
        {
            get
            {
                if (attachmentRepo == null) attachmentRepo = new AttachmentRepo(_context);
                return attachmentRepo;
            }
        }

        public async Task<int> Commit()
        {
            return await _context?.SaveChangesAsync();
        }
    }
}
