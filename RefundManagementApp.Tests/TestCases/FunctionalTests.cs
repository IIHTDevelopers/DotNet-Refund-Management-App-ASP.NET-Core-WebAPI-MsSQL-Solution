
using Moq;
using RefundManagementApp.BusinessLayer.Interfaces;
using RefundManagementApp.BusinessLayer.Services;
using RefundManagementApp.BusinessLayer.Services.Repository;
using RefundManagementApp.BusinessLayer.ViewModels;
using RefundManagementApp.DataLayer;
using RefundManagementApp.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RefundManagementApp.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly RefundManagementAppDbContext _dbContext;

        private readonly IRefundManagementService  _refundService;
        public readonly Mock<IRefundManagementRepository> refundservice= new Mock<IRefundManagementRepository >();

        private readonly Refund _refund;
        private readonly RefundViewModel _refundViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Create_Refund()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                refundservice.Setup(repos => repos.CreateRefund(_refund)).ReturnsAsync(_refund);
                var result = await  _refundService.CreateRefund(_refund);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_Update_Refund()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                refundservice.Setup(repos => repos.UpdateRefund(_refundViewModel)).ReturnsAsync(_refund); 
                var result = await  _refundService.UpdateRefund(_refundViewModel);
                if (result != null)
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
        public async Task<bool> Testfor_GetRefundById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                refundservice.Setup(repos => repos.GetRefundById(id)).ReturnsAsync(_refund);
                var result = await  _refundService.GetRefundById(id);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_DeleteRefundById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                refundservice.Setup(repos => repos.DeleteRefundById(id)).ReturnsAsync(response);
                var result = await  _refundService.DeleteRefundById(id);
                //Assertion
                if (result != null)
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