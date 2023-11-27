using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefundManagementApp.BusinessLayer.Interfaces;
using RefundManagementApp.BusinessLayer.ViewModels;
using RefundManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefundManagementApp.Controllers
{
    [ApiController]
    public class RefundManagementController : ControllerBase
    {
        private readonly IRefundManagementService  _refundService;
        public RefundManagementController(IRefundManagementService refundservice)
        {
             _refundService = refundservice;
        }

        [HttpPost]
        [Route("create-refund")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRefund([FromBody] Refund model)
        {
            var RefundExists = await  _refundService.GetRefundById(model.RefundId);
            if (RefundExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Refund already exists!" });
            var result = await  _refundService.CreateRefund(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Refund creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Refund created successfully!" });

        }


        [HttpPut]
        [Route("update-refund")]
        public async Task<IActionResult> UpdateRefund([FromBody] RefundViewModel model)
        {
            var Refund = await  _refundService.UpdateRefund(model);
            if (Refund == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Refund With Id = {model.RefundId} cannot be found" });
            }
            else
            {
                var result = await  _refundService.UpdateRefund(model);
                return Ok(new Response { Status = "Success", Message = "Refund updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-refund")]
        public async Task<IActionResult> DeleteRefund(long id)
        {
            var Refund = await  _refundService.GetRefundById(id);
            if (Refund == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Refund With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _refundService.DeleteRefundById(id);
                return Ok(new Response { Status = "Success", Message = "Refund deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-refund-by-id")]
        public async Task<IActionResult> GetRefundById(long id)
        {
            var Refund = await  _refundService.GetRefundById(id);
            if (Refund == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Refund With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Refund);
            }
        }

        [HttpGet]
        [Route("get-all-refunds")]
        public async Task<IEnumerable<Refund>> GetAllRefunds()
        {
            return   _refundService.GetAllRefunds();
        }
    }
}
