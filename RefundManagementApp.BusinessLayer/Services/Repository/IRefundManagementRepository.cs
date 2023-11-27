using RefundManagementApp.BusinessLayer.ViewModels;
using RefundManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefundManagementApp.BusinessLayer.Services.Repository
{
    public interface IRefundManagementRepository
    {
        List<Refund> GetAllRefunds();
        Task<Refund> CreateRefund(Refund refund);
        Task<Refund> GetRefundById(long id);
        Task<bool> DeleteRefundById(long id);
        Task<Refund> UpdateRefund(RefundViewModel model);
    }
}
