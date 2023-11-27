using Microsoft.EntityFrameworkCore;
using RefundManagementApp.BusinessLayer.ViewModels;
using RefundManagementApp.DataLayer;
using RefundManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RefundManagementApp.BusinessLayer.Services.Repository
{
    public class RefundManagementRepository : IRefundManagementRepository
    {
        private readonly RefundManagementAppDbContext _dbContext;
        public RefundManagementRepository(RefundManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Refund> CreateRefund(Refund RefundModel)
        {
            try
            {
                var result = await _dbContext.Refunds.AddAsync(RefundModel);
                await _dbContext.SaveChangesAsync();
                return RefundModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteRefundById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Refunds.Single(a => a.RefundId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Refund> GetAllRefunds()
        {
            try
            {
                var result = _dbContext.Refunds.
                OrderByDescending(x => x.RefundId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Refund> GetRefundById(long id)
        {
            try
            {
                return await _dbContext.Refunds.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Refund> UpdateRefund(RefundViewModel model)
        {
            var Refund = await _dbContext.Refunds.FindAsync(model.RefundId);
            try
            {

                _dbContext.Refunds.Update(Refund);
                await _dbContext.SaveChangesAsync();
                return Refund;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}