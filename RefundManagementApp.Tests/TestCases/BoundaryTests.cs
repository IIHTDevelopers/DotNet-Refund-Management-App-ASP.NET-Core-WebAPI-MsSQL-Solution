
using Moq;
using RefundManagementApp.BusinessLayer.Interfaces;
using RefundManagementApp.BusinessLayer.Services.Repository;
using RefundManagementApp.BusinessLayer.Services;
using RefundManagementApp.BusinessLayer.ViewModels;
using RefundManagementApp.DataLayer;
using RefundManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RefundManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly RefundManagementAppDbContext _dbContext;

        private readonly IRefundManagementService  _refundService;
        public readonly Mock<IRefundManagementRepository> refundservice = new Mock<IRefundManagementRepository>();

        private readonly Refund _refund;
        private readonly RefundViewModel _refundViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
             _refundService = new RefundManagementService(refundservice.Object);

            _output = output;

            _refund = new Refund
            {
                RefundId = 1,
                Reason = "Product not as described",
                Amount = 25.50m,
                RequestDate = DateTime.Now.AddDays(-5),
                Approved = true
            };

            _refundViewModel = new RefundViewModel
            {
                RefundId = 1,
                Reason = "Product not as described",
                Amount = 25.50m,
                RequestDate = DateTime.Now.AddDays(-5),
                Approved = true
            };
        }
        
        [Fact]
        public async Task<bool> Testfor_Refund_Reason_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                refundservice.Setup(repo => repo.CreateRefund(_refund)).ReturnsAsync(_refund);
                var result = await  _refundService.CreateRefund(_refund);
                var actualLength = _refund.Reason.ToString().Length;
                if (result.Reason.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

       
        [Fact]
        public async Task<bool> Testfor_Refund_Amount_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                refundservice.Setup(repo => repo.CreateRefund(_refund)).ReturnsAsync(_refund);
                var result = await  _refundService.CreateRefund(_refund);
                var actualLength = _refund.Amount.ToString().Length;
                if (result.Amount.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Refund_Date_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                refundservice.Setup(repo => repo.CreateRefund(_refund)).ReturnsAsync(_refund);
                var result = await  _refundService.CreateRefund(_refund);
                var actualLength = _refund.RequestDate.ToString().Length;
                if (result.RequestDate.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_RefundId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                refundservice.Setup(repo => repo.CreateRefund(_refund)).ReturnsAsync(_refund);
                var result = await  _refundService.CreateRefund(_refund);
                var actualLength = _refund.RefundId.ToString().Length;
                if (result.RefundId.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}