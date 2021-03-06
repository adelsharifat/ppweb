using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Data.Repository
{
    public class AttachmentRepo : Repo<Attachment>, IAttachmentRepo
    {
        public AttachmentRepo(AppDbContext context) : base(context)
        {
        }
    }
}
