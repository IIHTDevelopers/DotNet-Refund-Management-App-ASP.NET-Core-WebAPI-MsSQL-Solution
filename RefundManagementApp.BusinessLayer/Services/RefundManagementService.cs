using RefundManagementApp.BusinessLayer.Interfaces;
using RefundManagementApp.BusinessLayer.Services.Repository;
using RefundManagementApp.BusinessLayer.ViewModels;
using RefundManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementApp.BusinessLayer.Services
{
    public class RefundManagementService : IRefundManagementService
    {
        private readonly IRefundManagementRepository _repo;

        public RefundManagementService(IRefundManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Refund> CreateRefund(Refund employeeRefund)
        {
            return await _repo.CreateRefund(employeeRefund);
        }

        public async Task<bool> DeleteRefundById(long id)
        {
            return await _repo.DeleteRefundById(id);
        }

        public List<Refund> GetAllRefunds()
        {
            return  _repo.GetAllRefunds();
        }

        public async Task<Refund> GetRefundById(long id)
        {
            return await _repo.GetRefundById(id);
        }

        public async Task<Refund> UpdateRefund(RefundViewModel model)
        {
           return await _repo.UpdateRefund(model);
        }
    }
}
