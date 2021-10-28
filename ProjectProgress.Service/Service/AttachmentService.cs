using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Shared;
using ProjectProgress.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Service.Service
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttachmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Attachment>> GETALL_ASYNC()
        {
            try
            {
                return await _unitOfWork.AttachmentRepo.FIND_ASYNC();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Attachment> GET_ASYNC(Expression<Func<Attachment, bool>> expression)
        {
            try
            {
                return await _unitOfWork.AttachmentRepo.GET_ASYNC(expression);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<MutationResult> ADD_ASYNC(Attachment attachment)
        {
            try
            {
                await _unitOfWork.AttachmentRepo.CREATE_ASYNC(attachment);
                var result = await _unitOfWork.Commit();
                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Add attachment faild");
            }
            catch (Exception ex)
            {
                return new MutationResult(false,ex.Message);
            }
        }
        public async Task<MutationResult> UPDATE_ASYNC(Attachment attachment)
        {
            try
            {
                await _unitOfWork.AttachmentRepo.CREATE_ASYNC(attachment);
                var result = await _unitOfWork.Commit();
                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Update attachment faild");
            }
            catch (Exception ex)
            {
                return new MutationResult(false, ex.Message);
            }
        }
        public async Task<MutationResult> DELETE_ASYNC(Attachment attachment)
        {
            try
            {
                await _unitOfWork.AttachmentRepo.CREATE_ASYNC(attachment);
                var result = await _unitOfWork.Commit();
                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Delete item faild");
            }
            catch (Exception ex)
            {
                return new MutationResult(false, ex.Message);
            }
        }
    }
}
